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
            var filtro = ObterFiltro(mensagem);
            var ultimaAtualizacao = filtro != null ? new DateTime(filtro.AnoLetivo,1,1) : await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.FuncionarioIndiretoAdicionar));

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

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.FuncionarioIndiretoAdicionar, DateTime.Today));
            return true;
        }

        private async Task IncluirFuncionarioIndiretoComErroAsync(FuncionarioIndiretoEol funcionarioIndiretoParaIncluirGoogle, string mensagem)
        {
            var funcionarioComErro = new IncluirUsuarioErroCommand(
                                null,
                                funcionarioIndiretoParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.FuncionarioIndireto,
                                ExecucaoTipo.FuncionarioIndiretoAdicionar);
            await mediator.Send(funcionarioComErro);
        }

        private static string ObterMensagemDeErro(string cpf, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o funcionário indireto CPF{cpf} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}";
        }

        private FiltroCargaInicialDto ObterFiltro(MensagemRabbit mensagem)
        {
            try
            {
                return mensagem.ObterObjetoMensagem<FiltroCargaInicialDto>();
            }
            catch
            {
                return null;
            }
        }
    }
}