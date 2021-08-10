using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresParaIncluirGoogleQueryHandler : IRequestHandler<ObterProfessoresParaIncluirGoogleQuery, PaginacaoResultadoDto<ProfessorEol>>
    {
        private readonly IRepositorioProfessorEol repositorioProfessorEol;

        public ObterProfessoresParaIncluirGoogleQueryHandler(IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioProfessorEol = repositorioProfessorEol ?? throw new ArgumentNullException(nameof(repositorioProfessorEol));
        }

        public async Task<PaginacaoResultadoDto<ProfessorEol>> Handle(ObterProfessoresParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioProfessorEol.ObterProfessoresParaInclusaoAsync(request.UltimaDataExecucao, request.Paginacao, request.Rf, request.ParametrosCargaInicialDto);
    }
}
