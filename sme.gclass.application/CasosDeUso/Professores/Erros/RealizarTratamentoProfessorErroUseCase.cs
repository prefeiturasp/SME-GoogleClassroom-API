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
    public class RealizarTratamentoProfessorErroUseCase : IRealizarTratamentoProfessorErroUseCase
    {
        private readonly IMediator mediator;

        public RealizarTratamentoProfessorErroUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var usuarioErro = JsonConvert.DeserializeObject<UsuarioErro>(mensagemRabbit.Mensagem.ToString());
            if (usuarioErro is null) return true;

            try
            {
                if (usuarioErro.UsuarioTipo != UsuarioTipo.Professor)
                {
                    SentrySdk.CaptureMessage($"Não foi possível realizar o tratamento de erro do usuário {usuarioErro.UsuarioId}. O usuário informado não é um professor.");
                    return false;
                }

                var professorEol = await mediator.Send(new ObterProfessorParaTratamentoDeErroQuery(usuarioErro.UsuarioId.GetValueOrDefault()));
                if (professorEol is null)
                {
                    SentrySdk.CaptureMessage($"Não foi possível realizar o tratamento de erro do professor RF{usuarioErro.UsuarioId} na fila. Professor não encontrado no Eol.");
                    return false;
                }

                var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorIncluir, RotasRabbit.FilaProfessorIncluir, professorEol));
                if (!publicarFuncionario)
                {
                    SentrySdk.CaptureMessage($"Não foi possível inserir o professor RF{usuarioErro.UsuarioId} na fila de inclusão.");
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