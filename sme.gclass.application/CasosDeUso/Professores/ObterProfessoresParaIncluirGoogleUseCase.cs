using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresParaIncluirGoogleUseCase : IObterProfessoresParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterProfessoresParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<ProfessorEol>> Executar(int registrosQuantidade, int paginaNumero, DateTime ultimaAtualizacao, string rf)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            return await mediator.Send(new ObterProfessoresParaIncluirGoogleQuery(ultimaAtualizacao, paginacao, rf));
        }
    }
}
