using MediatR;
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
    public class TrataSyncGoogleCursosDoProfessorUseCase : ITrataSyncGoogleCursosDoProfessorUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursosDoProfessorUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var professorParaIncluirCursos = JsonConvert.DeserializeObject<ProfessorGoogle>(mensagemRabbit.Mensagem.ToString());
            if (professorParaIncluirCursos is null)
            {
                await IncluirCursoDoProfessorComErroAsync(professorParaIncluirCursos, "Não foi possível iniciar a inclusão de cursos professores no Google Classroom. O professor não foi informado corretamente.");
                return true;
            }

            try
            {
                var cursosDoProfessorParaIncluir = await mediator.Send(new ObterCursosDoProfessorParaIncluirGoogleQuery(professorParaIncluirCursos.Rf, DateTime.Now.Year));
                if (!cursosDoProfessorParaIncluir?.Any() ?? true) return true;

                foreach (var cursoDoProfessorParaIncluir in cursosDoProfessorParaIncluir)
                {
                    try
                    {
                        var publicarProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoIncluir, RotasRabbit.FilaProfessorCursoIncluir, cursoDoProfessorParaIncluir));
                        if (!publicarProfessor)
                        {
                            await IncluirCursoDoProfessorComErroAsync(cursoDoProfessorParaIncluir, ObterMensagemDeErro(cursoDoProfessorParaIncluir));
                        }
                    }
                    catch (Exception ex)
                    {
                        await IncluirCursoDoProfessorComErroAsync(cursoDoProfessorParaIncluir, ObterMensagemDeErro(cursoDoProfessorParaIncluir, ex));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de cursos professores no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirCursoDoProfessorComErroAsync(ProfessorGoogle professorEol, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                professorEol.Rf,
                ExecucaoTipo.ProfessorCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private async Task IncluirCursoDoProfessorComErroAsync(ProfessorCursoEol cursoDoprofessorParaIncluirGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoDoprofessorParaIncluirGoogle.Rf,
                cursoDoprofessorParaIncluirGoogle.TurmaId,
                cursoDoprofessorParaIncluirGoogle.ComponenteCurricularId,
                ExecucaoTipo.ProfessorCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private static string ObterMensagemDeErro(ProfessorCursoEol cursoDoprofessorParaIncluirGoogle, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o curso [TurmaId:{cursoDoprofessorParaIncluirGoogle.TurmaId}, ComponenteCurricularId:{cursoDoprofessorParaIncluirGoogle.ComponenteCurricularId}] professor RF{cursoDoprofessorParaIncluirGoogle.Rf} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }
    }
}