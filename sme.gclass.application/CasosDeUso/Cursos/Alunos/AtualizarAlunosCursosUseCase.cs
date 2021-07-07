using Google;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarAlunosCursosUseCase : IAtualizarAlunosCursosUseCase
    {
        private readonly IMediator mediator;
        private readonly IObterCursosAlunosParaIncluirGoogleUseCase obterCursosAlunosParaIncluirGoogleUseCase;
        private readonly IObterCursosCadastradosUseCase obterCursosCadastradosUseCase;

        public AtualizarAlunosCursosUseCase(IMediator mediator, IObterCursosAlunosParaIncluirGoogleUseCase obterCursosAlunosParaIncluirGoogleUseCase, IObterCursosCadastradosUseCase obterCursosCadastradosUseCase)
        {
            this.mediator = mediator;
            this.obterCursosAlunosParaIncluirGoogleUseCase = obterCursosAlunosParaIncluirGoogleUseCase;
            this.obterCursosCadastradosUseCase = obterCursosCadastradosUseCase;
        }

        public async Task<bool> Executar(long? turmaId, long? componenteCurricularId)
        {

            FiltroObterCursosCadastradosDto filtro = new FiltroObterCursosCadastradosDto
            {
                TurmaId = turmaId,
                ComponenteCurricularId = componenteCurricularId,
                PaginaNumero = 1,
                RegistrosQuantidade = 500000
            };

            var cursosCadastrados = await obterCursosCadastradosUseCase.Executar(filtro);

            foreach (var cursoGoogle in cursosCadastrados.Items)
            {
                try
                {
                    var alunosCurso = await obterCursosAlunosParaIncluirGoogleUseCase.Executar(cursoGoogle.TurmaId, cursoGoogle.ComponenteCurricularId);
                    foreach (var aluno in alunosCurso)
                    {
                        var alunoConsulta = await mediator.Send(new ObterAlunosPorCodigosQuery(aluno.CodigoAluno));
                        if (aluno is null || !alunoConsulta.Any()) continue;

                        var existeProfessorCurso = await mediator.Send(new ExisteAlunoCursoGoogleQuery(alunoConsulta.First().Indice, cursoGoogle.Id));
                        if (existeProfessorCurso) continue;

                        await InserirAlunoCursoGoogleAsync(alunoConsulta.First(), cursoGoogle);
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Erro ao enviar a atualização de alunos do curso: [ID:{cursoGoogle.Id}] - Nome:{cursoGoogle.Nome} -- Erro:{ex.Message} -- {ex.StackTrace}.");
                }
            }

            return true;
        }
        private async Task InserirAlunoCursoGoogleAsync(AlunoGoogle alunoGoogle, CursoGoogle cursoGoogle)
        {
            var alunoCursoGoogle = new AlunoCursoGoogle(alunoGoogle.Indice, cursoGoogle.Id);

            try
            {
                var professorCursoSincronizado = await mediator.Send(new InserirAlunoCursoGoogleCommand(alunoCursoGoogle, alunoGoogle.Email));
                if (professorCursoSincronizado)
                {
                    await InserirAlunoCursoAsync(alunoCursoGoogle);
                }
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirAlunoCursoAsync(alunoCursoGoogle);
                else
                    throw;
            }
        }

        private async Task InserirAlunoCursoAsync(AlunoCursoGoogle alunoCursoGoogle)
        {
            alunoCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(alunoCursoGoogle.UsuarioId, alunoCursoGoogle.CursoId));
        }
    }
}
