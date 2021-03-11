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
            var alunoCursoEolParaIncluir = JsonConvert.DeserializeObject<AlunoCursoEol>(mensagemRabbit.Mensagem.ToString());
            if (alunoCursoEolParaIncluir is null) return true;

            try
            {
                var aluno = await mediator.Send(new ObterAlunosPorCodigosQuery(alunoCursoEolParaIncluir.CodigoAluno));
                if (aluno is null || !aluno.Any()) return false;

                var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(alunoCursoEolParaIncluir.TurmaId, alunoCursoEolParaIncluir.ComponenteCurricularId));
                if (curso is null) return false;

                var existeProfessorCurso = await mediator.Send(new ExisteAlunoCursoGoogleQuery(alunoCursoEolParaIncluir.CodigoAluno, curso.Id));
                if (existeProfessorCurso) return true;

                var alunoCursoGoogle = new AlunoCursoGoogle(aluno.First().Indice, curso.Id);

                await mediator.Send(new InserirAlunoCursoGoogleCommand(alunoCursoGoogle, aluno.First().Email));
                if (_deveExecutarIntegracao) alunoCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(alunoCursoGoogle.UsuarioId, alunoCursoGoogle.CursoId));

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirCursoUsuarioErroCommand(alunoCursoEolParaIncluir.CodigoAluno, alunoCursoEolParaIncluir.TurmaId,
                    alunoCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}"));
                throw;
            }
        }
    }
}
