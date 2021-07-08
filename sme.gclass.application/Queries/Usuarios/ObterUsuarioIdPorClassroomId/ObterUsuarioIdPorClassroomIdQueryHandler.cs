using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioIdPorClassroomIdQueryHandler : IRequestHandler<ObterUsuarioIdPorClassroomIdQuery, long>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuarioIdPorClassroomIdQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<long> Handle(ObterUsuarioIdPorClassroomIdQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterIndicePorGoogleClassroomId(request.GoogleClassroomId);
    }
}
