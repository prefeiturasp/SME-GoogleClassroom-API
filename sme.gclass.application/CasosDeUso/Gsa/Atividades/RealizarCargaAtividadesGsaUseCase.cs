using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<bool> Executar(MensagemRabbit mensage)
        {
            var filtro = mensage.ObterObjetoMensagem<FiltroCargaAtividadesCursoDto>();

            var anoAtual = DateTime.Now.Year;
            var cursos = await mediator.Send(new ObterCursosPorAnoQuery(anoAtual, filtro.CursoId));
            var ultimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AtividadesCarregar));

            foreach (var curso in cursos)
            {
                try
                {
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesTratar, new FiltroTratarAtividadesCursoDto(curso, ultimaExecucao)));
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AtividadesCarregar));
            return true;
        }
    }
}
