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
            var funcionarioParaIncluir = JsonConvert.DeserializeObject<FuncionarioEol>(mensagemRabbit.Mensagem.ToString());
            if (funcionarioParaIncluir is null) return true;

            try
            {
                var funcionarioJaIncluido = await mediator.Send(new ExisteFuncionarioPorRfQuery(funcionarioParaIncluir.Rf));
                if (funcionarioJaIncluido) return true;

                var funcionarioGoogle = new FuncionarioGoogle(funcionarioParaIncluir.Rf, funcionarioParaIncluir.Nome, funcionarioParaIncluir.Email, funcionarioParaIncluir.OrganizationPath);
                await mediator.Send(new InserirFuncionarioGoogleCommand(funcionarioGoogle));
                if(_deveExecutarIntegracao) funcionarioGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(funcionarioGoogle));
                await IniciarSyncGoogleCursosDoFuncionarioAsync(funcionarioGoogle);

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(funcionarioParaIncluir?.Rf, funcionarioParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioAdicionar, DateTime.Now));
                throw;
            }
        }

        private async Task IniciarSyncGoogleCursosDoFuncionarioAsync(FuncionarioGoogle funcionarioGoogle)
        {
            var publicarCursosDoFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioCursoSync, RotasRabbit.FilaFuncionarioCursoSync, funcionarioGoogle));
            if (!publicarCursosDoFuncionario)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(funcionarioGoogle?.Rf, funcionarioGoogle?.Email,
                    $"O funionário RF{funcionarioGoogle.Rf} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos cursos deste funcionário.", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioCursoAdicionar, DateTime.Now));
            }
        }
    }
}