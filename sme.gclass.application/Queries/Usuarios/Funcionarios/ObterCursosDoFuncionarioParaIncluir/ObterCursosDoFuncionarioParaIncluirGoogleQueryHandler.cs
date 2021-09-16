using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Funcionarios.ObterCursosDoFuncionarioParaIncluir
{
    public class ObterCursosDoFuncionarioParaIncluirGoogleQueryHandler : IRequestHandler<ObterCursosDoFuncionarioParaIncluirGoogleQuery, IEnumerable<FuncionarioCursoEol>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterCursosDoFuncionarioParaIncluirGoogleQueryHandler(IRepositorioFuncionarioEol repositorioFuncionarioEol)
        {
            this.repositorioFuncionarioEol = repositorioFuncionarioEol;
        }

        public async Task<IEnumerable<FuncionarioCursoEol>> Handle(ObterCursosDoFuncionarioParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionarioEol.ObterCursosDoFuncionarioParaIncluirAsync(request.Rf, request.AnoLetivo, request.ParametrosCargaInicialDto);
    }
}