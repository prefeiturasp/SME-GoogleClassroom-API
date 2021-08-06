using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SyncProfessoresInativosGsaUseCase : ISyncProfessoresEFuncionariosInativarUseCase
    {
        private readonly IMediator mediator;

        public SyncProfessoresInativosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a inativação professores / funcionários GSA.");

            var filtro = mensagemRabbit?.ObterObjetoMensagem<ProfessorInativoDto>();
            if (filtro is null)
                throw new NegocioException("A mensagem enviada é inválida.");

            try
            {
                var usuarioTipo = ObterUsuarioTipo(filtro);

                var usuarioInativado = await mediator.Send(new IncluirUsuarioInativoCommand(new UsuarioInativo(filtro.UsuarioId, usuarioTipo)));

                var unidadeOrganizacional = ObterDescricaoUnidadeOrganizacional(filtro);

                var unidadeOrganizacionalAtualizada = await mediator.Send(new AtualizarUnidadeOrganizacionalUsuarioCommand(filtro.UsuarioId, unidadeOrganizacional));

                var professorInativoGoogle = await mediator.Send(new InativarProfessorGoogleCommand(filtro.EmailUsuario, usuarioTipo));

                if (usuarioInativado == false || unidadeOrganizacionalAtualizada == false || professorInativoGoogle == false)
                    await InserirMensagemErroIntegracaoAsync(filtro, "Não foi possível Inativar o professor / funcioário no GSA!");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                await InserirMensagemErroIntegracaoAsync(filtro, ex.Message);
            }
            return true;
        }

        private static UsuarioTipo ObterUsuarioTipo(ProfessorInativoDto filtro)
        {
            var usuarioTipo = new UsuarioTipo();
            switch (filtro.UsuarioTipo)
            {
                case 1:
                    usuarioTipo = UsuarioTipo.Aluno;
                    break;
                case 2:
                    usuarioTipo = UsuarioTipo.Professor;
                    break;
                case 3:
                    usuarioTipo = UsuarioTipo.Funcionario;
                    break;
                case 4:
                    usuarioTipo = UsuarioTipo.FuncionarioIndireto;
                    break;
                default:
                    break;
            }

            return usuarioTipo;
        }

        private static string ObterDescricaoUnidadeOrganizacional(ProfessorInativoDto filtro)
        {
            var unidadeOrganizacional = "";
            switch (filtro.UsuarioTipo)
            {
                case 1:
                    unidadeOrganizacional = "Alunos/Inativos";
                    break;
                case 2:
                    unidadeOrganizacional = "Professores/Inativos";
                    break;
                case 3:
                    unidadeOrganizacional = "Funcionarios/Inativos";
                    break;
                case 4:
                    unidadeOrganizacional = "FuncionariosIndiretos/Inativos";
                    break;
                default:
                    break;
            }
            return unidadeOrganizacional;
        }

        private async Task InserirMensagemErroIntegracaoAsync(ProfessorInativoDto filtro, string mensagem)
        {
            SentrySdk.CaptureMessage($"Erro ao processar inativação do funcioário / professor {filtro.EmailUsuario}-{mensagem}" );
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarProfessorErroTratar, filtro));
        }
    }
}
