using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverCursoUsuarioCommandHandler : IRequestHandler<RemoverCursoUsuarioCommand, bool>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public RemoverCursoUsuarioCommandHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario;
        }

        public async Task<bool> Handle(RemoverCursoUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorioCursoUsuario.RemoverAsync(request.CursoUsuarioId) > 0;
    }
}