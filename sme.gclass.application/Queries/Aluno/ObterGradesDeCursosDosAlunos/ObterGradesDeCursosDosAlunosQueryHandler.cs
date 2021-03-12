using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Aluno.ObterGradesDeCursosDosAlunos
{
    public class ObterGradesDeCursosDosAlunosQueryHandler : IRequestHandler<ObterGradesDeCursosDosAlunosQuery, PaginacaoResultadoDto<GradeAlunoCursoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterGradesDeCursosDosAlunosQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol;
        }

        public async Task<PaginacaoResultadoDto<GradeAlunoCursoEol>> Handle(ObterGradesDeCursosDosAlunosQuery request, CancellationToken cancellationToken)
            => await repositorioAlunoEol.ObterGradesDeCursosDosAlunosAsync(request.UltimaDataExecucao, request.Paginacao, request.CodigoAluno, request.TurmaId, request.ComponenteCurricularId);
    }
}