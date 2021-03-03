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

        public async Task<PaginacaoResultadoDto<FuncionarioGoogle>> Executar(int registrosQuantidade, int paginaNumero, long? rf, string email)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            return await mediator.Send(new ObterFuncionariosGoogleQuery(paginacao, rf, email));
        }
    }
}
