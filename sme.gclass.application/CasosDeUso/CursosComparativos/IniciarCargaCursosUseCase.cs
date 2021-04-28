using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarCargaCursosUseCase : IIniciarCargaCursosUseCase
    {
        private readonly IMediator mediator;

        public IniciarCargaCursosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar()
        {
            try
            {
                var dto = new FiltroCargaCursosGoogleDto();
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoCarregar, RotasRabbit.FilaCursoCarregar, dto));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }
    }
}
