using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using RabbitMQ.Client;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAvisosGsaErroProcessarUseCase : IIncluirAvisosGsaErroProcessarUseCase
    {
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public IncluirAvisosGsaErroProcessarUseCase(IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry, IMediator mediator)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyPublicaFila);
        }

        public async Task Executar()
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration.GetSection("ConfiguracaoRabbit:HostName").Value,
                UserName = configuration.GetSection("ConfiguracaoRabbit:UserName").Value,
                Password = configuration.GetSection("ConfiguracaoRabbit:Password").Value,
                VirtualHost = configuration.GetSection("ConfiguracaoRabbit:Virtualhost").Value
            };

            await policy.ExecuteAsync(() => TratarMensagens(RotasRabbit.FilaGsaMuralAvisosIncluirErro, factory));
        }

        private async Task TratarMensagens(string fila, ConnectionFactory factory)
        {
            using (var conexaoRabbit = factory.CreateConnection())
            {
                using (IModel _channel = conexaoRabbit.CreateModel())
                {
                    while (true)
                    {
                        var mensagemFila = _channel.BasicGet(fila, true);
                        if (mensagemFila == null)
                            break;

                        var mensagem = Encoding.UTF8.GetString(mensagemFila.Body.ToArray());
                        var mensagemRabbit = JsonConvert.DeserializeObject<MensagemRabbit>(mensagem);
                        var avisoGsa = mensagemRabbit.ObterObjetoMensagem<AvisoMuralGsaDto>();

                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosIncluir, avisoGsa));
                    }
                }
            }
        }
    }
}
