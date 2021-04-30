using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGsaUseCase : IObterUsuariosGsaUseCase
    {
        private readonly IMediator mediator;

        public ObterUsuariosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<UsuarioGsa>> Executar(FiltroObterUsuariosGsaDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterUsuariosGsaPaginadosQuery(paginacao, filtro.Email, filtro.Nome, filtro.OrganizationPath));
        }
    }
}
