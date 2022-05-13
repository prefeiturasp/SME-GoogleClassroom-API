using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.RemoverTurma;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverTurmaUseCase : IRemoverTurmaUseCase
    {
        public IMediator mediator;

        public RemoverTurmaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(FiltroRemoverTurmaDto filtro)
        {
            var cursosParaRemover = new List<string>();
            var turmasId =
                await mediator.Send(new ObterTurmasPorTipoECodigosQuery(filtro.CodigoTurma));
            foreach (var turmaId in turmasId)
            {
                var cursos = await mediator.Send(new ObterIdsCursosPorTurmaQuery(turmaId));
                cursosParaRemover.AddRange(cursos.Select(id => id.ToString()));
            }

            foreach (var cursoId in cursosParaRemover)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoAhRemover,
                    mensagem: cursoId));
            }

            return true;
        }
    }
}