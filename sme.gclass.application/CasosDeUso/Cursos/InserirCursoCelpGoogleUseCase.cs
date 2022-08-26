using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoCelpGoogleUseCase : IInserirCursoCelpGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public InserirCursoCelpGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o curso celp. A mensagem enviada é inválida.");

            var cursoParaIncluir = JsonConvert.DeserializeObject<FiltroCursoCelpDto>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluir is null) return true;

            try
            {
                FuncionarioGoogle professorDoCurso = null;
                
                if (string.IsNullOrWhiteSpace(cursoParaIncluir.EmailProfessor))
                {
                    await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, 
                        string.Empty, null, ExecucaoTipo.CursoAdicionar, ErroTipo.CursoSemEmail));
                    return false;
                }
                else
                {
                    var professoresDoCurso = await mediator.Send(new ObterFuncionariosGooglePorEmailQuery(cursoParaIncluir.EmailProfessor));
                    professorDoCurso = professoresDoCurso.FirstOrDefault();
                }

                var cursoGoogle = new CursoGoogle(
                    cursoParaIncluir.ComponenteCurricularNome,
                    cursoParaIncluir.Secao,
                    cursoParaIncluir.TurmaId,
                    cursoParaIncluir.ComponenteCurricularId,
                    cursoParaIncluir.EmailProfessor,
                    (TurmaTipo)cursoParaIncluir.TipoId);

                var existeCurso = await mediator.Send(new ExisteCursoPorTurmaComponenteCurricularQuery(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId));
                if (existeCurso)
                {
                    await IniciarSyncGoogleUsuariosDoCursoAsync(cursoParaIncluir, professorDoCurso);
                    return true;
                }

                await mediator.Send(new InserirCursoGoogleCommand(cursoGoogle));

                await InserirCursoAsync(cursoGoogle);
                await IniciarSyncGoogleUsuariosDoCursoAsync(cursoParaIncluir, professorDoCurso);
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

        private async Task IniciarSyncGoogleUsuariosDoCursoAsync(FiltroCursoCelpDto filtroCursoCelpDto, FuncionarioGoogle professorDoCurso)
        {
            await IniciarSyncGoogleProfessoresDoCursoCelpAsync(new ProfessorCursoEol()
            {
                Rf = professorDoCurso.Rf.Value,
                TurmaId = filtroCursoCelpDto.TurmaId,
                ComponenteCurricularId = filtroCursoCelpDto.ComponenteCurricularId,
            });
            
            await IniciarSyncGoogleAlunosDoCursoCelpAsync(filtroCursoCelpDto);
            
            await IniciarSyncGoogleFuncionariosDoCursoCelpAsync( new FiltroFuncionarioDoCursoCelpDto()
            {
                Indice = filtroCursoCelpDto.IndiceCoordenador,
                Rf = filtroCursoCelpDto.RfCoordenador,
                TurmaId = filtroCursoCelpDto.TurmaId,
                ComponenteCurricularId = filtroCursoCelpDto.ComponenteCurricularId,
                EmailCoordenadorParametro = filtroCursoCelpDto.EmailCoordenador
            });
        }

        private async Task IniciarSyncGoogleProfessoresDoCursoCelpAsync(ProfessorCursoEol professorCursoEol)
        {
            var publicarCursosDoProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoIncluir, RotasRabbit.FilaProfessorCursoIncluir, professorCursoEol));
            if (!publicarCursosDoProfessor)
            {
                await mediator.Send(new InserirCursoErroCommand(professorCursoEol.TurmaId, professorCursoEol.ComponenteCurricularId,
                    $"O curso Turma {professorCursoEol.TurmaId} e Componente Curricular {professorCursoEol.ComponenteCurricularId} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos professores deste curso.",
                    null, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno));
            }
        }

        private async Task IniciarSyncGoogleAlunosDoCursoCelpAsync(FiltroCursoCelpDto filtroCursoCelpDto)
        {
            var publicarCursosDoProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursosAlunosCelpSync, RotasRabbit.FilaGsaCursosAlunosCelpSync, filtroCursoCelpDto));
            if (!publicarCursosDoProfessor)
            {
                await mediator.Send(new InserirCursoErroCommand(filtroCursoCelpDto.TurmaId, filtroCursoCelpDto.ComponenteCurricularId,
                    $"O curso Turma {filtroCursoCelpDto.TurmaId} e Componente Curricular {filtroCursoCelpDto.ComponenteCurricularId} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos alunos deste curso.",
                    null, ExecucaoTipo.AlunoCursoAdicionar, ErroTipo.Interno));
            }
        }
       
        private async Task IniciarSyncGoogleFuncionariosDoCursoCelpAsync(FiltroFuncionarioDoCursoCelpDto filtroFuncionarioDoCursoCelpDto)
        {
            var publicarFuncionariosDoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir, RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir, filtroFuncionarioDoCursoCelpDto));
            if (!publicarFuncionariosDoCurso)
            {
                await mediator.Send(new InserirCursoErroCommand(filtroFuncionarioDoCursoCelpDto.TurmaId, filtroFuncionarioDoCursoCelpDto.ComponenteCurricularId,
                    $"O curso Turma {filtroFuncionarioDoCursoCelpDto.TurmaId} e Componente Curricular {filtroFuncionarioDoCursoCelpDto.ComponenteCurricularId} foi incluído com sucesso, mas não foi possível iniciar a sincronização dos funcionários CELP deste curso.",
                    null, ExecucaoTipo.FuncionarioCursoAdicionar, ErroTipo.Interno));
            }
        }
    }
}
