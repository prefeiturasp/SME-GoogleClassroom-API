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
    public class TrataSyncGoogleCursosDoFuncionarioUseCase : ITrataSyncGoogleCursosDoFuncionarioUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursosDoFuncionarioUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtroFuncionarioParaIncluirCursos = mensagemRabbit.ObterObjetoMensagem<FiltroFuncionarioGoogleDto>();
            var funcionarioParaIncluirCursos = filtroFuncionarioParaIncluirCursos.FuncionarioGoogle;
            var filtroParametros = filtroFuncionarioParaIncluirCursos.ParametrosCargaInicial;
            if (funcionarioParaIncluirCursos is null)
            {
                await IncluirCursoDoFuncionarioComErroAsync(funcionarioParaIncluirCursos, "Não foi possível iniciar a inclusão de cursos do funcionário no Google Classroom. O funcionário não foi informado corretamente.");
                return true;
            }

            var parametrosCargaInicialDto = filtroParametros != null ? filtroParametros : await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            var anoLetivo = filtroParametros != null ? filtroParametros.AnoLetivo.Value : DateTime.Now.Year;
            var cursosDoFuncionarioParaIncluir = await mediator.Send(new ObterCursosDoFuncionarioParaIncluirGoogleQuery(funcionarioParaIncluirCursos.Rf.GetValueOrDefault(), anoLetivo, parametrosCargaInicialDto));

            if (!cursosDoFuncionarioParaIncluir?.Any() ?? true) return true;

            foreach (var cursoDoFuncionarioParaIncluir in cursosDoFuncionarioParaIncluir)
            {
                try
                {
                    var publicarFuncionarioCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioCursoIncluir, RotasRabbit.FilaFuncionarioCursoIncluir, cursoDoFuncionarioParaIncluir));
                    if (!publicarFuncionarioCurso)
                    {
                        await IncluirCursoDoFuncionarioComErroAsync(cursoDoFuncionarioParaIncluir, ObterMensagemDeErro(cursoDoFuncionarioParaIncluir));
                    }
                }
                catch (Exception ex)
                {
                    await IncluirCursoDoFuncionarioComErroAsync(cursoDoFuncionarioParaIncluir, ObterMensagemDeErro(cursoDoFuncionarioParaIncluir, ex));
                }
            }

            return true;
        }

        private async Task IncluirCursoDoFuncionarioComErroAsync(FuncionarioGoogle funcionarioGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                funcionarioGoogle?.Rf ?? null,
                ExecucaoTipo.FuncionarioCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private async Task IncluirCursoDoFuncionarioComErroAsync(FuncionarioCursoEol cursoDoFuncionarioParaIncluirGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoDoFuncionarioParaIncluirGoogle.Rf,
                cursoDoFuncionarioParaIncluirGoogle.TurmaId,
                cursoDoFuncionarioParaIncluirGoogle.ComponenteCurricularId,
                ExecucaoTipo.FuncionarioCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private static string ObterMensagemDeErro(FuncionarioCursoEol cursoDoFuncionarioParaIncluirGoogle, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o curso [TurmaId:{cursoDoFuncionarioParaIncluirGoogle.TurmaId}, ComponenteCurricularId:{cursoDoFuncionarioParaIncluirGoogle.ComponenteCurricularId}] funcionário RF{cursoDoFuncionarioParaIncluirGoogle.Rf} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }
    }
}