using Google;
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
                await mediator.Send(new VerificarEmailExistenteAlunoQuery(alunoParaIncluir));
                var alunoGoogle = new AlunoGoogle(alunoParaIncluir.Codigo, alunoParaIncluir.Nome, alunoParaIncluir.Email, alunoParaIncluir.OrganizationPath);

                var alunoJaIncluido = await mediator.Send(new ExisteAlunoPorRfQuery(alunoGoogle.Codigo));
                if (alunoJaIncluido)
                {
                    await IniciarSyncGoogleCursosDoAlunoAsync(alunoGoogle);
                    return true;
                }

                await InserirAlunoGoogleAsync(alunoGoogle);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoParaIncluir?.Codigo, alunoParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                throw;
            }
        }

        private async Task InserirAlunoGoogleAsync(AlunoGoogle alunoGoogle)
        {
            try
            {
                var incluiuAlunoGoogle = await mediator.Send(new InserirAlunoGoogleCommand(alunoGoogle));
                if (!incluiuAlunoGoogle)
                {
                    await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                        $"Não foi possível incluir o professor no Google Classroom. {alunoGoogle}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                    return;
                }

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
            if (_deveExecutarIntegracao)
                alunoGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(alunoGoogle));
            await IniciarSyncGoogleCursosDoAlunoAsync(alunoGoogle);
        }

        private async Task IniciarSyncGoogleCursosDoAlunoAsync(AlunoGoogle alunoGoogle)
        {
            var publicarCursosDoAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoCursoSync, RotasRabbit.FilaAlunoCursoSync, alunoGoogle));
            if (!publicarCursosDoAluno)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                    $"O aluno RA{alunoGoogle.Codigo} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos cursos deste aluno.", UsuarioTipo.Professor, ExecucaoTipo.ProfessorCursoAdicionar));
            }
        }
    }
}
