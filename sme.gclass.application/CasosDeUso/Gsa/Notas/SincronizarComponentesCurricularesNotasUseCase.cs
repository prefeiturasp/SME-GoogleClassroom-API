﻿using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarComponentesCurricularesNotasUseCase : AbstractUseCase, ISincronizarComponentesCurricularesNotasUseCase
    {
        public SincronizarComponentesCurricularesNotasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.ObterObjetoMensagem<FiltroComponenteCurricularAtividadeDto>();
            var dataInicioAno = new DateTime(DateTime.Now.Year, 1, 1);

            if (filtro != null)
            {
                var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
                var atividadesPaginadas = await mediator.Send(new ObterAtividadesPorComponenteCurricularEAnoLetivoQuery(filtro.ComponenteCurricularId, dataInicioAno, paginacao));
                foreach(var atividade in atividadesPaginadas.Items)
                {
                    var dadosAtividades = new DadosAvaliacaoNotasGsaDto(atividade.TurmaId, filtro.ComponenteCurricularId, atividade.CursoId, atividade.Id, atividade.DataInclusao,
                        atividade.DataEntrega, filtro.LancaNota, atividade.NotaMaxima, filtro.TotalDiasImportacao, atividade.Titulo);
                    var notas = await mediator.Send(new ObterNotasGooglePorAtividadeQuery(dadosAtividades));
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasProcessar, notas));
                    if (atividadesPaginadas.TotalPaginas <= filtro.PaginaNumero)
                    {
                        var componenteFiltro = new FiltroComponenteCurricularAtividadeDto(filtro.ComponenteCurricularId, filtro.LancaNota, filtro.TotalDiasImportacao, filtro.PaginaNumero++, filtro.RegistrosQuantidade);
                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesSync, componenteFiltro));
                    }
                }
            }
            return true;
        }
    }
}