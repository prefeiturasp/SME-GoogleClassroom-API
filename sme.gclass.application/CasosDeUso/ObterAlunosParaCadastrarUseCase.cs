using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
        public async Task<PaginacaoResultadoDto<AlunoEol>> Executar(int registrosQuantidade, int paginaNumero, DateTime dataReferencia, long codigoEol)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            return await mediator.Send(new ObterAlunosNovosQuery(paginacao, dataReferencia, codigoEol));
        }
    }
}
