using MediatR;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase : IIniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase
    {
        private readonly IMediator mediator;

        public IniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(string codigoDre, int? componenteCurricularId)
        {
            var dto = new FiltroFormacaoCidadeTurmasDto(codigoDre, componenteCurricularId);
            return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarDre, dto));
        }
    }
}
