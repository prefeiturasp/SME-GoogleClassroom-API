using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosParaIncluirGoogleUseCase : IObterFuncionariosIndiretosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosIndiretosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> Executar(FiltroObterFuncionariosIndiretosIncluirGoogleDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterFuncionariosIndiretosParaIncluirGoogleQuery(filtro.UltimaExecucao, paginacao, filtro.Cpf));
        }
    }
}