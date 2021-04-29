using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarValidarUsuariosExistentesUsuariosComparativosUseCase : IIniciarValidarUsuariosExistentesUsuariosComparativosUseCase
    {
        private readonly IMediator mediator;

        public IniciarValidarUsuariosExistentesUsuariosComparativosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar()
        {
            try
            {
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaComparativosUsuariosValidar, RotasRabbit.FilaComparativosUsuariosValidar, true));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }
    }
}
