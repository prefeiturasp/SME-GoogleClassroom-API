using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleCursoUseCase : ITrataSyncGoogleCursoUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var ultimaExecucaoCursosIncluir = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.CursoAdicionar));

                if (ultimaExecucaoCursosIncluir == null)
                    throw new NegocioException($"Não foi possível obter a última execução da ação {ExecucaoTipo.CursoAdicionar}");

                var cursosParaAdicionar = await mediator.Send(new ObterCursosIncluirGoogleQuery(ultimaExecucaoCursosIncluir, new Paginacao(0, 0), null, null));

                if (cursosParaAdicionar != null || cursosParaAdicionar.Items.Any())
                {
                    foreach (var cursoParaAdicionar in cursosParaAdicionar.Items)
                    {
                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoIncluir, RotasRabbit.FilaCursoIncluir, cursoParaAdicionar));
                    }
                }

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.CursoAdicionar));

                return true;

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos cursos no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}
