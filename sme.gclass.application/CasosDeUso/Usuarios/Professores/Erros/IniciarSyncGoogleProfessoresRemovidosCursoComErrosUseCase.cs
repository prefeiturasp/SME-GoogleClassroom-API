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

    public class IniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase : IIniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IAsyncPolicy _policy;

        public IniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyPublicaFila);
        }

        public async Task<bool> Executar()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetSection("ConfiguracaoRabbit:HostName").Value,
                UserName = _configuration.GetSection("ConfiguracaoRabbit:UserName").Value,
                Password = _configuration.GetSection("ConfiguracaoRabbit:Password").Value,
                VirtualHost = _configuration.GetSection("ConfiguracaoRabbit:Virtualhost").Value
            };

            await _policy.ExecuteAsync(() => TratarMensagens(RotasRabbit.FilaGsaProfessoresRemovidosCursoErroSync, factory));
            
            return true;
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
                        
                        // TODO: Capturar objeto correto para enviar para fila
                        //var professoresRemovidosCursos = mensagemRabbit.ObterObjetoMensagem<AtividadeGsaDto>();

                        //await _mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoAtribuicaoSync, professoresRemovidosCursos));
                    }
                }
            }
        }
    }
}