using MediatR;
using SME.GoogleClassroom.Infra;
using System;
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

        public async Task<bool> Executar(string codigoDre, int? componenteCurricularId, int? anoLetivo)
        {
            if (!anoLetivo.HasValue)
                anoLetivo = DateTime.Now.Year;

            var dto = new FiltroFormacaoCidadeTurmaDto(anoLetivo.Value, codigoDre, componenteCurricularId);
            return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarDre, dto));
        }
    }
}
