using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class AbstractTratarFilaErrosUseCase<T> : ITratarFilaErrosUseCase where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IAsyncPolicy _policy;

        public AbstractTratarFilaErrosUseCase(string filaErro, string filaProcesso, IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            FilaErro = filaErro;
            FilaProcesso = filaProcesso;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyPublicaFila);
        }

        public string FilaErro { get; }
        public string FilaProcesso { get; }

        public async Task Executar()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetSection("ConfiguracaoRabbit:HostName").Value,
                UserName = _configuration.GetSection("ConfiguracaoRabbit:UserName").Value,
                Password = _configuration.GetSection("ConfiguracaoRabbit:Password").Value,
                VirtualHost = _configuration.GetSection("ConfiguracaoRabbit:Virtualhost").Value
            };

            await _policy.ExecuteAsync(() => TratarMensagens(FilaErro, factory));
        }

        private async Task TratarMensagens(string fila, ConnectionFactory factory)
        {
            await using var conexaoRabbit = await factory.CreateConnectionAsync();
            await using var channel = await conexaoRabbit.CreateChannelAsync();

            while (true)
            {
                // autoAck: false = a mensagem só sai da fila de erro quando confirmarmos
                var mensagemFila = await channel.BasicGetAsync(fila, autoAck: false);
                if (mensagemFila == null)
                    break;

                var mensagem = Encoding.UTF8.GetString(mensagemFila.Body.ToArray());
                var mensagemRabbit = JsonConvert.DeserializeObject<MensagemRabbit>(mensagem);
                var dto = mensagemRabbit?.ObterObjetoMensagem<T>();

                if (dto == null)
                {
                    // mensagem vazia ou inválida: descarta
                    await channel.BasicAckAsync(mensagemFila.DeliveryTag, false);
                    continue;
                }

                var publicou = await _mediator.Send(new PublicaFilaRabbitCommand(FilaProcesso, MontarMensagemProcesso(dto)));

                if (publicou)
                    await channel.BasicAckAsync(mensagemFila.DeliveryTag, false);
                else
                {
                    // falhou: devolve para a fila de erro e para o loop
                    await channel.BasicNackAsync(mensagemFila.DeliveryTag, false, true);
                    break;
                }
            }
        }

        protected virtual object MontarMensagemProcesso(T dto) => dto;
    }
}
