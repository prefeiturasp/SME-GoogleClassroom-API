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
    public class TrataSyncGoogleFuncionariosDoCursoUseCase : ITrataSyncGoogleFuncionariosDoCursoUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleFuncionariosDoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var cursoParaIncluirFuncionarios = JsonConvert.DeserializeObject<CursoGoogle>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluirFuncionarios is null)
            {
                await IncluirCursoParaIncluirFuncionariosComErroAsync(cursoParaIncluirFuncionarios, "Não foi possível iniciar a inclusão de funcionários do curso no Google Classroom. O funcionário não foi informado corretamente.");
                return true;
            }

            try
            {
                var funcionariosDoCursoParaIncluir = await mediator.Send(new ObterFuncionariosDoCursoParaIncluirGoogleQuery(DateTime.Now.Year, cursoParaIncluirFuncionarios.TurmaId, cursoParaIncluirFuncionarios.ComponenteCurricularId));
                if (!funcionariosDoCursoParaIncluir?.Any() ?? true) return true;

                foreach (var funcionarioDoCursoParaIncluir in funcionariosDoCursoParaIncluir)
                {
                    try
                    {
                        var publicarFuncionarioCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioCursoIncluir, RotasRabbit.FilaFuncionarioCursoIncluir, funcionarioDoCursoParaIncluir));
                        if (!publicarFuncionarioCurso)
                        {
                            await IncluirCursoDoFuncionarioComErroAsync(funcionarioDoCursoParaIncluir, ObterMensagemDeErro(funcionarioDoCursoParaIncluir));
                        }
                    }
                    catch (Exception ex)
                    {
                        await IncluirCursoDoFuncionarioComErroAsync(funcionarioDoCursoParaIncluir, ObterMensagemDeErro(funcionarioDoCursoParaIncluir, ex));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de funcionários do curso no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirCursoParaIncluirFuncionariosComErroAsync(CursoGoogle cursoGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoGoogle.TurmaId,
                cursoGoogle.ComponenteCurricularId,
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