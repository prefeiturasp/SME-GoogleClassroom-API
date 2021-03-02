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
        public async Task<PaginacaoResultadoDto<AlunoGoogle>> Executar(int registrosQuantidade, int paginaNumero, long? codigoEol, string email)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);

            return await mediator.Send(new ObterAlunosCadastradosQuery(paginacao, codigoEol, email));
        }
    }
}