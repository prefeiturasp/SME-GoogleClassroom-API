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
    public class TrataSyncGoogleProfessoresDoCursoUseCase : ITrataSyncGoogleProfessoresDoCursoUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleProfessoresDoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var cursoParaIncluirProfessores = JsonConvert.DeserializeObject<CursoGoogle>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluirProfessores is null)
            {
                await IncluirCursoParaIncluirProfessoresComErroAsync(cursoParaIncluirProfessores, "Não foi possível iniciar a inclusão de professores do curso no Google Classroom. O professor não foi informado corretamente.");
                return true;
            }

            var cursosDoProfessorParaIncluir = await mediator.Send(new ObterProfessoresDoCursoParaIncluirGoogleQuery(DateTime.Now.Year, cursoParaIncluirProfessores.TurmaId, cursoParaIncluirProfessores.ComponenteCurricularId));
            if (!cursosDoProfessorParaIncluir?.Any() ?? true) return true;

            foreach (var cursoDoProfessorParaIncluir in cursosDoProfessorParaIncluir)
            {
                try
                {
                    var publicarProfessorCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoIncluir, RotasRabbit.FilaProfessorCursoIncluir, cursoDoProfessorParaIncluir));
                    if (!publicarProfessorCurso)
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

        private async Task IncluirCursoParaIncluirProfessoresComErroAsync(CursoGoogle cursoGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoGoogle.TurmaId,
                cursoGoogle.ComponenteCurricularId,
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