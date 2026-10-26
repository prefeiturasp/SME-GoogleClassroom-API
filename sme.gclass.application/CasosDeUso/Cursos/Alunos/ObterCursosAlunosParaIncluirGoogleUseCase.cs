using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System;
using System.Collections.Generic;
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
            var anoLetivo = DateTime.Today.Year;

            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(anoLetivo));
            return await mediator.Send(new ObterAlunosDoCursoParaIncluirGoogleQuery(anoLetivo, turmaId, componenteCurricularId, parametrosCargaInicialDto));
        }
    }
}