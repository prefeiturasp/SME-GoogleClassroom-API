using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorIdsQueryHandler : IRequestHandler<ObterUsuariosPorIdsQuery, IEnumerable<UsuarioGsaDto>>
    {
        private readonly IRepositorioUsuarioGsa repositorioUsuarioGsa;

        public ObterUsuariosPorIdsQueryHandler(IRepositorioUsuarioGsa repositorioUsuarioGsa)
        {
            this.repositorioUsuarioGsa = repositorioUsuarioGsa ?? throw new ArgumentNullException(nameof(repositorioUsuarioGsa));
        }

        public async Task<IEnumerable<UsuarioGsaDto>> Handle(ObterUsuariosPorIdsQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuarioGsa.ObterUsuarioPorIds(request.Ids);
        }
    }
}