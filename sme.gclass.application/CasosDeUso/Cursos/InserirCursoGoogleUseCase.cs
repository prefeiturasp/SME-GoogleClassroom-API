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
        private readonly bool _deveExecutarIntegracao;

        public InserirCursoGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o curso. A mensagem enviada é inválida.");

            var cursoParaIncluir = JsonConvert.DeserializeObject<CursoEol>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluir is null) return true;

            try
            {
                if (string.IsNullOrWhiteSpace(cursoParaIncluir.Email))
                {
                    await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, string.Empty, null, ExecucaoTipo.CursoAdicionar, ErroTipo.CursoSemEmail));
                    return false;
                }

                var cursoGoogle = new CursoGoogle(
                    cursoParaIncluir.Nome,
                    cursoParaIncluir.Secao,
                    cursoParaIncluir.TurmaId,
                    cursoParaIncluir.ComponenteCurricularId,
                    cursoParaIncluir.Email,
                    cursoParaIncluir.TurmaTipo);

                var existeCurso = await mediator.Send(new ExisteCursoPorTurmaComponenteCurricularQuery(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId));
                if (existeCurso)
                {
                    await IniciarSyncGoogleUsuariosDoCursoAsync(cursoGoogle,cursoParaIncluir.TipoEscola);
                    return true;
                }

                await mediator.Send(new InserirCursoGoogleCommand(cursoGoogle));

                await InserirCursoAsync(cursoGoogle);
                await IniciarSyncGoogleUsuariosDoCursoAsync(cursoGoogle,cursoParaIncluir.TipoEscola);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
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

        private async Task IniciarSyncGoogleUsuariosDoCursoAsync(CursoGoogle cursoGoogle, TipoEscola tipoEscola)
        {
            await IniciarSyncGoogleProfessoresDoCursoAsync(cursoGoogle);
            
            await IniciarSyncGoogleAlunosDoCursoAsync(cursoGoogle);
            
            if (cursoGoogle.TurmaTipo != TurmaTipo.Programa)
                await IniciarSyncGoogleFuncionariosDoCursoAsync(cursoGoogle);
            
            if (tipoEscola == TipoEscola.Celp)
                await IniciarSyncGoogleFuncionariosDoCursoCelpAsync(cursoGoogle);
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

        private async Task IniciarSyncGoogleAlunosDoCursoAsync(CursoGoogle cursoGoogle)
        {
            var publicarCursosDoProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoAlunoSync, RotasRabbit.FilaCursoAlunoSync, cursoGoogle));
            if (!publicarCursosDoProfessor)
            {
                await mediator.Send(new InserirCursoErroCommand(cursoGoogle.TurmaId, cursoGoogle.ComponenteCurricularId,
                    $"O curso Turma {cursoGoogle.TurmaId} e Componente Curricular {cursoGoogle.ComponenteCurricularId} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos alunos deste curso.",
                    null, ExecucaoTipo.AlunoCursoAdicionar, ErroTipo.Interno));
            }
        }

        private async Task IniciarSyncGoogleFuncionariosDoCursoAsync(CursoGoogle cursoGoogle)
        {
            var publicarFuncionariosDoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoFuncionarioSync, RotasRabbit.FilaCursoFuncionarioSync, cursoGoogle));
            if (!publicarFuncionariosDoCurso)
            {
                await mediator.Send(new InserirCursoErroCommand(cursoGoogle.TurmaId, cursoGoogle.ComponenteCurricularId,
                    $"O curso Turma {cursoGoogle.TurmaId} e Componente Curricular {cursoGoogle.ComponenteCurricularId} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos funcionários deste curso.",
                    null, ExecucaoTipo.FuncionarioCursoAdicionar, ErroTipo.Interno));
            }
        }
        
        private async Task IniciarSyncGoogleFuncionariosDoCursoCelpAsync(CursoGoogle cursoGoogle)
        {
            var publicarFuncionariosDoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoFuncionarioCelpSync, RotasRabbit.FilaCursoFuncionarioCelpSync, cursoGoogle));
            if (!publicarFuncionariosDoCurso)
            {
                await mediator.Send(new InserirCursoErroCommand(cursoGoogle.TurmaId, cursoGoogle.ComponenteCurricularId,
                    $"O curso Turma {cursoGoogle.TurmaId} e Componente Curricular {cursoGoogle.ComponenteCurricularId} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos funcionários CELP deste curso.",
                    null, ExecucaoTipo.FuncionarioCursoAdicionar, ErroTipo.Interno));
            }
        }
    }
}
