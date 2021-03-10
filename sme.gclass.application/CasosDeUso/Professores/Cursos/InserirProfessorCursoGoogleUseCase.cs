using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleUseCase : IInserirProfessorCursoGoogleUseCase
    {
        private readonly IMediator mediator;

        public InserirProfessorCursoGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var professorCursoEolParaIncluir = JsonConvert.DeserializeObject<ProfessorCursoEol>(mensagemRabbit.Mensagem.ToString());
            if (professorCursoEolParaIncluir is null) return true;

            try
            {
                var professor = await mediator.Send(new ObterProfessoresPorRfsQuery(professorCursoEolParaIncluir.Rf));
                if (professor is null || !professor.Any()) return false;

                var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(professorCursoEolParaIncluir.TurmaId, professorCursoEolParaIncluir.ComponenteCurricularId));
                if (curso is null) return false;

                var existeProfessorCurso = await mediator.Send(new ExisteProfessorCursoGoogleQuery(professorCursoEolParaIncluir.Rf, curso.Id));
                if (existeProfessorCurso) return true;

                var professorCursoGoogle = new ProfessorCursoGoogle(professor.First().Indice, curso.Id);

                await mediator.Send(new InserirProfessorCursoGoogleCommand(professorCursoGoogle, professor.First().Email));
                professorCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(professorCursoGoogle.UsuarioId, professorCursoGoogle.CursoId));

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirCursoUsuarioErroCommand(professorCursoEolParaIncluir.Rf, professorCursoEolParaIncluir.TurmaId,
                    professorCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}"));
                throw;
            }
        }
    }
}
