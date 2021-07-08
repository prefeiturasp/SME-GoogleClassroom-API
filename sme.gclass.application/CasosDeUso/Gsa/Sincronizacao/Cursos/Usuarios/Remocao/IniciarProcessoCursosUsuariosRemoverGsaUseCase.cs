using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoCursosUsuariosRemoverGsaUseCase : IIniciarProcessoCursosUsuariosRemoverGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoCursosUsuariosRemoverGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            try
            {
                await LimparTabelasAsync();
                var dto = new CarregarTurmaRemoverCursoUsuarioDto();
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, dto));
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