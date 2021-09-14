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

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.Mensagem != null ? mensagem.ObterObjetoMensagem<FiltroCargaInicialDto>() : null;
            var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.FuncionarioAdicionar));
            var paginacao = new Paginacao(0, 0);
            var parametrosCargaInicialDto = filtro != null ? new ParametrosCargaInicialDto(filtro.TiposUes, filtro.Ues, filtro.Turmas, filtro.AnoLetivo) : 
                await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            var funcionariosParaIncluirGoogle = await mediator.Send(new ObterFuncionariosParaIncluirGoogleQuery(ultimaAtualizacao, paginacao, string.Empty, parametrosCargaInicialDto));

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
                catch (Exception ex)
                {
                    await IncluirFuncionarioComErroAsync(funcionarioParaIncluirGoogle, ObterMensagemDeErro(funcionarioParaIncluirGoogle.Rf, ex));
                }
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.FuncionarioAdicionar, DateTime.Today));
            return true;
        }

        private async Task IncluirFuncionarioComErroAsync(FuncionarioEol funcionarioParaIncluirGoogle, string mensagem)
        {
            var funcionarioComErro = new IncluirUsuarioErroCommand(
                                funcionarioParaIncluirGoogle.Rf,
                                funcionarioParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.Funcionario,
                                ExecucaoTipo.FuncionarioAdicionar);
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