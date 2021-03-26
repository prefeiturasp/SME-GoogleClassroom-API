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
    public class RealizarTratamentoAlunoErroUseCase : IRealizarTratamentoAlunoErroUseCase
    {
        private readonly IMediator mediator;

        public RealizarTratamentoAlunoErroUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var usuarioErro = JsonConvert.DeserializeObject<UsuarioErro>(mensagemRabbit.Mensagem.ToString());
            if (usuarioErro is null) return true;

            try
            {
                if (usuarioErro.UsuarioTipo != UsuarioTipo.Aluno)
                {
                    SentrySdk.CaptureMessage($"Não foi possível realizar o tratamento de erro do usuário {usuarioErro.UsuarioId}. O usuário informado não é um aluno.");
                    return false;
                }

                var alunoEol = await mediator.Send(new ObterAlunoParaTratamentoDeErroQuery(usuarioErro.UsuarioId.GetValueOrDefault()));
                if (alunoEol is null)
                {
                    var mensagem = $"Não foi possível realizar o tratamento de erro do aluno RA{usuarioErro.UsuarioId} na fila. Aluno não encontrado no Eol.";
                    SentrySdk.CaptureMessage(mensagem);
                    await mediator.Send(new IncluirUsuarioErroCommand(usuarioErro.UsuarioId, usuarioErro.Email, mensagem, usuarioErro.UsuarioTipo, usuarioErro.ExecucaoTipo));
                    return false;
                }

                var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoIncluir, RotasRabbit.FilaAlunoIncluir, alunoEol));
                if (!publicarFuncionario)
                {
                    var mensagem = $"Não foi possível inserir o aluno RA{usuarioErro.UsuarioId} na fila de inclusão.";
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