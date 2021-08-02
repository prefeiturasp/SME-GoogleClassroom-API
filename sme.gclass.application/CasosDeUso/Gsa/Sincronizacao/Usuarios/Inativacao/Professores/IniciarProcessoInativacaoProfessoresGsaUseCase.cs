using MediatR;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoInativacaoProfessoresGsaUseCase : IIniciarProcessoInativacaoProfessoresGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoInativacaoProfessoresGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(string rf)
        {
            var dto = new FiltroInativacaoProfessoresGoogleDto(rf);
            return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarProfessorCarregar, dto));
        }
    }
}
