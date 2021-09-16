using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterAlunosDoCursoParaIncluir
{
    public class ObterAlunosDoCursoParaIncluirGoogleQueryHandler : IRequestHandler<ObterAlunosDoCursoParaIncluirGoogleQuery, IEnumerable<AlunoCursoEol>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterAlunosDoCursoParaIncluirGoogleQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol;
        }

        public async Task<IEnumerable<AlunoCursoEol>> Handle(ObterAlunosDoCursoParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterAlunosDoCursoParaIncluirAsync(request.AnoLetivo, request.TurmaId, request.ComponenteCurricularId, request.ParametrosCargaInicialDto);
    }
}