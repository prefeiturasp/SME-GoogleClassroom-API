﻿using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaAtividadesGsaUseCase : IRealizarCargaAtividadesGsaUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaAtividadesGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.ObterObjetoMensagem<FiltroCargaAtividadesCursoDto>();

            var anoAtual = DateTime.Now.Year;

            var ultimaExecucao = await mediator
                .Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AtividadesCarregar));

            if (!filtro.CursoId.HasValue && ultimaExecucao.Date.Equals(DateTime.Today.Date))
                return true;

            filtro.Pagina = filtro.Pagina ?? 1;

            var retorno = await mediator
                .Send(new ObterCursosPorAnoQuery(anoAtual, filtro.CursoId, filtro.Pagina, 100));

            var totalPaginas = retorno.totalPaginas ?? filtro.TotalPaginas;

            Console.WriteLine($">>> Carga Atividades - Página: {filtro.Pagina}/{totalPaginas}");

            try
            {
                await PublicarMensagemTratar(ultimaExecucao, retorno);

                if (filtro.Pagina > totalPaginas)
                    await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AtividadesCarregar));
                else
                    await PublicarMensagemProximaPagina(filtro.Pagina.Value + 1, totalPaginas.Value);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }

            return true;
        }

        private async Task PublicarMensagemTratar(DateTime ultimaExecucao, (IEnumerable<CursoDto> cursos, int? totalPaginas) retorno)
        {
            await mediator
                .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesTratar, new FiltroTratarAtividadesCursoDto(retorno.cursos, ultimaExecucao)));
        }

        private async Task PublicarMensagemProximaPagina(int proximaPagina, int totalPaginas)
        {
            var filtro = new FiltroCargaAtividadesCursoDto(pagina: proximaPagina, totalPaginas: totalPaginas);

            await mediator
                .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesCarregar, filtro));
        }
    }
}
