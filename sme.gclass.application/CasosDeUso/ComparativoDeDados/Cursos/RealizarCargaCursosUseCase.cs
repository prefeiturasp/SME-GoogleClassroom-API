﻿using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaCursosUseCase : IRealizarCargaCursosUseCase
    {
        protected readonly IMediator mediator;

        public RealizarCargaCursosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a atualização de cursos para comparativo.");

            var dto = mensagemRabbit?.ObterObjetoMensagem<FiltroCargaCursosGoogleDto>();

            var resultado = await mediator.Send(new ObterCursosComparativosQuery(dto?.NextToken));
            foreach (var curso in resultado.Cursos)
            {
                try
                {
                    var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoComparativoAtualizar, RotasRabbit.FilaCursoComparativoAtualizar, curso));
                    if (!publicarCurso) continue;
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            dto.NextToken = resultado.NextToken;
            if (!string.IsNullOrEmpty(dto.NextToken))
                await PublicaProximaPaginaAsync(dto);

            return true;
        }

        private async Task PublicaProximaPaginaAsync(FiltroCargaCursosGoogleDto dto)
        {
            try
            {
                var syncCursoComparativo = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoCarregar, RotasRabbit.FilaCursoCarregar, dto));
                if (!syncCursoComparativo)
                    SentrySdk.CaptureMessage("Não foi possível sincronizar os cursos para comparativo");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}