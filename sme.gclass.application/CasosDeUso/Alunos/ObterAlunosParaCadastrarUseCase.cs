using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosParaCadastrarUseCase : IObterAlunosParaCadastrarUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosParaCadastrarUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Executar(FiltroObterAlunosIncluirGoogleDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterAlunosNovosQuery(paginacao, filtro.UltimaExecucao, filtro.CodigoEol));
        }
    }
}