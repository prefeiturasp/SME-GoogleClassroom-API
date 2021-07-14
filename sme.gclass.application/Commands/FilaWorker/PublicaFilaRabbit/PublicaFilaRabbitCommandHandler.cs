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
    public class PublicaFilaRabbitCommandHandler : IRequestHandler<PublicaFilaRabbitCommand, bool>
    {
        private readonly IModel rabbitChannel;

        public PublicaFilaRabbitCommandHandler(IModel rabbitChannel)
        {
            this.rabbitChannel = rabbitChannel ?? throw new ArgumentNullException(nameof(rabbitChannel));
        }

        public Task<bool> Handle(PublicaFilaRabbitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem);

                var mensagemJson = JsonConvert.SerializeObject(mensagem);
                var body = Encoding.UTF8.GetBytes(mensagemJson);

                var props = rabbitChannel.CreateBasicProperties();
                props.Persistent = true;

                rabbitChannel.BasicPublish(ExchangeRabbit.GoogleSync, request.NomeRota, props, body);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return Task.FromResult(false);
            }        
        }
    }
}
