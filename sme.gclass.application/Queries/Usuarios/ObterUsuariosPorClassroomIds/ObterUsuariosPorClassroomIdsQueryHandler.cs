using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorClassroomIdsQueryHandler : IRequestHandler<ObterUsuariosPorClassroomIdsQuery, IEnumerable<UsuarioGoogleDto>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuariosPorClassroomIdsQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<UsuarioGoogleDto>> Handle(ObterUsuariosPorClassroomIdsQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObteUsuariosPorClassroomIdsAsync(request.GoogleClassroomId);
    }
}
