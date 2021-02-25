using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQueryHandler : IRequestHandler<ObterCursosCadastradosQuery, IEnumerable<Curso>>
    {
        private readonly IRepositorioCurso repositorioCursos;

        public ObterCursosCadastradosQueryHandler(IRepositorioCurso repositorioCursos)
        {
            this.repositorioCursos = repositorioCursos ?? throw new System.ArgumentNullException(nameof(repositorioCursos));
        }
        public async Task<IEnumerable<Curso>> Handle(ObterCursosCadastradosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursos.ObterTodosCursos(request.paginacacao);
        }
    }
}
