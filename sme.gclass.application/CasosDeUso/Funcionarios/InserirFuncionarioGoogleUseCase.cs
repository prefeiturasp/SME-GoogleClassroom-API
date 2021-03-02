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

        public InserirFuncionarioGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var funcionarioParaIncluir = JsonConvert.DeserializeObject<FuncionarioEol>(mensagemRabbit.Mensagem.ToString());
            if (funcionarioParaIncluir is null) return true;

            try
            {
                // TO DO: Remover ao subir para produção
                //var funcionarioJaIncluido = await mediator.Send(new ExisteFuncionarioPorRfQuery(funcionarioParaIncluir.Rf));
                //if (funcionarioJaIncluido) return true;

                //var funcionarioGoogle = new FuncionarioGoogle(funcionarioParaIncluir.Rf, funcionarioParaIncluir.Nome, funcionarioParaIncluir.Email, funcionarioParaIncluir.OrganizationPath);
                //await mediator.Send(new InserirFuncionarioGoogleCommand(funcionarioGoogle));

                await Task.Delay(10000);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(funcionarioParaIncluir?.Rf, funcionarioParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioAdicionar, DateTime.Now));
                throw;
            }
        }
    }
}