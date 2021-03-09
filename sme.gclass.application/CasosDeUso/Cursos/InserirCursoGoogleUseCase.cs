using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGoogleUseCase : IIncluirCursoUseCase
    {
        private readonly IMediator mediator;

        public InserirCursoGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var cursoParaIncluir = JsonConvert.DeserializeObject<CursoEol>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluir is null) return true;

            try
            {
                var existeCurso = await mediator.Send(new ExisteCursoPorTurmaComponenteCurricularQuery(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId));
                if (existeCurso) return true;

                if (string.IsNullOrEmpty(cursoParaIncluir.Email))
                {
                    await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, string.Empty, null, ExecucaoTipo.CursoAdicionar, ErroTipo.CursoSemEmail));
                    return false;
                }

                var cursoGoogle = new CursoGoogle(
                    cursoParaIncluir.Nome,
                    cursoParaIncluir.Secao,
                    cursoParaIncluir.TurmaId,
                    cursoParaIncluir.ComponenteCurricularId,
                    cursoParaIncluir.Email);
                await mediator.Send(new InserirCursoGoogleCommand(cursoGoogle));

                await InserirCursoAsync(cursoGoogle);
                await IniciarSyncGoogleProfessoresDoCursoAsync(cursoGoogle);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new InserirCursoErroCommand(0, 0, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, Dominio.ExecucaoTipo.CursoAdicionar, Dominio.ErroTipo.Interno));
                throw;
            }            
        }

        private async Task InserirCursoAsync(CursoGoogle cursoGoogle)
        {
            try
            {
                await mediator.Send(new InserirCursoCommand(cursoGoogle));
            }
            catch
            {
                await mediator.Send(new ArquivarCursoGoogleCommand(cursoGoogle.Id));
                throw;
            }
        }

        private async Task IniciarSyncGoogleProfessoresDoCursoAsync(CursoGoogle cursoGoogle)
        {
            var publicarCursosDoProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoProfessorSync, RotasRabbit.FilaCursoProfessorSync, cursoGoogle));
            if (!publicarCursosDoProfessor)
            {
                await mediator.Send(new InserirCursoErroCommand(cursoGoogle.TurmaId, cursoGoogle.ComponenteCurricularId,
                    $"O curso Turma {cursoGoogle.TurmaId} e Componente Curricular {cursoGoogle.ComponenteCurricularId} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos professores deste curso.",
                    null, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno));
            }
        }
    }
}
