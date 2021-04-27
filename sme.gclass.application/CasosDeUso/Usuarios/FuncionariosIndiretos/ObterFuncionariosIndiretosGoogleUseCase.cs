using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosGoogleUseCase : IObterFuncionariosIndiretosGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosIndiretosGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoGoogle>> Executar(FiltroObterFuncionariosIndiretosCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterFuncionariosIndiretosGoogleQuery(paginacao, filtro.Cpf, filtro.Email));
        }
    }
}