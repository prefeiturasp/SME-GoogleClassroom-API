using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosParaCadastrarGoogleUseCase : IObterAlunosCursosParaCadastrarGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosCursosParaCadastrarGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<AlunoCursoEol>> Executar(long codigoAluno)
        {
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            return await mediator.Send(new ObterCursosDoAlunoParaIncluirGoogleQuery(codigoAluno, DateTime.Now.Year, parametrosCargaInicialDto));
        }
    }
}