using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGooglePorCodigosQueryHandler : IRequestHandler<ObterUsuariosGooglePorCodigosQuery, UsuarioGoogleDto>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuariosGooglePorCodigosQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<UsuarioGoogleDto> Handle(ObterUsuariosGooglePorCodigosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ObterUsuariosGooglePorCodigos(request.UsuarioCodigo);
        }
    }
}
