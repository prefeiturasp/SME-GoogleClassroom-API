using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarSincronizacaoAlunosDoCursoCelpGoogleUseCase : ITratarSincronizacaoAlunosDoCursoCelpGoogleUseCase
    {
        private readonly IMediator mediator;

        public TratarSincronizacaoAlunosDoCursoCelpGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtroDosAlunosParaIncluir = JsonConvert.DeserializeObject<FiltroCursoCelpDto>(mensagemRabbit.Mensagem.ToString());
            if (filtroDosAlunosParaIncluir is null)
            {
                await IncluirCursoParaIncluirAlunosComErroAsync(filtroDosAlunosParaIncluir, "Não foi possível iniciar a inclusão de alunos no curso no Google Classroom. O filtro de aluno não foi informado corretamente.");
                return true;
            }
            
            var alunosDoCursoParaIncluir = await mediator.Send(new ObterAlunosMatriculadosCelpQuery(filtroDosAlunosParaIncluir.ComponenteCurricularId, filtroDosAlunosParaIncluir.AnoLetivo,filtroDosAlunosParaIncluir.TurmaId ));
            if (alunosDoCursoParaIncluir == null || !alunosDoCursoParaIncluir.Any())
            {
                await IncluirCursoParaIncluirAlunosComErroAsync(filtroDosAlunosParaIncluir, $"Os alunos do componente curricular {filtroDosAlunosParaIncluir.ComponenteCurricularId} sa turma {filtroDosAlunosParaIncluir.TurmaId} e no ano letivo {filtroDosAlunosParaIncluir.AnoLetivo} não foram localizados.");
                return true;
            }

            foreach (var alunoDoCursoParaIncluir in alunosDoCursoParaIncluir)
            {
                try
                {
                    var alunoEol = new AlunoEol(int.Parse(alunoDoCursoParaIncluir.CodigoAluno.ToString()), alunoDoCursoParaIncluir.Nome,alunoDoCursoParaIncluir.NomeSocial,"/Alunos/FUNDAMENTAL", alunoDoCursoParaIncluir.DataNascimento);
                    
                    var incluirAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAlunoCelpIncluir, RotasRabbit.FilaGsaAlunoCelpIncluir, alunoEol));
                    if (!incluirAluno)
                        await IncluirAlunoComErroAsync(alunoDoCursoParaIncluir.CodigoAluno, ObterMensagemDeErro(alunoDoCursoParaIncluir.TurmaCodigo, alunoDoCursoParaIncluir.ComponenteCodigo,alunoDoCursoParaIncluir.CodigoAluno));

                    var alunoCursoEol = new AlunoCursoEol(alunoDoCursoParaIncluir.CodigoAluno,
                        alunoDoCursoParaIncluir.TurmaCodigo,
                        alunoDoCursoParaIncluir.ComponenteCodigo,
                        alunoDoCursoParaIncluir.NomeSocial,
                        alunoDoCursoParaIncluir.Nome,
                        alunoDoCursoParaIncluir.DataNascimento);
                    
                    var publicarAlunoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoAlunoCelpIncluir, RotasRabbit.FilaGsaCursoAlunoCelpIncluir, alunoCursoEol));
                    if (!publicarAlunoCurso)
                    {
                        await IncluirCursoDoAlunoComErroAsync(alunoDoCursoParaIncluir, filtroDosAlunosParaIncluir, 
                            ObterMensagemDeErro(alunoDoCursoParaIncluir.TurmaCodigo, alunoDoCursoParaIncluir.ComponenteCodigo, alunoDoCursoParaIncluir.CodigoAluno));
                    }
                }
                catch (Exception ex)
                {
                    await IncluirCursoDoAlunoComErroAsync(alunoDoCursoParaIncluir, filtroDosAlunosParaIncluir, 
                        ObterMensagemDeErro(alunoDoCursoParaIncluir.TurmaCodigo, alunoDoCursoParaIncluir.ComponenteCodigo, alunoDoCursoParaIncluir.CodigoAluno, ex));
                }
            }

            return true;
        }

        private async Task IncluirAlunoComErroAsync(long codigoAluno, string mensagem)
        {
            var alunoComErro = new IncluirUsuarioErroCommand(
                codigoAluno,
                String.Empty, 
                mensagem,
                UsuarioTipo.Aluno,
                ExecucaoTipo.AlunoAdicionar);
            await mediator.Send(alunoComErro);
        }
        
        private async Task IncluirCursoParaIncluirAlunosComErroAsync(FiltroCursoCelpDto filtroCursoCelpDto, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                filtroCursoCelpDto.TurmaId,
                filtroCursoCelpDto.ComponenteCurricularId,
                ExecucaoTipo.AlunoCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private async Task IncluirCursoDoAlunoComErroAsync(AlunoCelpDto cursoDoAlunoParaIncluirGoogle, FiltroCursoCelpDto filtroCursoCelpDto, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoDoAlunoParaIncluirGoogle.CodigoAluno,
                filtroCursoCelpDto.TurmaId,
                filtroCursoCelpDto.ComponenteCurricularId,
                ExecucaoTipo.AlunoCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private string ObterMensagemDeErro(long turmaId, long componenteCurricularId, long codigoAluno, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o curso Celp para [TurmaId:{turmaId}, ComponenteCurricularId:{componenteCurricularId}] aluno RA{codigoAluno} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }
    }
}