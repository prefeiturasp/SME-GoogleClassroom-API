﻿using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleGeralUseCase : ITrataSyncGoogleGeralUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleGeralUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var resposta = mensagemRabbit.Mensagem;

            var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoSync, RotasRabbit.FilaCursoSync, resposta));

            if (publicarCurso)
                throw new NegocioException("Erro ao enviar o curso");

            return await Task.FromResult(true);
        }
    }
}
