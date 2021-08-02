using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosQueSeraoInativadosUseCase: AbstractUseCase, IObterFuncionariosQueSeraoInativadosUseCase
    {
        public ObterFuncionariosQueSeraoInativadosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<FuncionarioEol>> Executar(FiltroObterFuncionariosQueSeraoInativadosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterFuncionariosQueSeraoInativadosQuery(paginacao, filtro.DataReferencia));
        }
    }
}
