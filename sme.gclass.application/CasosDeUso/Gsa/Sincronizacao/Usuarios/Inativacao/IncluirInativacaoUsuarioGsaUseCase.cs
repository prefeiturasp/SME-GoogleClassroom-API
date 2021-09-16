using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirInativacaoUsuarioGsaUseCase : IIncluirInativacaoUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public IncluirInativacaoUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a inativação usuário GSA.");

            var filtro = mensagemRabbit?.ObterObjetoMensagem<AlunoUsuarioInativarDto>();
            if (filtro is null)
                throw new NegocioException("A mensagem enviada é inválida.");

            try
            {
                var usuarioInativado = await mediator.Send(new IncluirUsuarioInativoCommand(new UsuarioInativo(filtro.UsuarioId, UsuarioTipo.Aluno)));

                var unidadeOrganizacionalAtualizada = await mediator.Send(new AtualizarUnidadeOrganizacionalUsuarioCommand(filtro.UsuarioId, "Alunos/Inativos"));

                var alunoRemovidoGoogle = await mediator.Send(new InativarAlunoGoogleCommand(filtro.EmailUsuario));

                if (usuarioInativado == false || unidadeOrganizacionalAtualizada == false || alunoRemovidoGoogle == false)
                    await InserirMensagemErroIntegracaoAsync(filtro, "Não foi possível Inativar o Usuário!");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                await InserirMensagemErroIntegracaoAsync(filtro, ex.Message);
            }
            return true;
        }

        private async Task InserirMensagemErroIntegracaoAsync(AlunoUsuarioInativarDto filtro, string mensagem)
          => await mediator.Send(new IncluirInativacaoUsuarioErroCommand(new UsuarioInativoErro(filtro.UsuarioId, mensagem)));
    }
}