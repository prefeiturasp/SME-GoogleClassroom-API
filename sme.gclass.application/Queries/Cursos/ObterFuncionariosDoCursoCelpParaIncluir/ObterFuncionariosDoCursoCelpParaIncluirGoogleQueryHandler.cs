using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosDoCursoCelpParaIncluirGoogleQueryHandler : IRequestHandler<ObterFuncionariosDoCursoCelpParaIncluirGoogleQuery, IEnumerable<FuncionarioCursoEol>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterFuncionariosDoCursoCelpParaIncluirGoogleQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol;
        }

        public async Task<IEnumerable<FuncionarioCursoEol>> Handle(ObterFuncionariosDoCursoCelpParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterFuncionariosDoCursoCelpParaIncluirAsync(request.AnoLetivo, request.TurmaId, request.ComponenteCurricularId);
    }
}