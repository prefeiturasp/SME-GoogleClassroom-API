using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    class ArquivarCursosCommandHandler : AsyncRequestHandler<ArquivarCursosCommand>
    {
        private readonly IMediator mediator;
        
        public ArquivarCursosCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(ArquivarCursosCommand request, CancellationToken cancellationToken)
        {
            var cursosEol = await mediator.Send(new ObterCursosPorAnoLetivoSemestreQuery(request.AnoLetivo, request.Semestre));

            foreach (var curso in cursosEol)
            {
                var dto = new ArquivarTurmaExtintaDto(curso.TurmaId, DateTime.Now, false);

                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarTratar, dto));
            }
        }
    }
}
