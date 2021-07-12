using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarInativacaoUsuarioGsaUseCase : ISincronizarInativacaoUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public SincronizarInativacaoUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a inativação usuário GSA.");

            var filtro = mensagemRabbit?.ObterObjetoMensagem<FiltroInativacaoUsuarioGsaDTO>();
            if (filtro is null)
                throw new NegocioException("A mensagem enviada é inválida.");

            try
            {
                var alunoInativado = await mediator.Send(new InativarUsuarioCommand(filtro.UsuarioId));

                if (alunoInativado == false)
                    await InserirMensagemErroIntegracaoAsync(filtro, "Não foi possível Inativar o Usuário");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                await InserirMensagemErroIntegracaoAsync(filtro, ex.Message);
            }
            return true;
        }

        private async Task InserirMensagemErroIntegracaoAsync(FiltroInativacaoUsuarioGsaDTO filtro, string mensagem)
          => await mediator.Send(new IncluirInativacaoUsuarioErroCommand(new AlunoInativoErro(filtro.UsuarioId, mensagem)));
    }
}