using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosQueSeraoInativadosUseCase : AbstractUseCase, IObterAlunosQueSeraoInativadosUseCase
    {
        public ObterAlunosQueSeraoInativadosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Executar(FiltroObterAlunosQueSeraoInativadosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterAlunosQueSeraoInativadosPorAnoLetivoQuery(paginacao, filtro.AnoLetivo, filtro.DataReferencia));
        }
    }

}