using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresDoCursoParaIncluirGoogleQueryHandler : IRequestHandler<ObterProfessoresDoCursoParaIncluirGoogleQuery, IEnumerable<ProfessorCursoEol>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterProfessoresDoCursoParaIncluirGoogleQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol;
        }

        public async Task<IEnumerable<ProfessorCursoEol>> Handle(ObterProfessoresDoCursoParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterProfessoresDoCursoParaIncluirGoogleAsync(request.AnoLetivo, request.TurmaId, request.ComponenteCurricularId, request.ParametrosCargaInicialDto);
    }
}