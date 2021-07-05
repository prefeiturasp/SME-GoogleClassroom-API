using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoInativacaoUsuariosCursosGsaUseCase : IIniciarProcessoInativacaoUsuariosCursosGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoInativacaoUsuariosCursosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            try
            {
                await LimparTabelasAsync();

                var dto = new FiltroUsuariosCursosGoogleDto();
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativacaoUsuarioCurso, RotasRabbit.FilaGsaInativacaoUsuarioCurso, dto));
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
                UsuariosCursosRemovidosGsa = true
            };

            await mediator.Send(command);
        }
    }
}