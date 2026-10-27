using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosFuncionariosParaIncluirGoogleUseCase : IObterCursosFuncionariosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosFuncionariosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<FuncionarioCursoParaIncluirGoogleDto>> Executar(long turmaId, long componenteCurricularId)
        {
            var anoLetivo = DateTime.Today.Year;
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(anoLetivo));
            return await mediator.Send(new ObterFuncionariosDoCursoParaIncluirGoogleQuery(anoLetivo, turmaId,
                componenteCurricularId, parametrosCargaInicialDto));
        }
    }
}