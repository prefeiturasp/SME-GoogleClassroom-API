using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
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
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var cursoParaIncluirAlunos = JsonConvert.DeserializeObject<CursoGoogle>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluirAlunos is null)
            {
                await IncluirCursoParaIncluirAlunosComErroAsync(cursoParaIncluirAlunos, "Não foi possível iniciar a inclusão de alunos do curso no Google Classroom. O curso não foi informado corretamente.");
                return true;
            }

            var anoLetivo = DateTime.Today.Year;

            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(anoLetivo));
            var alunosDoCursoParaIncluir = await mediator.Send(new ObterAlunosDoCursoParaIncluirGoogleQuery(anoLetivo, cursoParaIncluirAlunos.TurmaId, cursoParaIncluirAlunos.ComponenteCurricularId, parametrosCargaInicialDto));
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

        private async Task IncluirCursoDoAlunoComErroAsync(AlunoCursoParaIncluirGoogleDto alunoCurso, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                alunoCurso.CodigoAluno,
                alunoCurso.TurmaId,
                alunoCurso.ComponenteCurricularId,
                ExecucaoTipo.AlunoCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private static string ObterMensagemDeErro(AlunoCursoParaIncluirGoogleDto alunoCurso, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o curso [TurmaId:{alunoCurso.TurmaId}, ComponenteCurricularId:{alunoCurso.ComponenteCurricularId}] aluno RA{alunoCurso.CodigoAluno} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }
    }
}