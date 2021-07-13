using Google;
using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Commands.Usuarios.Professores.ObterProfessorCursoGoogle;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleUseCase : IInserirProfessorCursoGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public InserirProfessorCursoGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
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

                var existeProfessorCursoLocal = await mediator.Send(new ExisteProfessorCursoGoogleQuery(professor.First().Indice, curso.Id));
                var existeProfessorCursoGoogle = await mediator.Send(new ExisteProfessorCursoGoogleCommand(curso.Id, professor.First().Email));
                if (existeProfessorCursoLocal && existeProfessorCursoGoogle) return true;

                await InserirProfessorCursoGoogleAsync(professor.First(), curso, existeProfessorCursoLocal, existeProfessorCursoGoogle);

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

        private async Task InserirProfessorCursoGoogleAsync(ProfessorGoogle professorGoogle, CursoGoogle cursoGoogle, bool existeProfessorCursoLocal, bool existeProfessorCursoGoogle)
        {
            var professorCursoGoogle = new ProfessorCursoGoogle(professorGoogle.Indice, cursoGoogle.Id);

            try
            {
                var professorCursoSincronizado = !existeProfessorCursoGoogle && await mediator.Send(new InserirProfessorCursoGoogleCommand(professorCursoGoogle, professorGoogle.Email));
                if(professorCursoSincronizado && !existeProfessorCursoLocal)
                {
                    await InserirProfessorCursoAsync(professorCursoGoogle);
                }
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirProfessorCursoAsync(professorCursoGoogle);
                else
                    throw;
            }
        }

        private async Task InserirProfessorCursoAsync(ProfessorCursoGoogle professorCursoGoogle)
        {
            if (!_deveExecutarIntegracao) return;
            professorCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(professorCursoGoogle.UsuarioId, professorCursoGoogle.CursoId));
        }
    }
}
