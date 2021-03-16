using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleCursosGradesUseCase : ITrataSyncGoogleCursosGradesUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursosGradesUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.CursoGradesAdicionar));

                var paginacao = new Paginacao(0, 0);
                var gradesDeCursosAlunos = await mediator.Send(new ObterGradesDeCursosDosAlunosQuery(ultimaAtualizacao, paginacao));

                foreach (var gradeDeCursoAluno in gradesDeCursosAlunos.Items)
                {
                    var cursoDoAlunoParaIncluir = new AlunoCursoEol(gradeDeCursoAluno.CodigoAluno, gradeDeCursoAluno.TurmaId, gradeDeCursoAluno.ComponenteCurricularId);

                    try
                    {
                        var publicarGradeAlunoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoCursoIncluir, RotasRabbit.FilaAlunoCursoIncluir, cursoDoAlunoParaIncluir));
                        if (!publicarGradeAlunoCurso)
                        {
                            await IncluirCursoDoAlunoComErroAsync(cursoDoAlunoParaIncluir, ObterMensagemDeErro(cursoDoAlunoParaIncluir));
                        }
                    }
                    catch (Exception ex)
                    {
                        await IncluirCursoDoAlunoComErroAsync(cursoDoAlunoParaIncluir, ObterMensagemDeErro(cursoDoAlunoParaIncluir, ex));
                    }
                }

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.CursoGradesAdicionar, DateTime.Today));
                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos alunos no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirCursoDoAlunoComErroAsync(AlunoCursoEol cursoDoAlunoParaIncluirGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoDoAlunoParaIncluirGoogle.CodigoAluno,
                cursoDoAlunoParaIncluirGoogle.TurmaId,
                cursoDoAlunoParaIncluirGoogle.ComponenteCurricularId,
                ExecucaoTipo.CursoGradesAdicionar,
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