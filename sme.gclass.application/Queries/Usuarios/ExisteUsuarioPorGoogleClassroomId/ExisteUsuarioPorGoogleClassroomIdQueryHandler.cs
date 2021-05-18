using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteUsuarioPorGoogleClassroomIdQueryHandler : IRequestHandler<ExisteUsuarioPorGoogleClassroomIdQuery, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteUsuarioPorGoogleClassroomIdQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<bool> Handle(ExisteUsuarioPorGoogleClassroomIdQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ExisteUsuarioPorGoogleClassroomIdAsync(request.GoogleClassroomId);
    }
}