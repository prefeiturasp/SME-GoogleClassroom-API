using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
                await mediator.Send(new InserirProfessorCursoGoogleCommand(professorCursoEolParaIncluir));
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
