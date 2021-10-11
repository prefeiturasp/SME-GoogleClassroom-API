using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.ObterObjetoMensagem<FiltroCargaAtividadesCursoDto>();

            var anoAtual = DateTime.Now.Year;
            var cursos = await mediator.Send(new ObterCursosPorAnoQuery(anoAtual, filtro.CursoId));
            var ultimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AtividadesCarregar));

            foreach (var curso in cursos)
            {
                try
                {
                    var atividadesCurso = await mediator.Send(new ObterAtividadesDoCursoGoogleQuery(curso));

                    if (atividadesCurso.Atividades.Any())
                        await mediator.Send(new TratarImportacaoAtividadesCommand(atividadesCurso.Atividades, curso.CursoId, ultimaExecucao));
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
