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
        private readonly IConnection connectionRabbit;

        public PublicaFilaRabbitSgpCommandHandler(IConnection connectionRabbit)
        {
            this.connectionRabbit = connectionRabbit ?? throw new ArgumentNullException(nameof(connectionRabbit));
        }

        public async Task<bool> Handle(PublicaFilaRabbitSgpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagemRabbit = new MensagemRabbitSgp(request.Mensagem, request.UsuarioLogadoRF, request.UsuarioLogadoNome, request.UsuarioLogadoPerfil);

                var mensagem = JsonConvert.SerializeObject(mensagemRabbit, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var body = Encoding.UTF8.GetBytes(mensagem);

                await using var canal = await connectionRabbit.CreateChannelAsync(null, cancellationToken);

                var props = new BasicProperties
                {
                    Persistent = true
                };

                await canal.BasicPublishAsync(
                    ExchangeRabbit.Sgp,
                    request.NomeFila,
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