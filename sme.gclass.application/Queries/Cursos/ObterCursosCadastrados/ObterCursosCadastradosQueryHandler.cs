using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQueryHandler : IRequestHandler<ObterCursosCadastradosQuery, PaginacaoResultadoDto<CursoGoogleDto>>
    {
        private readonly IRepositorioCurso repositorioCursos;

        public ObterCursosCadastradosQueryHandler(IRepositorioCurso repositorioCursos)
        {
            this.repositorioCursos = repositorioCursos ?? throw new System.ArgumentNullException(nameof(repositorioCursos));
        }

        public async Task<PaginacaoResultadoDto<CursoGoogleDto>> Handle(ObterCursosCadastradosQuery request, CancellationToken cancellationToken)
            => await repositorioCursos.ObterTodosCursosAsync(request.Paginacao, request.TurmaId, request.ComponenteCurricularId, request.CursoId, request.EmailCriador);
    }
}