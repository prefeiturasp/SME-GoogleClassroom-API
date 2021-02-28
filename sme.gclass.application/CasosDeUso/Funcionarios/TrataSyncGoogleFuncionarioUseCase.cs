using MediatR;
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

        public async Task Executar(MensagemRabbit mensagem)
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
                            await IncluirFuncionarioComErroAsync(funcionarioParaIncluirGoogle, ObterMensagemDeErro(funcionarioParaIncluirGoogle.CdRegistroFuncional));
                        }
                    }
                    catch(Exception ex)
                    {
                        await IncluirFuncionarioComErroAsync(funcionarioParaIncluirGoogle, ObterMensagemDeErro(funcionarioParaIncluirGoogle.CdRegistroFuncional, ex));
                    }
                }

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.FuncionarioAdicionar, DateTime.Today));
            }
            catch(Exception ex)
            {
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos funcionários no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirFuncionarioComErroAsync(FuncionarioParaIncluirGoogleDto funcionarioParaIncluirGoogle, string mensagem)
        {
            var funcionarioComErro = new IncluirUsuarioErroCommand(
                                long.Parse(funcionarioParaIncluirGoogle.CdRegistroFuncional),
                                funcionarioParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.Funcionario,
                                ExecucaoTipo.FuncionarioAdicionar,
                                DateTime.Now);
            await mediator.Send(funcionarioComErro);
        }

        private static string ObterMensagemDeErro(string cdRegistroFuncional, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o funcionário RF{cdRegistroFuncional} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}";
        }
    }
}