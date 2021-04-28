using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCadastradosUseCase : IObterAlunosCadastradosUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosCadastradosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AlunoGoogle>> Executar(FiltroObterAlunosCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterAlunosCadastradosQuery(paginacao, filtro.CodigoEol, filtro.Email));
        }
    }
}