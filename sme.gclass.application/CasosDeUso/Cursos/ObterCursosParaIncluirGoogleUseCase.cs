using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaIncluirGoogleUseCase : IObterCursosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<PaginacaoResultadoDto<CursoParaInclusaoDto>> Executar(FiltroObterCursosIncluirGoogleDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterCursosIncluirGoogleQuery(filtro.UltimaExecucao, paginacao, filtro.ComponenteCurricularId, filtro.TurmaId));
        }
    }
}
