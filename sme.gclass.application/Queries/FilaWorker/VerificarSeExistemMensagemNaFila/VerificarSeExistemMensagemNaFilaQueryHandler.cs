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
        private readonly IConnection connectionRabbit;

        public VerificarSeExistemMensagemNaFilaQueryHandler(IConnection connectionRabbit)
        {
            this.connectionRabbit = connectionRabbit ?? throw new ArgumentNullException(nameof(connectionRabbit));
        }

        public async Task<bool> Handle(VerificarSeExistemMensagemNaFilaQuery request, CancellationToken cancellationToken)
        {
            await using var canal = await connectionRabbit.CreateChannelAsync(null, cancellationToken);

            await canal.QueueBindAsync(request.RotaFila, ExchangeRabbit.GoogleSync, request.RotaFila, cancellationToken: cancellationToken);

            var quantidade = await canal.MessageCountAsync(request.RotaFila, cancellationToken);
            return quantidade > uint.MinValue;
        }
    }
}