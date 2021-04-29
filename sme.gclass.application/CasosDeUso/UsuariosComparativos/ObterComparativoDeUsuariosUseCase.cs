using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterComparativoDeUsuariosUseCase : IObterComparativoDeUsuariosUseCase
    {
        private readonly IMediator mediator;

        public ObterComparativoDeUsuariosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<UsuarioComparativo>> Executar(FiltroObterComparativoUsuarioDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterUsuariosComparativosPaginadosQuery(paginacao, filtro.Email, filtro.Nome, filtro.OrganizationPath));
        }
    }
}
