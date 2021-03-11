using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteAlunoCursoGoogleQueryHandler : IRequestHandler<ExisteAlunoCursoGoogleQuery, bool>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ExisteAlunoCursoGoogleQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<bool> Handle(ExisteAlunoCursoGoogleQuery request, CancellationToken cancellationToken)
        {
            var existe = await repositorioCursoUsuario.ExisteAlunoCurso(request.UsusarioId, request.CursoId);
            return existe;
        }
    }
}
