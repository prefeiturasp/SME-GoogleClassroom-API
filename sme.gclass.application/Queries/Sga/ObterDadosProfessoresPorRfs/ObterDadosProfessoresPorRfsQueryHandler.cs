using Google.Apis.Http;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra.Dtos.Sga;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterDadosProfessoresPorRfs
{
    public class ObterDadosProfessoresPorRfsQueryHandler : IRequestHandler<ObterDadosProfessoresPorRfsQuery, IEnumerable<DadosProfessorEolSgaDto>>
    {
        private readonly IRepositorioProfessorEol repositorio;

        public ObterDadosProfessoresPorRfsQueryHandler(IRepositorioProfessorEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<DadosProfessorEolSgaDto>> Handle(ObterDadosProfessoresPorRfsQuery request, CancellationToken cancellationToken)
        {
            return await repositorio.ObterDadosDoProfessorPorRfs(request.Rfs);
        }
    }
}
