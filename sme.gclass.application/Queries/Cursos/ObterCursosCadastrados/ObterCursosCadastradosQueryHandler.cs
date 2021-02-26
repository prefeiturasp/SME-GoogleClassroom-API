using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQueryHandler : IRequestHandler<ObterCursosCadastradosQuery, PaginacaoResultadoDto<Curso>>
    {
        private readonly IRepositorioCurso repositorioCursos;

        public ObterCursosCadastradosQueryHandler(IRepositorioCurso repositorioCursos)
        {
            this.repositorioCursos = repositorioCursos ?? throw new System.ArgumentNullException(nameof(repositorioCursos));
        }
        public async Task<PaginacaoResultadoDto<Curso>> Handle(ObterCursosCadastradosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursos.ObterTodosCursosAsync(request.Paginacacao);
        }
    }
}
