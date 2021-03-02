using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresGoogleUseCase : IObterProfessoresGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterProfessoresGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<ProfessorGoogle>> Executar(int registrosQuantidade, int paginaNumero)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            return await mediator.Send(new ObterProfessoresGoogleQuery(paginacao));
        }
    }
}
