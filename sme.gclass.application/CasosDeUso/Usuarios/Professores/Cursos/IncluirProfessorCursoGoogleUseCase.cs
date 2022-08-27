using Google;
using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirProfessorCursoGoogleUseCase : IIncluirProfessorCursoGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public IncluirProfessorCursoGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
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
                if (professor is null || !professor.Any())
                {
                    await LogarCursoUsuarioErro(mensagemRabbit, professorCursoEolParaIncluir, $"O professor de Rf '{professorCursoEolParaIncluir.Rf}' não foi encontrado.");
                    return false;
                }

                var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(professorCursoEolParaIncluir.TurmaId, professorCursoEolParaIncluir.ComponenteCurricularId));
                if (curso is null)
                {
                    await LogarCursoErro(mensagemRabbit, professorCursoEolParaIncluir, $"Não foi encontrado curso para a turma '{professorCursoEolParaIncluir.TurmaId}' e para o componente curricular '{professorCursoEolParaIncluir.ComponenteCurricularId}'.");
                    return false;
                }

                var existeProfessorCursoLocal = await mediator.Send(new ExisteProfessorCursoGoogleQuery(professor.First().Indice, curso.Id));
                if (!existeProfessorCursoLocal)
                    await InserirProfessorCursoGoogleAsync(professor.First(), curso, existeProfessorCursoLocal);

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

        private async Task LogarCursoUsuarioErro(MensagemRabbit mensagemRabbit, ProfessorCursoEol professorCursoEolParaIncluir,
            string mensagem)
        {
            await mediator.Send(new IncluirCursoUsuarioErroCommand(professorCursoEolParaIncluir.Rf,
                professorCursoEolParaIncluir.TurmaId,
                professorCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno,
                $"ex.: {mensagem} <-> msg rabbit: {mensagemRabbit}"));
        }
        
        private async Task LogarCursoErro(MensagemRabbit mensagemRabbit, ProfessorCursoEol professorCursoEolParaIncluir,
            string mensagem)
        {
            await mediator.Send(new InserirCursoErroCommand(professorCursoEolParaIncluir.TurmaId, professorCursoEolParaIncluir.ComponenteCurricularId,
                $"ex.: {mensagem} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
        }

        private static bool DonoDoCursoEhGestor(UsuarioGoogleDto usuarioAtual)
        {
            return usuarioAtual.UsuarioTipo == 3 ? true : false;
        }

        private async Task InserirProfessorCursoGoogleAsync(ProfessorGoogle professorGoogle, CursoGoogle cursoGoogle, bool existeProfessorCursoLocal)
        {
            var professorCursoGoogle = new ProfessorCursoGoogle(professorGoogle.Indice, cursoGoogle.Id);

            try
            {
                var professorCursoSincronizado = !existeProfessorCursoLocal && await mediator.Send(new InserirProfessorCursoGoogleCommand(cursoGoogle.Id, professorGoogle.Email));
                if (professorCursoSincronizado && !existeProfessorCursoLocal)
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
            professorCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(professorCursoGoogle.UsuarioId, professorCursoGoogle.CursoId));
        }
    }
}
