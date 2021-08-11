using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarTratamentoFuncionarioErroUseCase : IRealizarTratamentoFuncionarioErroUseCase
    {
        private readonly IMediator mediator;

        public RealizarTratamentoFuncionarioErroUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var usuarioErro = JsonConvert.DeserializeObject<UsuarioErro>(mensagemRabbit.Mensagem.ToString());
            if (usuarioErro is null) return true;

            try
            {
                if (usuarioErro.UsuarioTipo != UsuarioTipo.Funcionario)
                {
                    SentrySdk.CaptureMessage($"Não foi possível realizar o tratamento de erro do usuário {usuarioErro.UsuarioId}. O usuário informado não é um funcionário.");
                    return false;
                }

                var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
                var funcionarioEol = await mediator.Send(new ObterFuncionarioParaTratamentoDeErroQuery(usuarioErro.UsuarioId.GetValueOrDefault(), parametrosCargaInicialDto));
                if (funcionarioEol is null)
                {
                    var mensagem = $"Não foi possível realizar o tratamento de erro do funcionário RF{usuarioErro.UsuarioId} na fila. Funcionario não encontrado no Eol.";
                    SentrySdk.CaptureMessage(mensagem);
                    return false;
                }

                var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioIncluir, RotasRabbit.FilaFuncionarioIncluir, funcionarioEol));
                if (!publicarFuncionario)
                {
                    var mensagem = $"Não foi possível inserir o funcionário RF{usuarioErro.UsuarioId} na fila de inclusão.";
                    SentrySdk.CaptureMessage(mensagem);
                    await mediator.Send(new IncluirUsuarioErroCommand(usuarioErro.UsuarioId, usuarioErro.Email, mensagem, usuarioErro.UsuarioTipo, usuarioErro.ExecucaoTipo));
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                await mediator.Send(new IncluirUsuarioErroCommand(usuarioErro.UsuarioId, usuarioErro.Email, ex.InnerException?.Message ?? ex.Message, usuarioErro.UsuarioTipo, usuarioErro.ExecucaoTipo));
            }

            return false;
        }
    }
}