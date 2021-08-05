using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Professores.ObterAtribuicoesDeCursosDoProfessor
{
    public class ObterAtribuicoesDeCursosDosProfessoresQueryHandler : IRequestHandler<ObterAtribuicoesDeCursosDosProfessoresQuery, PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>>
    {
        private readonly IRepositorioProfessorEol repositorioProfessorEol;

        public ObterAtribuicoesDeCursosDosProfessoresQueryHandler(IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioProfessorEol = repositorioProfessorEol;
        }

        public async Task<PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>> Handle(ObterAtribuicoesDeCursosDosProfessoresQuery request, CancellationToken cancellationToken)
            => await repositorioProfessorEol.ObterAtribuicoesDeCursosDoProfessorAsync(request.UltimaDataExecucao, request.Paginacao, request.Rf, request.TurmaId, request.ComponenteCurricularId, request.parametrosCargaInicialDto);
    }
}