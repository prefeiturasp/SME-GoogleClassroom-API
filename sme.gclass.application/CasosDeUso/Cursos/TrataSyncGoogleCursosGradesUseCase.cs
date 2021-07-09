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
    public class TrataSyncGoogleCursosGradesUseCase : ITrataSyncGoogleCursosGradesUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursosGradesUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.CursoGradesAdicionar));

            var paginacao = new Paginacao(0, 0);
            var gradesDeCursosAlunos = await mediator.Send(new ObterGradesDeCursosQuery(ultimaAtualizacao, paginacao));

            foreach (var gradeDeCurso in gradesDeCursosAlunos.Items)
            {
                var cursoDoAlunoParaIncluir = new CursoEol(gradeDeCurso.Nome, gradeDeCurso.Secao, gradeDeCurso.TurmaId, gradeDeCurso.ComponenteCurricularId, gradeDeCurso.UeCodigo, gradeDeCurso.Email);

                try
                {
                    var publicarGradeAlunoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoIncluir, RotasRabbit.FilaCursoIncluir, cursoDoAlunoParaIncluir));
                    if (!publicarGradeAlunoCurso)
                    {
                        await IncluirGradeDeCursoComErroAsync(gradeDeCurso, ObterMensagemDeErro(gradeDeCurso));
                    }
                }
                catch (Exception ex)
                {
                    await IncluirGradeDeCursoComErroAsync(gradeDeCurso, ObterMensagemDeErro(gradeDeCurso, ex));
                }
            }            

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.CursoGradesAdicionar, DateTime.Today));
            return true;
        }

        private async Task IncluirGradeDeCursoComErroAsync(GradeCursoEol gradeCursoEol, string mensagem)
        {
            var command = new InserirCursoErroCommand(
                gradeCursoEol.TurmaId,
                gradeCursoEol.ComponenteCurricularId,
                mensagem,
                null,
                ExecucaoTipo.CursoGradesAdicionar,
                ErroTipo.Negocio);

            await mediator.Send(command);
        }

        private static string ObterMensagemDeErro(GradeCursoEol gradeCursoEol, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir a grade do curso [TurmaId:{gradeCursoEol.TurmaId}, ComponenteCurricularId:{gradeCursoEol.ComponenteCurricularId}] na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }        
    }
}