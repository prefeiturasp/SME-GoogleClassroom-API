using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleCursoErroUseCase : ITrataSyncGoogleCursoErroUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursoErroUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var cursosErroParaTratar = await mediator.Send(new ObterCursosComErroQuery());
                if (cursosErroParaTratar != null && cursosErroParaTratar.Any())
                {
                    foreach (var cursoErroParaTratar in cursosErroParaTratar)
                    {
                        try
                        {                            
                            await mediator.Send(new ExcluirCursoErroCommand(cursoErroParaTratar.Id));

                            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoErroTratamento, RotasRabbit.FilaCursoErroTratamento, cursoErroParaTratar));
                        }
                        catch (Exception ex)
                        {
                            await mediator.Send(new InserirCursoErroCommand(cursoErroParaTratar.TurmaId, cursoErroParaTratar.ComponenteCurricularId, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
                        }
                    }
                }
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
