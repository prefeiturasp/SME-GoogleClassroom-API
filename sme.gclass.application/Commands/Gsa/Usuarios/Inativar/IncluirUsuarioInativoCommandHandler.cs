using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioInativoCommandHandler : IRequestHandler<IncluirUsuarioInativoCommand, bool>
    {
        private readonly IRepositorioUsuarioInativo repositorio;

        public IncluirUsuarioInativoCommandHandler(IRepositorioUsuarioInativo repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<bool> Handle(IncluirUsuarioInativoCommand request, CancellationToken cancellationToken)
            => await repositorio.InativarUsuarioAsync(request.UsuarioInativo.UsuarioId, request.UsuarioInativo.UsuarioTipo, request.UsuarioInativo.InativadoEm);
    }
}
