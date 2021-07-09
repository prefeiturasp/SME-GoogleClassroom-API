using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class LimparTabelasGsaCommandHandler : AsyncRequestHandler<LimparTabelasGsaCommand>
    {
        private readonly IRepositorioUsuarioGsa repositorioUsuarioGsa;
        private readonly IRepositorioCursoGsa repositorioCursoGsa;
        private readonly IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa;
        private readonly IRepositorioCursoUsuarioRemovidoGsa repositorioCursoUsuarioRemovidoGsa;

        public LimparTabelasGsaCommandHandler(IRepositorioUsuarioGsa repositorioUsuarioGsa, IRepositorioCursoGsa repositorioCursoGsa, IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa, IRepositorioCursoUsuarioRemovidoGsa repositorioCursoUsuarioRemovidoGsa)
        {
            this.repositorioUsuarioGsa = repositorioUsuarioGsa;
            this.repositorioCursoGsa = repositorioCursoGsa;
            this.repositorioUsuarioCursoGsa = repositorioUsuarioCursoGsa;
            this.repositorioCursoUsuarioRemovidoGsa = repositorioCursoUsuarioRemovidoGsa ?? throw new System.ArgumentNullException(nameof(repositorioCursoUsuarioRemovidoGsa));
        }

        protected override async Task Handle(LimparTabelasGsaCommand request, CancellationToken cancellationToken)
        {
            if (!request.UsuariosGsa && !request.CursosGsa)
                return;

            if (request.UsuariosGsa)
            {
                await repositorioUsuarioGsa.LimparAsync();
            }

            if (request.CursosGsa)
            {
                await repositorioCursoGsa.LimparAsync();
                await repositorioUsuarioCursoGsa.LimparAsync();
            }

            if (request.UsuariosCursosRemovidosGsa)
            {
                await repositorioCursoUsuarioRemovidoGsa.LimparAsync();
            }
        }
    }
}