using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
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

        public async Task<bool> Executar(MensagemRabbit param)
        {
            var anoAtual = DateTime.Now.Year;
            var cursos = await mediator.Send(new ObterCursosPorAnoQuery(anoAtual));

            foreach (var curso in cursos)
            {
                try
                {
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesTratar, new FiltroCargaAtividadesCursoDto(curso)));
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            // TODO obter tipo da tarefa 42906 com o Bernard
            //await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.MuralAvisosCarregar));

            return true;
        }
    }
}
