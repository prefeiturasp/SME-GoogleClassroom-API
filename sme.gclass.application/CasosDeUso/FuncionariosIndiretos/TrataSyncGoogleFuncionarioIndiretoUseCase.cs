using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleFuncionarioIndiretoUseCase : ITrataSyncGoogleFuncionarioIndiretoUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleFuncionarioIndiretoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            try
            {
                var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.FuncionarioIndiretoAdicionar));

                var paginacao = new Paginacao(0, 0);
                var funcionariosIndiretosParaIncluirGoogle = await mediator.Send(new ObterFuncionariosIndiretosParaIncluirGoogleQuery(ultimaAtualizacao, paginacao));

                foreach (var funcionarioIndiretosParaIncluirGoogle in funcionariosIndiretosParaIncluirGoogle.Items)
                {
                    try
                    {
                        var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioIndiretoIncluir, RotasRabbit.FilaFuncionarioIndiretoIncluir, funcionarioIndiretosParaIncluirGoogle));
                        if (!publicarFuncionario)
                        {
                            await IncluirFuncionarioIndiretoComErroAsync(funcionarioIndiretosParaIncluirGoogle, ObterMensagemDeErro(funcionarioIndiretosParaIncluirGoogle.Cpf));
                        }
                    }
                    catch (Exception ex)
                    {
                        await IncluirFuncionarioIndiretoComErroAsync(funcionarioIndiretosParaIncluirGoogle, ObterMensagemDeErro(funcionarioIndiretosParaIncluirGoogle.Cpf, ex));
                    }
                }

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.FuncionarioAdicionar, DateTime.Today));
                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos funcionários indiretos no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirFuncionarioIndiretoComErroAsync(FuncionarioIndiretoEol funcionarioIndiretoParaIncluirGoogle, string mensagem)
        {
            var funcionarioComErro = new IncluirUsuarioErroCommand(
                                null,
                                funcionarioIndiretoParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.FuncionarioIndireto,
                                ExecucaoTipo.FuncionarioIndiretoAdicionar,
                                DateTime.Now);
            await mediator.Send(funcionarioComErro);
        }

        private static string ObterMensagemDeErro(string cpf, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o funcionário indireto CPF{cpf} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}";
        }
    }
}