using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverUsuarioCursoGsaCommandHandler : IRequestHandler<RemoverUsuarioCursoGsaCommand, bool>
    {
        private readonly IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa;

        public RemoverUsuarioCursoGsaCommandHandler(IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa)
        {
            this.repositorioUsuarioCursoGsa = repositorioUsuarioCursoGsa;
        }

        public async Task<bool> Handle(RemoverUsuarioCursoGsaCommand request, CancellationToken cancellationToken)
            => await repositorioUsuarioCursoGsa.RemoverAsync(request.UsuarioCursoGsa);
    }
}