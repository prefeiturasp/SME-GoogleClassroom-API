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

            var filtro = mensagemRabbit?.ObterObjetoMensagem<ProfessorEFuncionarioInativoDto>();
            if (filtro is null)
                throw new NegocioException("A mensagem enviada é inválida.");

            try
            {
                var usuarioTipo = ObterUsuarioTipo(filtro);

                var usuarioInativado = await mediator.Send(new IncluirUsuarioInativoCommand(new UsuarioInativo(filtro.UsuarioId, usuarioTipo)));

                var unidadeOrganizacional = ObterDescricaoUnidadeOrganizacional(filtro);

                var unidadeOrganizacionalAtualizada = await mediator.Send(new AtualizarUnidadeOrganizacionalUsuarioCommand(filtro.UsuarioId, unidadeOrganizacional));

                var usuarioInativadoGoogle = await mediator.Send(new InativarFuncionarioGoogleCommand(filtro.EmailUsuario, usuarioTipo));

                if (usuarioInativado == false || unidadeOrganizacionalAtualizada == false || usuarioInativadoGoogle == false)
                    await InserirMensagemErroIntegracaoAsync(filtro, "Não foi possível Inativar o professor, funcionário ou funcionário indireto no GSA!");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                await InserirMensagemErroIntegracaoAsync(filtro, ex.Message);
            }
            return true;
        }

        private static UsuarioTipo ObterUsuarioTipo(ProfessorEFuncionarioInativoDto filtro)
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

        private static string ObterDescricaoUnidadeOrganizacional(ProfessorEFuncionarioInativoDto filtro)
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

        private async Task InserirMensagemErroIntegracaoAsync(ProfessorEFuncionarioInativoDto filtro, string mensagem)
        {
            SentrySdk.CaptureMessage($"Erro ao processar inativação do funcionário / professor {filtro.EmailUsuario}-{mensagem}" );
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaInativarProfessorErroTratar, filtro));
        }
    }
}
