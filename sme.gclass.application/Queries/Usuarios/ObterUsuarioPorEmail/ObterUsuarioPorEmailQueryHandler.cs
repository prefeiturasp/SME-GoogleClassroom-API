using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioPorEmailQueryHandler : IRequestHandler<ObterUsuarioPorEmailQuery, UsuarioGoogleDto>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuarioPorEmailQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<UsuarioGoogleDto> Handle(ObterUsuarioPorEmailQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterUsuarioPorEmail(request.Email);
    }
}
