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
                // TO DO: Remover ao subir para produção
                var professorJaIncluido = await mediator.Send(new ExisteProfessorPorRfQuery(professorParaIncluir.Rf));
                if (professorJaIncluido) return true;

                var professorGoogle = new ProfessorGoogle(professorParaIncluir.Rf, professorParaIncluir.Nome, professorParaIncluir.Email, professorParaIncluir.OrganizationPath);
                await mediator.Send(new InserirProfessorGoogleCommand(professorGoogle));

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(professorParaIncluir?.Rf, professorParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Professor, ExecucaoTipo.ProfessorAdicionar, DateTime.Now));
                throw;
            }
        }
    }
}