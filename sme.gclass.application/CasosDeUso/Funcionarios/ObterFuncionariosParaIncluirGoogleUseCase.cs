using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaIncluirGoogleUseCase : IObterFuncionariosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioEol>> Executar(int registrosQuantidade, int paginaNumero, DateTime ultimaAtualizacao, string rf)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            return await mediator.Send(new ObterFuncionariosParaIncluirGoogleQuery(ultimaAtualizacao, paginacao, rf));
        }
    }
}