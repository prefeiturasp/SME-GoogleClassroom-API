using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosQueSeraoInativadosUseCase : AbstractUseCase, IObterFuncionariosIndiretosQueSeraoInativadosUseCase
    {
        public ObterFuncionariosIndiretosQueSeraoInativadosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> Executar(FiltroObterFuncionariosIndiretosQueSeraoInativadosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQuery(paginacao, filtro.Cpf));
        }
    }
}
