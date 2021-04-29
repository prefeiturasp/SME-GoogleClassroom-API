using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarCargaUsuariosUseCase : IIniciarCargaUsuariosUseCase
    {
        private readonly IMediator mediator;

        public IniciarCargaUsuariosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar()
        {
            try
            {
                var dto = new FiltroCargaComparativoUsuariosGoogleDto();
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaComparativoUsuarioCarregar, RotasRabbit.FilaComparativoUsuarioCarregar, dto));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }
    }
}
