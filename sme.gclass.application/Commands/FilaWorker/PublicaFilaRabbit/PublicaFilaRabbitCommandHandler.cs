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
        private readonly IConnection connectionRabbit;

        public PublicaFilaRabbitCommandHandler(IConnection connectionRabbit)
        {
            this.connectionRabbit = connectionRabbit ?? throw new ArgumentNullException(nameof(connectionRabbit));
        }

        public async Task<bool> Handle(PublicaFilaRabbitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem);

                var mensagemJson = JsonConvert.SerializeObject(mensagem);
                var body = Encoding.UTF8.GetBytes(mensagemJson);

                await using var canal = await connectionRabbit.CreateChannelAsync(null, cancellationToken);

                var props = new BasicProperties
                {
                    Persistent = true
                };

                await canal.BasicPublishAsync(
                    ExchangeRabbit.GoogleSync,
                    request.NomeRota,
                    false,
                    props,
                    body,
                    cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
