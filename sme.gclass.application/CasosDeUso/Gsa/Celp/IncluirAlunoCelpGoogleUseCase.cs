using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAlunoCelpGoogleUseCase : IIncluirAlunoCelpGoogleUseCase
    {
        private readonly IMediator mediator;

        public IncluirAlunoCelpGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o aluno. A mensagem enviada é inválida.");

            var alunoEol = mensagemRabbit.ObterObjetoMensagem<AlunoEol>();
            
            var alunoParaIncluir = alunoEol;
            if (alunoParaIncluir is null)
                throw new NegocioException("Não foi possível incluir o aluno. A mensagem enviada é inválida.");

            try
            {
                var alunoJaIncluido = await mediator.Send(new ObterAlunosPorCodigosQuery(alunoParaIncluir.Codigo));
                var googleClassroomId = alunoJaIncluido.Any() ? alunoJaIncluido.First().GoogleClassroomId : null;
                if (alunoJaIncluido != null && alunoJaIncluido.Any() && googleClassroomId != null && !googleClassroomId.Equals(alunoParaIncluir.Codigo.ToString()))
                {
                    await AtualizarAlunoGoogleSync(alunoEol, alunoJaIncluido.First());
                    return true;
                }

                alunoParaIncluir = await mediator.Send(new VerificarEmailExistenteAlunoQuery(alunoParaIncluir));
                var alunoGoogle = new AlunoGoogle(alunoParaIncluir.Codigo, alunoParaIncluir.Nome, alunoParaIncluir.Email, alunoParaIncluir.OrganizationPath);

                await InserirAlunoGoogleAsync(alunoGoogle, alunoJaIncluido?.FirstOrDefault(), alunoEol);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoParaIncluir?.Codigo, alunoParaIncluir?.Email,
                    $"IncluirAlunoCelpGoogleUseCase - Erro: {ex.Message} - Mensagem Rabbit: {mensagemRabbit} - StackTrace:{ex.StackTrace}.", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                throw;
            }
        }

        private async Task InserirAlunoGoogleAsync(AlunoGoogle alunoGoogle, AlunoGoogle alunoJaIncluido, AlunoEol alunoEol)
        {
            try
            {
                var incluiuAlunoGoogle = await mediator.Send(new InserirAlunoGoogleCommand(alunoGoogle));
                if (!incluiuAlunoGoogle)
                {
                    await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                        $"IncluirAlunoCelpGoogleUseCase - InserirAlunoGoogleAsync - Não foi possível incluir o aluno no Google Classroom. {alunoGoogle}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                    return;
                }

                if (alunoJaIncluido != null)
                {
                    alunoJaIncluido.GoogleClassroomId = alunoGoogle.GoogleClassroomId;
                    await AtualizarAlunoGoogleSync(alunoEol, alunoJaIncluido);
                }
                else
                    await InserirAlunoAsync(alunoGoogle);
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirAlunoAsync(alunoGoogle);
                else
                    throw;
            }
        }

        private async Task InserirAlunoAsync(AlunoGoogle alunoGoogle)
        {
            alunoGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(alunoGoogle)); 
        }

        private async Task AtualizarAlunoGoogleSync(AlunoEol alunoEol, AlunoGoogle alunoGoogle)
        {
            alunoGoogle.Nome = alunoEol.Nome;
            
            alunoGoogle.OrganizationPath = alunoEol.OrganizationPath;

            var incluiuAlunoGoogle = await mediator.Send(new AtualizarAlunoGoogleCommand(alunoGoogle));
            if (!incluiuAlunoGoogle)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                    $"IncluirAlunoCelpGoogleUseCase - AtualizarAlunoGoogleSync - Não foi possível atualizar o aluno no Google Classroom. {alunoGoogle}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                return;
            }

            var usuarioAlterado = await mediator.Send(new AtualizarUsuarioCommand(alunoGoogle.Indice, alunoGoogle.Nome, alunoGoogle.OrganizationPath));
            if (!usuarioAlterado)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                    $"IncluirAlunoCelpGoogleUseCase - AtualizarAlunoGoogleSync - Não foi possível atualizar o aluno {alunoGoogle} no Google Classroom. O aluno não foi encontrado na base.", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                return;
            }

            var idAlterado = await mediator.Send(new AtualizarUsuarioGoogleClassroomIdCommand(alunoGoogle.Indice, alunoGoogle.GoogleClassroomId));
            if (!idAlterado)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                    $"IncluirAlunoCelpGoogleUseCase - AtualizarAlunoGoogleSync - Não foi possível atualizar o Id do aluno {alunoGoogle} no Google Classroom.", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                return;
            }
        }
    }
}
