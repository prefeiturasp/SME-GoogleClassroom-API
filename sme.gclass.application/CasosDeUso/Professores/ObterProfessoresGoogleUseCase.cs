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

        public async Task<PaginacaoResultadoDto<ProfessorGoogle>> Executar(FiltroObterProfessoresCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterProfessoresGoogleQuery(paginacao, filtro.Rf, filtro.Email));
        }
    }
}
