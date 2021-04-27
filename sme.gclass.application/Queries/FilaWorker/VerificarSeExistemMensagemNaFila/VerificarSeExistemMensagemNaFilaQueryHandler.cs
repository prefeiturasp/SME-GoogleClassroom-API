using MediatR;
using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class VerificarSeExistemMensagemNaFilaQueryHandler : IRequestHandler<VerificarSeExistemMensagemNaFilaQuery, bool>
    {
        private readonly IModel rabbitChannel;

        public VerificarSeExistemMensagemNaFilaQueryHandler(IModel rabbitChannel)
        {
            this.rabbitChannel = rabbitChannel ?? throw new ArgumentNullException(nameof(rabbitChannel));
        }

        public async Task<bool> Handle(VerificarSeExistemMensagemNaFilaQuery request, CancellationToken cancellationToken)
        {
            rabbitChannel.QueueBind(request.RotaFila, RotasRabbit.ExchangeGoogleSync, request.RotaFila);
            var existemMensagens = rabbitChannel.MessageCount(request.RotaFila) > uint.MinValue;
            return await Task.FromResult(existemMensagens);
        }
    }
}