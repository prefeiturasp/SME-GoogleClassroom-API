using System;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarSincronizacaoCursosCelpTurmaUseCase : ITratarSincronizacaoCursosCelpTurmaUseCase
    {
        private readonly IMediator mediator;

        public TratarSincronizacaoCursosCelpTurmaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            try
            {
                if (mensagem?.Mensagem is null)
                    throw new NegocioException("Não foi possível iniciar a sincronização com GSA dos cursos do CELP por turma.");

                var filtro = mensagem.ObterObjetoMensagem<FiltroTurmaComponenteCurricularUeDto>();
                
                var cursoDoAlunoParaIncluir = ObterCursoEol(filtro);
                
                try
                {
                    var publicarGradeAlunoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoIncluir, RotasRabbit.FilaCursoIncluir, cursoDoAlunoParaIncluir));
                    if (!publicarGradeAlunoCurso)
                    {
                        await IncluirGradeDeCursoComErroAsync(filtro, ObterMensagemDeErro(filtro));
                    }
                }
                catch (Exception ex)
                {
                    await IncluirGradeDeCursoComErroAsync(filtro, ObterMensagemDeErro(filtro, ex));
                }
                
                return true;
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"" +
                    $"Erro ao iniciar a sincronização dos cursos CELP por Turma", LogNivel.Critico, 
                    LogContexto.CelpGsa, ex.Message, rastreamento: ex.StackTrace));
                
                return false;
            }
        }

        private CursoEol ObterCursoEol(FiltroTurmaComponenteCurricularUeDto filtro)
        {
            return new CursoEol(filtro.ComponenteCurricularNome, 
                filtro.Secao, long.Parse(filtro.TurmaCodigo),long.Parse(filtro.ComponenteCurricularCodigo), 
                filtro.UeCodigo,filtro.Email,(TurmaTipo)filtro.TipoId,(TipoEscola)filtro.TipoEscola);
        }
        
        private async Task IncluirGradeDeCursoComErroAsync(FiltroTurmaComponenteCurricularUeDto filtro, string mensagem)
        {
            var command = new InserirCursoErroCommand(
                long.Parse(filtro.TurmaCodigo),
                long.Parse(filtro.ComponenteCurricularCodigo),
                mensagem,
                null,
                ExecucaoTipo.CursoGradesAdicionar,
                ErroTipo.Negocio);

            await mediator.Send(command);
        }
        
        private static string ObterMensagemDeErro(FiltroTurmaComponenteCurricularUeDto filtro, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir a grade do curso CELP [TurmaId:{filtro.TurmaCodigo}, ComponenteCurricularId:{filtro.ComponenteCurricularCodigo}] na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }
    }
}