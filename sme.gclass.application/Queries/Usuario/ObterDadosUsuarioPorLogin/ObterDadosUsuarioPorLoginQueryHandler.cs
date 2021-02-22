using MediatR;
using SME.GoogleClassrom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDadosUsuarioPorLoginQueryHandler : IRequestHandler<ObterDadosUsuarioPorLoginQuery, UsuarioDto>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterDadosUsuarioPorLoginQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<UsuarioDto> Handle(ObterDadosUsuarioPorLoginQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.BuscarRfEmailAsync(request.Login);
        }

    }
}
