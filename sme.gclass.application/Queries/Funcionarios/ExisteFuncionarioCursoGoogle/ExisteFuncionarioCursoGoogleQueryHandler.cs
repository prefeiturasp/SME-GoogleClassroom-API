using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteFuncionarioCursoGoogleQueryHandler : IRequestHandler<ExisteFuncionarioCursoGoogleQuery, bool>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ExisteFuncionarioCursoGoogleQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<bool> Handle(ExisteFuncionarioCursoGoogleQuery request, CancellationToken cancellationToken)
        {
            var existe = await repositorioCursoUsuario.ExisteFuncionarioCurso(request.UsusarioId, request.CursoId);
            return existe;
        }
    }
}
