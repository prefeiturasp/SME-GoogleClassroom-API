using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarSyncGsaUseCase : ITratarSyncGsaUseCase
    {
        private readonly IMediator mediator;

        public TratarSyncGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            await LimparTabelasAsync();

            var filtroCursoGsa = new FiltroCargaGsaDto();
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoCarregar, filtroCursoGsa));

            var filtroUsuarioGsa = new FiltroCargaGsaDto();
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCarregar, filtroUsuarioGsa));

            return true;
        }

        private async Task LimparTabelasAsync()
        {
            var command = new LimparTabelasGsaCommand
            {
                UsuariosGsa = true,
                CursosGsa = true
            };

            await mediator.Send(command);
        }
    }
}
