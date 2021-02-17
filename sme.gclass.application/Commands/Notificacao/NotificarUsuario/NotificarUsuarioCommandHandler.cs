using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class NotificarUsuarioCommandHandler : IRequestHandler<NotificarUsuarioCommand, long>
    {
        private readonly IMediator mediator;

        public NotificarUsuarioCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<long> Handle(NotificarUsuarioCommand request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
