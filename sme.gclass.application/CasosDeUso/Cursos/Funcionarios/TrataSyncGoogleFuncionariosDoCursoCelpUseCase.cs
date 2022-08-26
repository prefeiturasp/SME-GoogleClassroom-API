using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleFuncionariosDoCursoCelpUseCase : ITrataSyncGoogleFuncionariosDoCursoCelpUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleFuncionariosDoCursoCelpUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var cursoParaIncluirFuncionarios = JsonConvert.DeserializeObject<FiltroFuncionarioDoCursoCelpDto>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluirFuncionarios is null)
            {
                await IncluirCursoParaIncluirFuncionariosComErroAsync(cursoParaIncluirFuncionarios, "Não foi possível iniciar a inclusão de funcionários do curso Celp no Google Classroom. O funcionário não foi informado corretamente.");
                return true;
            }
            
            var funcionarioDoCursoParaIncluir = ObterFuncionarioDoCursoParaIncluir(cursoParaIncluirFuncionarios);
            
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

            return true;
        }

        private FuncionarioCursoEol ObterFuncionarioDoCursoParaIncluir(FiltroFuncionarioDoCursoCelpDto funcionarioDoCursoCelpDto)
        {
            return new FuncionarioCursoEol
            {
                Email = funcionarioDoCursoCelpDto.EmailCoordenadorParametro,
                Indice = funcionarioDoCursoCelpDto.Indice,
                Rf = funcionarioDoCursoCelpDto.Rf.Value,
                TurmaId = funcionarioDoCursoCelpDto.TurmaId,
                ComponenteCurricularId = funcionarioDoCursoCelpDto.ComponenteCurricularId
            };
        }

        private async Task IncluirCursoParaIncluirFuncionariosComErroAsync(FiltroFuncionarioDoCursoCelpDto funcionarioDoCursoCelpDto, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                funcionarioDoCursoCelpDto.TurmaId,
                funcionarioDoCursoCelpDto.ComponenteCurricularId,
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