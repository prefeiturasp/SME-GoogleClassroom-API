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
    public class InserirProfessorGoogleUseCase : IInserirProfessorGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public InserirProfessorGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator;
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o professor. A mensagem enviada é inválida.");

            var professorParaIncluir = JsonConvert.DeserializeObject<ProfessorEol>(mensagemRabbit.Mensagem.ToString());
            if (professorParaIncluir is null) return true;

            try
            {
                var professorGoogle = new ProfessorGoogle(professorParaIncluir.Rf, professorParaIncluir.Nome, professorParaIncluir.Email, professorParaIncluir.OrganizationPath);

                var professorJaIncluido = await mediator.Send(new ExisteProfessorPorRfQuery(professorGoogle.Rf));
                if (professorJaIncluido)
                {
                    var professor = await mediator.Send(new ObterProfessoresPorRfsQuery(professorGoogle.Rf));
                    professorGoogle.GoogleClassroomId = professor?.FirstOrDefault()?.GoogleClassroomId;
                    await IniciarSyncGoogleCursosDoProfessorAsync(professorGoogle);
                    return true;
                }

                await InserirProfessorGoogleAsync(professorGoogle);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(professorParaIncluir?.Rf, professorParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}. StackTrace:{ex.StackTrace}.", UsuarioTipo.Professor, ExecucaoTipo.ProfessorAdicionar));
                throw;
            }
        }

        private async Task InserirProfessorGoogleAsync(ProfessorGoogle professorGoogle)
        {
            try
            {
                var professorSincronizado = await mediator.Send(new InserirProfessorGoogleCommand(professorGoogle));
                if (!professorSincronizado)
                {
                    await mediator.Send(new IncluirUsuarioErroCommand(professorGoogle?.Rf, professorGoogle?.Email,
                        $"Não foi possível incluir o professor no Google Classroom. {professorGoogle}", UsuarioTipo.Professor, ExecucaoTipo.ProfessorAdicionar));
                    return;
                }

                await InserirProfessorAsync(professorGoogle);
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirProfessorAsync(professorGoogle);
                else
                    throw;
            }
        }

        private async Task InserirProfessorAsync(ProfessorGoogle professorGoogle)
        {
            if (_deveExecutarIntegracao)
                professorGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(professorGoogle));
            await IniciarSyncGoogleCursosDoProfessorAsync(professorGoogle);
        }

        private async Task IniciarSyncGoogleCursosDoProfessorAsync(ProfessorGoogle professorGoogle)
        {
            //var publicarCursosDoProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoSync, RotasRabbit.FilaProfessorCursoSync, professorGoogle));
            var trataSyncGoogleCursosDoProfessorUseCase = new TrataSyncGoogleCursosDoProfessorUseCase(mediator);
            var publicarCursosDoProfessor = await trataSyncGoogleCursosDoProfessorUseCase.Executar(new MensagemRabbit(JsonConvert.SerializeObject(professorGoogle)));
            if (!publicarCursosDoProfessor)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(professorGoogle?.Rf, professorGoogle?.Email,
                    $"O professor RF {professorGoogle?.Rf} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos cursos deste professor.", UsuarioTipo.Professor, ExecucaoTipo.ProfessorCursoAdicionar));
            }
        }
    }
}