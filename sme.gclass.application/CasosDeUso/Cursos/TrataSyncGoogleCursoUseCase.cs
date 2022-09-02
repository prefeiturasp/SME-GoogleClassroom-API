using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleCursoUseCase : ITrataSyncGoogleCursoUseCase
    {
        private const int QUANTIDADE_PADRAO_REGISTROS_POR_PAGINA = 10000;
        private readonly IMediator mediator;

        public TrataSyncGoogleCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível iniciar a sincronização de cursos. A mensagem enviada é inválida.");

            var filtro = ObterFiltro(mensagemRabbit);

            var parametrosCargaInicialDto = filtro != null && filtro.AnoLetivo.HasValue ? new ParametrosCargaInicialDto(filtro.TiposUes, filtro.Ues, filtro.Turmas, filtro.AnoLetivo) :
                await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            var dataReferencia = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.CursoAdicionar));
            var paginacao = new Paginacao(filtro?.Pagina ?? 1, QUANTIDADE_PADRAO_REGISTROS_POR_PAGINA);

            var cursosResgatados = await mediator
                .Send(new ObterCursosIncluirGoogleQuery(parametrosCargaInicialDto, dataReferencia, paginacao, filtro?.ComponenteCurricularId, filtro?.TurmaId));

            foreach (var cursoParaAdicionar in cursosResgatados.Items)
            {
                try
                {
                    if (!(await mediator.Send(new ExisteCursoPorTurmaComponenteCurricularQuery(cursoParaAdicionar.TurmaId, cursoParaAdicionar.ComponenteCurricularId))))
                    {
                        var rf = Convert.ToInt64(cursoParaAdicionar.Email.Substring(cursoParaAdicionar.Email.IndexOf('@') - 7, 7));
                        var professores = await mediator.Send(new ObterProfessoresPorRfsQuery(rf));
                        cursoParaAdicionar.Email = professores != null && professores.Any() && !professores.First().Email.Equals(cursoParaAdicionar.Email) ? professores.First().Email : cursoParaAdicionar.Email;
                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoIncluir, RotasRabbit.FilaCursoIncluir, cursoParaAdicionar));
                    }                   
                }
                catch (Exception ex)
                {
                    await mediator.Send(new InserirCursoErroCommand(cursoParaAdicionar.TurmaId, cursoParaAdicionar.ComponenteCurricularId, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
                }
            }

            if ((filtro == null || !filtro.TurmaId.HasValue) && !cursosResgatados.Items.Any())
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.CursoAdicionar));
            else if (filtro == null || !filtro.TurmaId.HasValue)
            {
                var mensagem = new IniciarSyncGoogleCursoDto(null, null, (filtro?.Pagina ?? 1) + 1);
                mensagem.TiposUes = filtro.TiposUes;
                mensagem.Ues = filtro.Ues;
                mensagem.Turmas = filtro.Turmas;
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoSync, RotasRabbit.FilaCursoSync, mensagem));
            }

            return true;
        }

        private IniciarSyncGoogleCursoDto ObterFiltro(MensagemRabbit mensagemRabbit)
        {
            try
            {
                return JsonSerializer.Deserialize<IniciarSyncGoogleCursoDto>(mensagemRabbit.Mensagem.ToString());
            }
            catch
            {
                return null;
            }
        }
    }
}
