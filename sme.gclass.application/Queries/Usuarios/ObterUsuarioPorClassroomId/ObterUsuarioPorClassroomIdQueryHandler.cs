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
    public class ObterUsuarioPorClassroomIdQueryHandler : IRequestHandler<ObterUsuarioPorClassroomIdQuery, UsuarioGoogleDto>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuarioPorClassroomIdQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<UsuarioGoogleDto> Handle(ObterUsuarioPorClassroomIdQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObteUsuarioPorClassroomId(request.GoogleClassroomId);
    }
}
