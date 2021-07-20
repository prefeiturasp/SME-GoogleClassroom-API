using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarTurmaCursoUsuarioRemovidoUseCase : ITratarTurmaCursoUsuarioRemovidoUseCase
    {
        private readonly IMediator mediator;

        public TratarTurmaCursoUsuarioRemovidoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaRemoverCursoUsuarioDto>();

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, dto));

            return true;
        }
    }
}
