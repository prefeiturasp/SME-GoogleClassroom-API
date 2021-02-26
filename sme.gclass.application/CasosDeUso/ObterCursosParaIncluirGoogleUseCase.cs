using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
        public async Task<PaginacaoResultadoDto<CursoParaInclusaoDto>> Executar(int registrosQuantidade, int paginaNumero, DateTime ultimaAtualizacao)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);

            return await mediator.Send(new ObterCursosIncluirGoogleQuery(ultimaAtualizacao, paginacao));
        }
    }
}
