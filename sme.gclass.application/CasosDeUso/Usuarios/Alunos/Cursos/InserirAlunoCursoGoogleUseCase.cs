using Google;
using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirAlunoCursoGoogleUseCase : IInserirAlunoCursoGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public InserirAlunoCursoGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o aluno no curso. A mensagem enviada é inválida.");

            var alunoCursoEolParaIncluir = JsonConvert.DeserializeObject<AlunoCursoEol>(mensagemRabbit.Mensagem.ToString());
            if (alunoCursoEolParaIncluir is null) return true;

            try
            {
                var aluno = await mediator.Send(new ObterAlunosPorCodigosQuery(alunoCursoEolParaIncluir.CodigoAluno));
                if (aluno is null || !aluno.Any()) 
                {
                    await LogarCursoUsuarioErro(mensagemRabbit, alunoCursoEolParaIncluir, $"O aluno de código '{alunoCursoEolParaIncluir.CodigoAluno}' não foi encontrado.");
                    return false;
                }

                var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(alunoCursoEolParaIncluir.TurmaId, alunoCursoEolParaIncluir.ComponenteCurricularId));
                if (curso is null)
                {
                    await LogarCursoErro(mensagemRabbit, alunoCursoEolParaIncluir, $"O curso não foi encontrado para a turma '{alunoCursoEolParaIncluir.TurmaId}' e para o componente curricular '{alunoCursoEolParaIncluir.ComponenteCurricularId}'.");
                    return false;
                }

                var existeProfessorCurso = await mediator.Send(new ExisteAlunoCursoGoogleQuery(aluno.First().Indice, curso.Id));
                if (existeProfessorCurso) return true;

                await InserirAlunoCursoGoogleAsync(aluno.First(), curso);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirCursoUsuarioErroCommand(alunoCursoEolParaIncluir.CodigoAluno, alunoCursoEolParaIncluir.TurmaId,
                    alunoCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.AlunoCursoAdicionar, ErroTipo.Interno,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}. StackTrace: {ex.StackTrace}."));
                throw;
            }
        }
        
        private async Task LogarCursoUsuarioErro(MensagemRabbit mensagemRabbit, AlunoCursoEol alunoCursoEolParaIncluir,
            string mensagem)
        {
            await mediator.Send(new IncluirCursoUsuarioErroCommand(null,
                alunoCursoEolParaIncluir.TurmaId,
                alunoCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno,
                $"ex.: {mensagem} <-> msg rabbit: {mensagemRabbit}"));
        }
        
        private async Task LogarCursoErro(MensagemRabbit mensagemRabbit, AlunoCursoEol alunoCursoEolParaIncluir,
            string mensagem)
        {
            await mediator.Send(new InserirCursoErroCommand(alunoCursoEolParaIncluir.TurmaId, alunoCursoEolParaIncluir.ComponenteCurricularId,
                $"ex.: {mensagem} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
        }

        private async Task InserirAlunoCursoGoogleAsync(AlunoGoogle alunoGoogle, CursoGoogle cursoGoogle)
        {
            var alunoCursoGoogle = new AlunoCursoGoogle(alunoGoogle.Indice, cursoGoogle.Id);

            try
            {
                var professorCursoSincronizado = await mediator.Send(new InserirAlunoCursoGoogleCommand(alunoCursoGoogle, alunoGoogle.Email));
                if (professorCursoSincronizado)
                {
                    await InserirAlunoCursoAsync(alunoCursoGoogle);
                }
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirAlunoCursoAsync(alunoCursoGoogle);
                else
                    throw;
            }
        }

        private async Task InserirAlunoCursoAsync(AlunoCursoGoogle alunoCursoGoogle)
        {
            alunoCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(alunoCursoGoogle.UsuarioId, alunoCursoGoogle.CursoId));
        }
    }
}
