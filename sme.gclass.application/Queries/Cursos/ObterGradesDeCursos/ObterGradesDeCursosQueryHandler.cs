using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Aluno.ObterGradesDeCursosDosAlunos
{
    public class ObterGradesDeCursosQueryHandler : IRequestHandler<ObterGradesDeCursosQuery, PaginacaoResultadoDto<GradeCursoEol>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterGradesDeCursosQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol;
        }

        public async Task<PaginacaoResultadoDto<GradeCursoEol>> Handle(ObterGradesDeCursosQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterGradesDeCursosAsync(request.UltimaDataExecucao, request.Paginacao, request.TurmaId, request.ComponenteCurricularId);
    }
}