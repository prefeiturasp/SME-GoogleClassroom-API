using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoPorTurmaComponenteCurricularQueryHandler : IRequestHandler<ObterCursoPorTurmaComponenteCurricularQuery, Curso>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterCursoPorTurmaComponenteCurricularQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<Curso> Handle(ObterCursoPorTurmaComponenteCurricularQuery request, CancellationToken cancellationToken)
        {
            var curso = await repositorioCurso.ObterCursoPorTurmaComponenteCurricular(request.TurmaId, request.ComponenteCurricularId);

            return curso;
        }
    }
}
