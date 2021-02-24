using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
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
            var mensagem = new MensagemRabbit(request.Mensagem);

            var mensagemJson = JsonConvert.SerializeObject(mensagem);
            var body = Encoding.UTF8.GetBytes(mensagemJson);

            rabbitChannel.QueueBind(request.NomeFila, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaGoogleSync);
            
            rabbitChannel.BasicPublish(RotasRabbit.ExchangeGoogleSync, request.NomeFila, null, body);

            return Task.FromResult(true);
        }
    }
}
