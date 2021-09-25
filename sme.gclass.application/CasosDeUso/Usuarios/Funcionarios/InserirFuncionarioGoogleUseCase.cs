using Google;
using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioGoogleUseCase : IInserirFuncionarioGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public InserirFuncionarioGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator;
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o funcionário. A mensagem enviada é inválida.");

            var filtro = mensagemRabbit.ObterObjetoMensagem<FiltroFuncionarioDto>();
            var funcionarioParaIncluir = filtro.FuncionarioEol;
            var parametrosCargaInicial = filtro.ParametrosCargaInicial;
            if (funcionarioParaIncluir is null) return true;

            try
            {
                var funcionarioGoogle = new FuncionarioGoogle(funcionarioParaIncluir.Rf, funcionarioParaIncluir.Nome, funcionarioParaIncluir.Email, funcionarioParaIncluir.OrganizationPath);

                var funcionarioJaIncluido = await mediator.Send(new ExisteFuncionarioPorRfQuery(funcionarioParaIncluir.Rf));
                var filtroFuncionarioGoogle = new FiltroFuncionarioGoogleDto(funcionarioGoogle, parametrosCargaInicial);
                if (funcionarioJaIncluido)
                {
                    await IniciarSyncGoogleCursosDoFuncionarioAsync(filtroFuncionarioGoogle);
                    return true;
                }

                await InserirFuncionarioGoogleAsync(filtroFuncionarioGoogle);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(funcionarioParaIncluir?.Rf, funcionarioParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}. StackTrace:{ex.StackTrace}.", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioAdicionar));
                throw;
            }
        }

        private async Task InserirFuncionarioGoogleAsync(FiltroFuncionarioGoogleDto filtroFuncionarioGoogle)
        {
            var funcionarioGoogle = filtroFuncionarioGoogle.FuncionarioGoogle;
            try
            {
                var funcionarioSincronizado = await mediator.Send(new InserirFuncionarioGoogleCommand(funcionarioGoogle));
                if (!funcionarioSincronizado)
                {
                    await mediator.Send(new IncluirUsuarioErroCommand(funcionarioGoogle?.Rf, funcionarioGoogle?.Email,
                        $"Não foi possível incluir o funcionário no Google Classroom. {funcionarioGoogle}", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioAdicionar));
                    return;
                }

                await InserirFuncionarioAsync(filtroFuncionarioGoogle);
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirFuncionarioAsync(filtroFuncionarioGoogle);
                else
                    throw;
            }
        }

        private async Task InserirFuncionarioAsync(FiltroFuncionarioGoogleDto filtroFuncionarioGoogle)
        {
            var funcionarioGoogle = filtroFuncionarioGoogle.FuncionarioGoogle;
            funcionarioGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(funcionarioGoogle));
            await IniciarSyncGoogleCursosDoFuncionarioAsync(filtroFuncionarioGoogle);
        }

        private async Task IniciarSyncGoogleCursosDoFuncionarioAsync(FiltroFuncionarioGoogleDto filtroFuncionarioGoogle)
        {
            var funcionarioGoogle = filtroFuncionarioGoogle.FuncionarioGoogle;
            var publicarCursosDoFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioCursoSync, RotasRabbit.FilaFuncionarioCursoSync, filtroFuncionarioGoogle));
            if (!publicarCursosDoFuncionario)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(funcionarioGoogle?.Rf, funcionarioGoogle?.Email,
                    $"O funionário RF{funcionarioGoogle.Rf} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos cursos deste funcionário.", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioCursoAdicionar));
            }
        }
    }
}