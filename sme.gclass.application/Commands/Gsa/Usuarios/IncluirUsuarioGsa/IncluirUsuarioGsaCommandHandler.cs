using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioGsaCommandHandler : IRequestHandler<IncluirUsuarioGsaCommand, bool>
    {
        private readonly IRepositorioUsuarioGsa repositorio;

        public IncluirUsuarioGsaCommandHandler(IRepositorioUsuarioGsa repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<bool> Handle(IncluirUsuarioGsaCommand request, CancellationToken cancellationToken) 
            => await repositorio.SalvarAsync(request.UsuarioGsa);
    }
}