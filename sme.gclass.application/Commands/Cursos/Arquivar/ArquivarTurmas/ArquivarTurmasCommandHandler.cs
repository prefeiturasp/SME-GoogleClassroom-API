using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    class ArquivarTurmasCommandHandler : AsyncRequestHandler<ArquivarTurmasCommand>
    {
        private readonly IMediator mediator;
        
        public ArquivarTurmasCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(ArquivarTurmasCommand request, CancellationToken cancellationToken)
        {
            var cursosEol = await mediator.Send(new ObterTurmasConcluidasPorAnoLetivoQuery(request.AnoLetivo, request.TurmaId));

            foreach (var curso in cursosEol)
            {
                var dto = new ArquivarTurmaDto(curso.TurmaId, DateTime.Now, false);

                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoArquivarTratar, dto));
            }
        }
    }
}
