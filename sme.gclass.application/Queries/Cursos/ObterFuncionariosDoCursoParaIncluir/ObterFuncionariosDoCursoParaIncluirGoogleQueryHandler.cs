using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterFuncionariosDoCursoParaIncluir
{
    public class ObterFuncionariosDoCursoParaIncluirGoogleQueryHandler : IRequestHandler<ObterFuncionariosDoCursoParaIncluirGoogleQuery, IEnumerable<FuncionarioCursoEol>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterFuncionariosDoCursoParaIncluirGoogleQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol;
        }

        public async Task<IEnumerable<FuncionarioCursoEol>> Handle(ObterFuncionariosDoCursoParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterFuncionariosDoCursoParaIncluirAsync(request.AnoLetivo, request.TurmaId, request.ComponenteCurricularId, request.ParametrosCargaInicialDto);
    }
}