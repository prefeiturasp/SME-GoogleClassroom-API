using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterProfessoresInativosPorAnoLetivoQueryHandler : IRequestHandler<ObterProfessoresInativosPorAnoLetivoQuery, IEnumerable<string>>
    {
        private readonly IRepositorioProfessorEol repositorioProfessorEol;

        public ObterProfessoresInativosPorAnoLetivoQueryHandler(IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioProfessorEol = repositorioProfessorEol ?? throw new ArgumentNullException(nameof(repositorioProfessorEol));
        }

        public async Task<IEnumerable<string>> Handle(ObterProfessoresInativosPorAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProfessorEol.ObterCodigosProfessoresInativosPorAnoLetivo(request.AnoLetivo, request.DataReferencia, request.Rf);
        }
    }
}
