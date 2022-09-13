using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class PublicaFilaRabbitSgpCommandHandler : IRequestHandler<PublicaFilaRabbitSgpCommand, bool>
    {
        private readonly IModel rabbitChannel;

        public PublicaFilaRabbitSgpCommandHandler(IModel rabbitChannel)
        {
            this.rabbitChannel = rabbitChannel ?? throw new ArgumentNullException(nameof(rabbitChannel));
        }

        public Task<bool> Handle(PublicaFilaRabbitSgpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagemRabbit = new MensagemRabbitSgp(request.Mensagem, request.UsuarioLogadoRF, request.UsuarioLogadoNome);

                var mensagem = JsonConvert.SerializeObject(mensagemRabbit, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var body = Encoding.UTF8.GetBytes(mensagem);

                var props = rabbitChannel.CreateBasicProperties();
                props.Persistent = true;
                rabbitChannel.BasicPublish(ExchangeRabbit.Sgp, request.NomeFila, props, body);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }        
        }
    }
}
