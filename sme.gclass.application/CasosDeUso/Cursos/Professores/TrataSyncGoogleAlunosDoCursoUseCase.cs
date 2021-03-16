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
    public class TrataSyncGoogleAlunosDoCursoUseCase : ITrataSyncGoogleAlunosDoCursoUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleAlunosDoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var cursoParaIncluirAlunos = JsonConvert.DeserializeObject<CursoGoogle>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluirAlunos is null)
            {
                await IncluirCursoParaIncluirAlunosComErroAsync(cursoParaIncluirAlunos, "Não foi possível iniciar a inclusão de alunos do curso no Google Classroom. O curso não foi informado corretamente.");
                return true;
            }

            try
            {
                var alunosDoCursoParaIncluir = await mediator.Send(new ObterAlunosDoCursoParaIncluirGoogleQuery(DateTime.Now.Year, cursoParaIncluirAlunos.TurmaId, cursoParaIncluirAlunos.ComponenteCurricularId));
                if (!alunosDoCursoParaIncluir?.Any() ?? true) return true;

                foreach (var alunoDoCursoParaIncluir in alunosDoCursoParaIncluir)
                {
                    try
                    {
                        var publicarAlunoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoCursoIncluir, RotasRabbit.FilaAlunoCursoIncluir, alunoDoCursoParaIncluir));
                        if (!publicarAlunoCurso)
                        {
                            await IncluirCursoDoAlunoComErroAsync(alunoDoCursoParaIncluir, ObterMensagemDeErro(alunoDoCursoParaIncluir));
                        }
                    }
                    catch (Exception ex)
                    {
                        await IncluirCursoDoAlunoComErroAsync(alunoDoCursoParaIncluir, ObterMensagemDeErro(alunoDoCursoParaIncluir, ex));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de alunos do curso no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirCursoParaIncluirAlunosComErroAsync(CursoGoogle cursoGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoGoogle.TurmaId,
                cursoGoogle.ComponenteCurricularId,
                ExecucaoTipo.AlunoCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private async Task IncluirCursoDoAlunoComErroAsync(AlunoCursoEol cursoDoAlunoParaIncluirGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoDoAlunoParaIncluirGoogle.CodigoAluno,
                cursoDoAlunoParaIncluirGoogle.TurmaId,
                cursoDoAlunoParaIncluirGoogle.ComponenteCurricularId,
                ExecucaoTipo.AlunoCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private static string ObterMensagemDeErro(AlunoCursoEol cursoDoAlunoParaIncluirGoogle, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o curso [TurmaId:{cursoDoAlunoParaIncluirGoogle.TurmaId}, ComponenteCurricularId:{cursoDoAlunoParaIncluirGoogle.ComponenteCurricularId}] aluno RA{cursoDoAlunoParaIncluirGoogle.CodigoAluno} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }
    }
}