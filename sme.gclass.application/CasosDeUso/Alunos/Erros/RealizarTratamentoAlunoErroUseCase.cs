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
                    SentrySdk.CaptureMessage($"Não foi possível realizar o tratamento de erro do aluno RA{usuarioErro.UsuarioId} na fila. Aluno não encontrado no Eol.");
                    return false;
                }

                var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoIncluir, RotasRabbit.FilaAlunoIncluir, alunoEol));
                if (!publicarFuncionario)
                {
                    SentrySdk.CaptureMessage($"Não foi possível inserir o aluno RA{usuarioErro.UsuarioId} na fila de inclusão.");
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }

            return false;
        }
    }
}