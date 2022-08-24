using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var cursoParaIncluirFuncionarios = JsonConvert.DeserializeObject<CursoGoogle>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluirFuncionarios is null)
            {
                await IncluirCursoParaIncluirFuncionariosComErroAsync(cursoParaIncluirFuncionarios, "Não foi possível iniciar a inclusão de funcionários do curso no Google Classroom. O funcionário não foi informado corretamente.");
                return true;
            }
            
            var parametroEmailCoordenador = await ObterParametroEmailCoordenador();

            var coordenadorDoCurso = await mediator.Send(new ObterFuncionariosGooglePorEmailQuery(parametroEmailCoordenador.Valor));
            if (coordenadorDoCurso is null || !coordenadorDoCurso.Any())
            {
                await IncluirCursoParaIncluirFuncionariosComErroAsync(cursoParaIncluirFuncionarios, @"Não foi possível iniciar a inclusão do Coordenador (funcionários) do curso CELP no Google Classroom. O funcionário não foi encontrado.");
                return true;
            }
            
            var funcionarioDoCursoParaIncluir = ObterFuncionarioDoCursoParaIncluir(parametroEmailCoordenador, coordenadorDoCurso, cursoParaIncluirFuncionarios);
            
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

        private async Task<ParametrosSistema> ObterParametroEmailCoordenador()
        {
            var parametroEmailCoordenador =
                await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistema.EmailCoordenadorCELP,
                    DateTime.Now.Year));
            if (parametroEmailCoordenador is null)
                throw new NegocioException(
                    $"Parâmetro do E-mail do Coordenador do CELP não localizado para o ano {DateTime.Now.Year}");
            return parametroEmailCoordenador;
        }

        private static FuncionarioCursoEol ObterFuncionarioDoCursoParaIncluir(ParametrosSistema parametroEmailCoordenador, IEnumerable<FuncionarioGoogle> coordenadorDoCurso, CursoGoogle cursoParaIncluirFuncionarios)
        {
            return new FuncionarioCursoEol
            {
                Email = parametroEmailCoordenador.Valor,
                Indice = coordenadorDoCurso.FirstOrDefault().Indice,
                Rf = coordenadorDoCurso.FirstOrDefault().Rf.Value,
                TurmaId = cursoParaIncluirFuncionarios.TurmaId,
                ComponenteCurricularId = cursoParaIncluirFuncionarios.ComponenteCurricularId
            };
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