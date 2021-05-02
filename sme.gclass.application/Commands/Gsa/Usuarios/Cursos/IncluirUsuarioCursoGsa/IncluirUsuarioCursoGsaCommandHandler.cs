using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCursoGsaCommandHandler : IRequestHandler<IncluirUsuarioCursoGsaCommand, bool>
    {
        private readonly IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa;

        public IncluirUsuarioCursoGsaCommandHandler(IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa)
        {
            this.repositorioUsuarioCursoGsa = repositorioUsuarioCursoGsa;
        }

        public async Task<bool> Handle(IncluirUsuarioCursoGsaCommand request, CancellationToken cancellationToken)
            => await repositorioUsuarioCursoGsa.SalvarAsync(request.UsuarioCursoGsa);
    }
}