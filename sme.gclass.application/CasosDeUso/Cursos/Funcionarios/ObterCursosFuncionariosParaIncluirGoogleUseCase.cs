using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
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

        public async Task<IEnumerable<FuncionarioCursoEol>> Executar(long turmaId, long componenteCurricularId)
            => await mediator.Send(new ObterFuncionariosDoCursoParaIncluirGoogleQuery(DateTime.Now.Year, turmaId, componenteCurricularId));
    }
}