using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarSyncGoogleComparativoDadosUseCase : ITratarSyncGoogleComparativoDadosUseCase
    {
        private readonly IMediator mediator;

        public TratarSyncGoogleComparativoDadosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var mensagem = mensagemRabbit.Mensagem;

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaUsuariosCarregar));

            return true;
        }
    }
}
