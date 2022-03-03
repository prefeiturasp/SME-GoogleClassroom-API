using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorCodigosQueryHandler : IRequestHandler<ObterUsuariosPorCodigosQuery, IEnumerable<UsuarioGsaDto>>
    {
        private readonly IRepositorioUsuarioGsa repositorioUsuarioGsa;

        public ObterUsuariosPorCodigosQueryHandler(IRepositorioUsuarioGsa repositorioUsuario)
        {
            this.repositorioUsuarioGsa = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<UsuarioGsaDto>> Handle(ObterUsuariosPorCodigosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuarioGsa.ObterUsuariosPorCodigos(request.UsuarioCodigo, request.UsuarioTipo);
        }
    }
}
