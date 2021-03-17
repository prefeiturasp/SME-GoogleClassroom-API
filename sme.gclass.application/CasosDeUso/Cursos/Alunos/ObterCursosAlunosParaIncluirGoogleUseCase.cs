using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
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
            this.mediator = mediator;
        }

        public async Task<IEnumerable<AlunoCursoEol>> Executar(long turmaId, long componenteCurricularId)
            => await mediator.Send(new ObterAlunosDoCursoParaIncluirGoogleQuery(DateTime.Now.Year, turmaId, componenteCurricularId));
    }
}