using Google;
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
    public class RemoverProfessorCursoGoogleUseCase : IRemoverProfessorCursoGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public RemoverProfessorCursoGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o professor no curso. A mensagem enviada é inválida.");

            var professorCursoEolParaIncluir = JsonConvert.DeserializeObject<ProfessorCursoEol>(mensagemRabbit.Mensagem.ToString());
            if (professorCursoEolParaIncluir is null) return true;

            try
            {
                var professor = await mediator.Send(new ObterProfessoresPorRfsQuery(professorCursoEolParaIncluir.Rf));
                if (professor is null || !professor.Any()) return false;

                var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(professorCursoEolParaIncluir.TurmaId, professorCursoEolParaIncluir.ComponenteCurricularId));
                if (curso is null) return false;

                var professorCurso = await mediator.Send(new ObterPorUsuarioIdCursoIdQuery(professor.First().Indice, curso.Id));
                if (professorCurso is null) return true;

                await RemoverProfessorCursoGoogleAsync(professor.First(), professorCurso);

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirCursoUsuarioErroCommand(professorCursoEolParaIncluir.Rf, professorCursoEolParaIncluir.TurmaId,
                    professorCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}. StackTrace: {ex.StackTrace}."));
                throw;
            }
        }

        private async Task RemoverProfessorCursoGoogleAsync(ProfessorGoogle professorGoogle, CursoUsuario cursoUsuario)
        {
            try
            {
                var professorCursoRemovido = await mediator.Send(new RemoverProfessorCursoGoogleCommand(cursoUsuario.CursoId, professorGoogle.Email));
                if (professorCursoRemovido)
                {
                    await RemoverProfessorCursoAsync(cursoUsuario);
                }
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await RemoverProfessorCursoAsync(cursoUsuario);
                else
                    throw;
            }
        }

        private async Task RemoverProfessorCursoAsync(CursoUsuario cursoUsuario)
        {
            if (!_deveExecutarIntegracao) return;
            if (!await mediator.Send(new RemoverCursoUsuarioCommand(cursoUsuario.Id)))
            {
                throw new NegocioException($"Não foi possível remover a atribuição do professor do curso {cursoUsuario.CursoId}");
            }
        }
    }
}