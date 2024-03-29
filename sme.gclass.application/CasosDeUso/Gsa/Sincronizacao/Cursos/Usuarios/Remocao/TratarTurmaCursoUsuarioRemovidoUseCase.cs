﻿using MediatR;
using SME.GoogleClassroom.Infra;
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

            if (dto.ProcessarAlunos)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, dto));
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosCelpTratar, dto));
            }

            if (dto.ProcessarProfessores)
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar, dto));
            
            if (dto.ProcessarFuncionario)
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar, dto));

            return true;
        }
    }
}
