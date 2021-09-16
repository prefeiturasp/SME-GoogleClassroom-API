using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosCursosParaIncluirGoogleUseCase : IObterFuncionariosCursosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosCursosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<FuncionarioCursoEol>> Executar(long rf)
        {
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            return await mediator.Send(new ObterCursosDoFuncionarioParaIncluirGoogleQuery(rf, DateTime.Now.Year, parametrosCargaInicialDto));
        }
    }
}