using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosAlunosParaIncluirGoogleUseCase : IObterCursosAlunosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosAlunosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<AlunoCursoParaIncluirGoogleDto>> Executar(long turmaId, long componenteCurricularId)
        {
            var anoLetivo = await mediator.Send(new ObterAnoLetivoTurmaQuery(turmaId));
            if (!anoLetivo.HasValue)
                return Enumerable.Empty<AlunoCursoParaIncluirGoogleDto>();

            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(anoLetivo.Value));
            return await mediator.Send(new ObterAlunosDoCursoParaIncluirGoogleQuery(anoLetivo.Value, turmaId, componenteCurricularId, parametrosCargaInicialDto));
        }
    }
}