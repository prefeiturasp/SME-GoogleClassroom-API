using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosGoogleUseCase : IObterFuncionariosGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioGoogle>> Executar(FiltroObterFuncionariosCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterFuncionariosGoogleQuery(paginacao, filtro.Rf, filtro.Email));
        }
    }
}
