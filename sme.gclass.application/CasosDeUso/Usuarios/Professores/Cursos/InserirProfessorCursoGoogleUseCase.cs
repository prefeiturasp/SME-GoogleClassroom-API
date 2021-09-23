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
                if (!existeProfessorCursoLocal)
                    //await InserirProfessorCursoGoogleAsync(professor.First(), curso, existeProfessorCursoLocal);

                await AtribuirProfessorComoDonoDoCurso(professorCursoEolParaIncluir, professor, curso);

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

        private async Task AtribuirProfessorComoDonoDoCurso(ProfessorCursoEol professorCursoEolParaIncluir, IEnumerable<ProfessorGoogle> professor, CursoGoogle curso)
        {
            bool ehGestor = false;

            var funcionariosDoCurso = await mediator.Send(new ObterFuncionariosPorCursoQuery(curso.Id));

            var usuarioAtual = await mediator.Send(new ObterUsuarioPorEmailQuery(curso.Email));

            ehGestor = DonoDoCursoEhGestor(usuarioAtual, ehGestor);

            if (professorCursoEolParaIncluir.Modalidade != 0 && professorCursoEolParaIncluir.Modalidade != 1 && ehGestor)
            {
                var usuario = await mediator.Send(new ObterUsuarioGoogleQuery(professor.First().Email));
                var retornoGoogle = await mediator.Send(new AtribuirDonoCursoGoogleCommand(curso.Id, usuario.Id));
                if (retornoGoogle)
                {
                    curso.Email = professor.First().Email;
                    await mediator.Send(new AlterarCursoCommand(curso));
                }
            }
        }

        private static bool DonoDoCursoEhGestor(UsuarioGoogleDto usuarioAtual, bool ehAdmin)
        {
            return usuarioAtual.UsuarioTipo == 3 ? true : false;
        }

        private async Task InserirProfessorCursoGoogleAsync(ProfessorGoogle professorGoogle, CursoGoogle cursoGoogle, bool existeProfessorCursoLocal)
        {
            var professorCursoGoogle = new ProfessorCursoGoogle(professorGoogle.Indice, cursoGoogle.Id);

            try
            {
                var professorCursoSincronizado = !existeProfessorCursoLocal && await mediator.Send(new InserirProfessorCursoGoogleCommand(professorCursoGoogle, professorGoogle.Email));
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
