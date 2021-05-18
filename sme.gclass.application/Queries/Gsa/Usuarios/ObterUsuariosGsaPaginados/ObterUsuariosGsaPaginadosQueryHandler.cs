using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGsaPaginadosQueryHandler : IRequestHandler<ObterUsuariosGsaPaginadosQuery, PaginacaoResultadoDto<UsuarioGsa>>
    {
        private readonly IRepositorioUsuarioGsa repositorioUsuarioComparativo;

        public ObterUsuariosGsaPaginadosQueryHandler(IRepositorioUsuarioGsa repositorioUsuarioComparativo)
        {
            this.repositorioUsuarioComparativo = repositorioUsuarioComparativo ?? throw new System.ArgumentNullException(nameof(repositorioUsuarioComparativo));
        }
        public async Task<PaginacaoResultadoDto<UsuarioGsa>> Handle(ObterUsuariosGsaPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuarioComparativo.ObterUsuariosComparativosAsync(request.Paginacao, request.Nome, request.Email, request.OrganizationPath);
        }
    }
}
