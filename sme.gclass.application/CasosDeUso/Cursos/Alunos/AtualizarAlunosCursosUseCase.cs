using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarAlunosCursosUseCase : IAtualizarAlunosCursosUseCase
    {        
        private readonly IObterCursosAlunosParaIncluirGoogleUseCase obterCursosAlunosParaIncluirGoogleUseCase;
        private readonly IObterCursosCadastradosUseCase obterCursosCadastradosUseCase;
        private readonly IEnviarRequisicaoAtribuirAlunoCursoUseCase enviarRequisicaoAtribuirAlunoCursoUseCase;

        public AtualizarAlunosCursosUseCase(IObterCursosAlunosParaIncluirGoogleUseCase obterCursosAlunosParaIncluirGoogleUseCase, 
                                            IObterCursosCadastradosUseCase obterCursosCadastradosUseCase,
                                            IEnviarRequisicaoAtribuirAlunoCursoUseCase enviarRequisicaoAtribuirAlunoCursoUseCase)
        {           
            this.obterCursosAlunosParaIncluirGoogleUseCase = obterCursosAlunosParaIncluirGoogleUseCase;
            this.obterCursosCadastradosUseCase = obterCursosCadastradosUseCase;
            this.enviarRequisicaoAtribuirAlunoCursoUseCase = enviarRequisicaoAtribuirAlunoCursoUseCase;
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
                        var alunoDto = new AtribuirAlunoCursoDto
                        {
                            CodigoAluno = aluno.CodigoAluno,
                            TurmaId = aluno.TurmaId,
                            ComponenteCurricularId = aluno.ComponenteCurricularId
                        };
                        await enviarRequisicaoAtribuirAlunoCursoUseCase.Executar(alunoDto);                        
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Erro ao enviar a atualização de alunos do curso: [ID:{cursoGoogle.Id}] - Nome:{cursoGoogle.Nome} -- Erro:{ex.Message} -- {ex.StackTrace}.");
                }
            }

            return true;
        }
    }
}
