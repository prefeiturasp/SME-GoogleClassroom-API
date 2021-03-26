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
    public class InserirFuncionarioIndiretoGoogleUseCase : IInserirFuncionarioIndiretoGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public InserirFuncionarioIndiretoGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator;
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var funcionarioIndiretoParaIncluir = JsonConvert.DeserializeObject<FuncionarioIndiretoEol>(mensagemRabbit.Mensagem.ToString());
            if (funcionarioIndiretoParaIncluir is null) return true;

            try
            {
                var funcionarioIndiretoGoogle = new FuncionarioIndiretoGoogle(funcionarioIndiretoParaIncluir.Cpf, funcionarioIndiretoParaIncluir.Nome, funcionarioIndiretoParaIncluir.Email, funcionarioIndiretoParaIncluir.OrganizationPath);

                var funcionarioJaIncluido = await mediator.Send(new ExisteFuncionarioIndiretoPorCpfQuery(funcionarioIndiretoParaIncluir.Cpf));
                if (funcionarioJaIncluido) return true;

                await InserirFuncionarioIndiretoGoogleAsync(funcionarioIndiretoGoogle);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(null, funcionarioIndiretoParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioAdicionar));
                throw;
            }
        }

        private async Task InserirFuncionarioIndiretoGoogleAsync(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle)
        {
            try
            {
                var funcionarioSincronizado = await mediator.Send(new InserirFuncionarioIndiretoGoogleCommand(funcionarioIndiretoGoogle));
                if (!funcionarioSincronizado)
                {
                    await mediator.Send(new IncluirUsuarioErroCommand(null, funcionarioIndiretoGoogle?.Email,
                        $"Não foi possível incluir o funcionário no Google Classroom. {funcionarioIndiretoGoogle}", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioAdicionar));
                    return;
                }

                await InserirFuncionarioIndiretoAsync(funcionarioIndiretoGoogle);
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                {
                    await mediator.Send(new AtualizarFuncionarioIndiretoGoogleCommand(funcionarioIndiretoGoogle));
                    await InserirFuncionarioIndiretoAsync(funcionarioIndiretoGoogle);
                }
                else
                    throw;
            }
        }

        private async Task InserirFuncionarioIndiretoAsync(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle)
        {
            if (_deveExecutarIntegracao)
                funcionarioIndiretoGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(funcionarioIndiretoGoogle));
        }
    }
}