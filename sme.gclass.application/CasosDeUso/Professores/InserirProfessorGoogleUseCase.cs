using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorGoogleUseCase : IInserirProfessorGoogleUseCase
    {
        private readonly IMediator mediator;

        public InserirProfessorGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var professorParaIncluir = JsonConvert.DeserializeObject<ProfessorEol>(mensagemRabbit.Mensagem.ToString());
            if (professorParaIncluir is null) return true;

            try
            {
                var professorJaIncluido = await mediator.Send(new ExisteProfessorPorRfQuery(professorParaIncluir.Rf));
                if (professorJaIncluido) return true;

                var professorGoogle = new ProfessorGoogle(professorParaIncluir.Rf, professorParaIncluir.Nome, professorParaIncluir.Email, professorParaIncluir.OrganizationPath);
                await mediator.Send(new InserirProfessorGoogleCommand(professorGoogle));
                professorGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(professorGoogle));

                await IniciarSyncGoogleCursosDoProfessorAsync(professorGoogle);

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(professorParaIncluir?.Rf, professorParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Professor, ExecucaoTipo.ProfessorAdicionar, DateTime.Now));
                throw;
            }
        }

        private async Task IniciarSyncGoogleCursosDoProfessorAsync(ProfessorGoogle professorGoogle)
        {
            var publicarCursosDoProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoSync, RotasRabbit.FilaProfessorCursoSync, professorGoogle));
            if(!publicarCursosDoProfessor)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(professorGoogle?.Rf, professorGoogle?.Email,
                    $"O professor RF{professorGoogle.Rf} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos cursos deste professor.", UsuarioTipo.Professor, ExecucaoTipo.ProfessorCursoAdicionar, DateTime.Now));
            }
        }
    }
}