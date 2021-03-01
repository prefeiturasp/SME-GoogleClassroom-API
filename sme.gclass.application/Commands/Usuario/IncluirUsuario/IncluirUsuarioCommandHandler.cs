using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCommandHandler : IRequestHandler<IncluirUsuarioCommand, long>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public IncluirUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<long> Handle(IncluirUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.SalvarAsync(request.Id, request.Email, request.Tipo, request.OrganizationPath, request.DataInclusao, request.DataAtualizacao);
    }
}