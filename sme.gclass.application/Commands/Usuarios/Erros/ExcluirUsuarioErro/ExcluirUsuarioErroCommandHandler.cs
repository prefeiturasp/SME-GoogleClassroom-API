using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.Erros.ExcluirUsuarioErro
{
    public class ExcluirUsuarioErroCommandHandler : IRequestHandler<ExcluirUsuarioErroCommand, bool>
    {
        private readonly IRepositorioUsuarioErro repositorioUsuarioErro;

        public ExcluirUsuarioErroCommandHandler(IRepositorioUsuarioErro repositorioUsuarioErro)
        {
            this.repositorioUsuarioErro = repositorioUsuarioErro;
        }

        public async Task<bool> Handle(ExcluirUsuarioErroCommand request, CancellationToken cancellationToken)
            => await repositorioUsuarioErro.ExcluirAsync(request.UsuarioErroId) > 0;
    }
}