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

        public async Task<bool> Executar(bool executarCargaDeUsuariosGsa)
        {
            try
            {
                await LimparTabelasAsync(executarCargaDeUsuariosGsa);

                var dto = new FiltroCagaCursosGsaDto(null, executarCargaDeUsuariosGsa);
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoCarregar, RotasRabbit.FilaGsaCursoCarregar, dto));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }

        private async Task LimparTabelasAsync(bool executarCargaDeUsuariosGsa)
        {
            var command = new LimparTabelasGsaCommand
            {
                UsuariosGsa = executarCargaDeUsuariosGsa,
                CursosGsa = true
            };

            await mediator.Send(command);
        }
    }
}
