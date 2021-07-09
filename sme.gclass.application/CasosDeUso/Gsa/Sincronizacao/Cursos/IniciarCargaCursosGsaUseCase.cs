using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarCargaCursosGsaUseCase : IIniciarCargaCursosGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarCargaCursosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            try
            {
                await LimparTabelasAsync();

                var dto = new FiltroCargaGsaDto();
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoCarregar, RotasRabbit.FilaGsaCursoCarregar, dto));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }

        private async Task LimparTabelasAsync()
        {
            var command = new LimparTabelasGsaCommand
            {
                CursosGsa = true
            };

            await mediator.Send(command);
        }
    }
}
