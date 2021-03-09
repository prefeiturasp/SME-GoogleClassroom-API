using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteProfessorCursoGoogleQueryHandler : IRequestHandler<ExisteProfessorCursoGoogleQuery, bool>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ExisteProfessorCursoGoogleQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<bool> Handle(ExisteProfessorCursoGoogleQuery request, CancellationToken cancellationToken)
        {
            var existe = await repositorioCursoUsuario.ExisteProfessorCurso(request.UsusarioId, request.CursoId);
            return existe;
        }
    }
}
