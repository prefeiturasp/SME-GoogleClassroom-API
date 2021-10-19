using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaAtividadesGsaUseCase : IRealizarCargaAtividadesGsaUseCase
    {
        private readonly int quantidadeRegistrosBloco = 100;
        private readonly IMediator mediator;

        public RealizarCargaAtividadesGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.ObterObjetoMensagem<FiltroCargaAtividadesCursoDto>();

            var anoAtual = DateTime.Now.Year;

            var cursos = mediator
                .Send(new ObterCursosPorAnoQuery(anoAtual, filtro.CursoId)).Result.ToList();

            var ultimaExecucao = await mediator
                .Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AtividadesCarregar));

            for (int i = 0; i < cursos.TotalBlocos(quantidadeRegistrosBloco); i++)
            {
                try
                {
                    await mediator
                        .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesTratar, new FiltroTratarAtividadesCursoDto(cursos.ObterBloco(i, quantidadeRegistrosBloco), ultimaExecucao)));
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                }
                
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AtividadesCarregar));
            return true;
        }
    }
}
