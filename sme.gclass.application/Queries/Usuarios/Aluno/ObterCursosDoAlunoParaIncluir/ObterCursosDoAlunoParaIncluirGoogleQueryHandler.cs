using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Aluno.ObterCursosDoAlunoParaIncluir
{
    public class ObterCursosDoAlunoParaIncluirGoogleQueryHandler : IRequestHandler<ObterCursosDoAlunoParaIncluirGoogleQuery, IEnumerable<AlunoCursoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterCursosDoAlunoParaIncluirGoogleQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol;
        }

        public async Task<IEnumerable<AlunoCursoEol>> Handle(ObterCursosDoAlunoParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioAlunoEol.ObterCursosDoAlunoParaIncluirAsync(request.CodigoAluno, request.AnoLetivo, request.ParametrosCargaInicialDto);
    }
}