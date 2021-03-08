using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoProfessorParaIncluirGoogleQueryHandler : IRequestHandler<ObterCursosDoProfessorParaIncluirGoogleQuery, IEnumerable<ProfessorCursoEol>>
    {
        private readonly IRepositorioProfessorEol repositorioProfessorEol;

        public ObterCursosDoProfessorParaIncluirGoogleQueryHandler(IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioProfessorEol = repositorioProfessorEol;
        }

        public async Task<IEnumerable<ProfessorCursoEol>> Handle(ObterCursosDoProfessorParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioProfessorEol.ObterCursosDoProfessorParaInclusaoAsync(request.Rf, request.AnoLetivo);
    }
}