using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAlunoUseCase : IIncluirAlunoUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public IncluirAlunoUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var alunoParaIncluir = JsonConvert.DeserializeObject<AlunoEol>(mensagemRabbit.Mensagem.ToString());
            if (alunoParaIncluir is null) return true;

            try
            {
                var alunoJaIncluido = await mediator.Send(new ExisteAlunoPorRfQuery(alunoParaIncluir.Codigo));
                if (alunoJaIncluido) return true;

                var alunoGoogle = new AlunoGoogle(alunoParaIncluir.Codigo, alunoParaIncluir.Nome, alunoParaIncluir.Email, alunoParaIncluir.OrganizationPath);
                var incluiuAlunoGoogle = await mediator.Send(new InserirAlunoGoogleCommand(alunoGoogle));
                if(incluiuAlunoGoogle && _deveExecutarIntegracao)
                    await mediator.Send(new IncluirUsuarioCommand(alunoGoogle));

                if(!incluiuAlunoGoogle)
                    await mediator.Send(new IncluirUsuarioErroCommand(alunoParaIncluir?.Codigo, alunoParaIncluir?.Email,
                   $"ex.: Erro ao inserir no google <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar, DateTime.Now));

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoParaIncluir?.Codigo, alunoParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar, DateTime.Now));
                throw;
            }
        }
    }
}
