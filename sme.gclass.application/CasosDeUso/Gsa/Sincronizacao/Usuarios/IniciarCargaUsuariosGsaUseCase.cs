using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarCargaUsuariosGsaUseCase : IIniciarCargaUsuariosGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarCargaUsuariosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar()
        {
            try
            {
                await LimparTabelasAsync();

                var dto = new FiltroCargaGsaDto();
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCarregar, RotasRabbit.FilaGsaUsuarioCarregar, dto));
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"IniciarCargaUsuariosGsaUseCase", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));
                return false;
            }
        }

        private async Task LimparTabelasAsync()
        {
            var command = new LimparTabelasGsaCommand
            {
                UsuariosGsa = true
            };

            await mediator.Send(command);
        }
    }
}
