using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosGsaUseCase : IObterCursosGsaUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<CursoComparativoDto>> Executar(FiltroObterComparativoCursoDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterCursosComparativosPaginadosQuery(paginacao, filtro.Secao, filtro.Descricao, filtro.Nome));
        }
    }
}
