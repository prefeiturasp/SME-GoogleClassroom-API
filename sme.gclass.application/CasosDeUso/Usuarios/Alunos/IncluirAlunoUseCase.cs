using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAlunoUseCase : IIncluirAlunoUseCase
    {
        private readonly IMediator mediator;

        public IncluirAlunoUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o aluno. A mensagem enviada é inválida.");

            var filtro = mensagemRabbit.ObterObjetoMensagem<FiltroAlunoDto>();
            var alunoParaIncluir = filtro.AlunoEol;
            if (alunoParaIncluir is null)
                throw new NegocioException("Não foi possível incluir o aluno. A mensagem enviada é inválida.");

            try
            {
                var alunoJaIncluido = await mediator.Send(new ObterAlunosPorCodigosQuery(alunoParaIncluir.Codigo));
                var googleClassroomId = alunoJaIncluido.First().GoogleClassroomId;
                if (alunoJaIncluido != null && alunoJaIncluido.Any() && googleClassroomId != null && !googleClassroomId.Equals(alunoParaIncluir.Codigo.ToString()))
                {
                    await AtualizarAlunoGoogleSync(filtro, alunoJaIncluido.First());
                    return true;
                }

                alunoParaIncluir = await mediator.Send(new VerificarEmailExistenteAlunoQuery(alunoParaIncluir));
                var alunoGoogle = new AlunoGoogle(alunoParaIncluir.Codigo, alunoParaIncluir.Nome, alunoParaIncluir.Email, alunoParaIncluir.OrganizationPath);

                await InserirAlunoGoogleAsync(alunoGoogle, alunoJaIncluido?.FirstOrDefault(), filtro);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoParaIncluir?.Codigo, alunoParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}. StackTrace:{ex.StackTrace}.", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                throw;
            }
        }

        private async Task InserirAlunoGoogleAsync(AlunoGoogle alunoGoogle, AlunoGoogle alunoJaIncluido, FiltroAlunoDto filtro)
        {
            var alunoEol = filtro.AlunoEol;
            try
            {
                var incluiuAlunoGoogle = await mediator.Send(new InserirAlunoGoogleCommand(alunoGoogle));
                if (!incluiuAlunoGoogle)
                {
                    await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                        $"Não foi possível incluir o aluno no Google Classroom. {alunoGoogle}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                    return;
                }

                if (alunoJaIncluido != null)
                {
                    alunoJaIncluido.GoogleClassroomId = alunoGoogle.GoogleClassroomId;
                    await AtualizarAlunoGoogleSync(filtro, alunoJaIncluido);
                }
                else
                    await InserirAlunoAsync(alunoGoogle, filtro);
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirAlunoAsync(alunoGoogle, filtro);
                else
                    throw;
            }
        }

        private async Task InserirAlunoAsync(AlunoGoogle alunoGoogle, FiltroAlunoDto filtro)
        {
            alunoGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(alunoGoogle)); 
            var filtroAlunoCurso = new FiltroAlunoCursoDto(alunoGoogle, filtro.AnoLetivo, filtro.TiposUes, filtro.Ues, filtro.Turmas);
            await IniciarSyncGoogleCursosDoAlunoAsync(filtroAlunoCurso);
        }

        private async Task AtualizarAlunoGoogleSync(FiltroAlunoDto filtro, AlunoGoogle alunoGoogle)
        {
            var alunoEol = filtro.AlunoEol;
            alunoGoogle.Nome = alunoEol.Nome;
            
            alunoGoogle.OrganizationPath = alunoEol.OrganizationPath;

            var incluiuAlunoGoogle = await mediator.Send(new AtualizarAlunoGoogleCommand(alunoGoogle));
            if (!incluiuAlunoGoogle)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                    $"Não foi possível atualizar o aluno no Google Classroom. {alunoGoogle}", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                return;
            }

            var usuarioAlterado = await mediator.Send(new AtualizarUsuarioCommand(alunoGoogle.Indice, alunoGoogle.Nome, alunoGoogle.OrganizationPath));
            if (!usuarioAlterado)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                    $"Não foi possível atualizar o aluno {alunoGoogle} no Google Classroom. O aluno não foi encontrado na base.", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                return;
            }

            var idAlterado = await mediator.Send(new AtualizarUsuarioGoogleClassroomIdCommand(alunoGoogle.Indice, alunoGoogle.GoogleClassroomId));
            if (!idAlterado)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoGoogle?.Codigo, alunoGoogle?.Email,
                    $"Não foi possível atualizar o Id do aluno {alunoGoogle} no Google Classroom.", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar));
                return;
            }
            var filtroAlunoCurso = new FiltroAlunoCursoDto(alunoGoogle, filtro.AnoLetivo, filtro.TiposUes, filtro.Ues, filtro.Turmas);
            await IniciarSyncGoogleCursosDoAlunoAsync(filtroAlunoCurso);
        }

        private async Task IniciarSyncGoogleCursosDoAlunoAsync(FiltroAlunoCursoDto filtro)
        {
            var publicarCursosDoAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoCursoSync, RotasRabbit.FilaAlunoCursoSync, filtro));
            if (!publicarCursosDoAluno)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(filtro.AlunoGoogle?.Codigo, filtro.AlunoGoogle?.Email,
                    $"O aluno RA{filtro.AlunoGoogle.Codigo} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos cursos deste aluno.", UsuarioTipo.Professor, ExecucaoTipo.ProfessorCursoAdicionar));
            }
        }
    }
}
