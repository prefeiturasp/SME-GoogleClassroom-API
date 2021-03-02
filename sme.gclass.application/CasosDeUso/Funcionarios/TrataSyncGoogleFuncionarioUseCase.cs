using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleFuncionarioUseCase : ITrataSyncGoogleFuncionarioUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleFuncionarioUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            try
            {
                var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.FuncionarioAdicionar));

                var paginacao = new Paginacao(0, 0);
                var funcionariosParaIncluirGoogle = await mediator.Send(new ObterFuncionariosParaIncluirGoogleQuery(ultimaAtualizacao, paginacao));
                foreach (var funcionarioParaIncluirGoogle in funcionariosParaIncluirGoogle.Items)
                {
                    try
                    {
                        var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioIncluir, RotasRabbit.FilaFuncionarioIncluir, funcionarioParaIncluirGoogle));
                        if (!publicarFuncionario)
                        {
                            await IncluirFuncionarioComErroAsync(funcionarioParaIncluirGoogle, ObterMensagemDeErro(funcionarioParaIncluirGoogle.Rf));
                        }
                    }
                    catch(Exception ex)
                    {
                        await IncluirFuncionarioComErroAsync(funcionarioParaIncluirGoogle, ObterMensagemDeErro(funcionarioParaIncluirGoogle.Rf, ex));
                    }
                }

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.FuncionarioAdicionar, DateTime.Today));
                return true;
            }
            catch(Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos funcionários no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirFuncionarioComErroAsync(FuncionarioEol funcionarioParaIncluirGoogle, string mensagem)
        {
            var funcionarioComErro = new IncluirUsuarioErroCommand(
                                funcionarioParaIncluirGoogle.Rf,
                                funcionarioParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.Funcionario,
                                ExecucaoTipo.FuncionarioAdicionar,
                                DateTime.Now);
            await mediator.Send(funcionarioComErro);
        }

        private static string ObterMensagemDeErro(long cdRegistroFuncional, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o funcionário RF{cdRegistroFuncional} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}";
        }
    }
}