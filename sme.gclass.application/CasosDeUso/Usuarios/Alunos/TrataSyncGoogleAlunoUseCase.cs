using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleAlunoUseCase : ITrataSyncGoogleAlunoUseCase
    {
        private const int QUANTIDADE_ITENS_POR_PAGINA = 10000;
        private readonly IMediator mediator;

        public TrataSyncGoogleAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível iniciar a sincronização de alunos. A mensagem enviada é inválida.");

            var filtro = ObterFiltro(mensagemRabbit);
            var codigoAlunoFiltro = filtro.CodigoAluno;
            var ultimaAtualizacao = default(DateTime?);

            if (codigoAlunoFiltro is null && !filtro.AnoLetivo.HasValue)
                ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AlunoAdicionar));
            else if (filtro.AnoLetivo.HasValue)
                ultimaAtualizacao = new DateTime(filtro.AnoLetivo.Value, 1, 1);

            if (filtro.Paginacao is null)
                filtro.Paginacao = codigoAlunoFiltro is null ? new Paginacao(1, QUANTIDADE_ITENS_POR_PAGINA) : new Paginacao(0, 0);

            var totalPaginas = 1;
            var parametrosCargaInicialDto = filtro.AnoLetivo != null ?
                new ParametrosCargaInicialDto(filtro.TiposUes, filtro.Ues, filtro.Turmas, filtro.AnoLetivo) :
                await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            var alunosEol = await mediator
                .Send(new ObterAlunosNovosQuery(filtro.Paginacao, ultimaAtualizacao, codigoAlunoFiltro, parametrosCargaInicialDto));

            totalPaginas = alunosEol.TotalPaginas;

            var codigosAlunosEol = alunosEol.Items.Select(a => (long)a.Codigo).ToArray();
            var alunosCadastrados = await mediator.Send(new ObterAlunosPorCodigosQuery(codigosAlunosEol));
            var alunosParaInclusao = from aeol in alunosEol.Items
                                     where !alunosCadastrados.Select(ac => ac.Codigo).Contains(aeol.Codigo)
                                     select aeol;

            alunosParaInclusao
                .AsParallel()
                .WithDegreeOfParallelism(10)
                .ForAll(async alunoParaIncluirGoogleEol =>
                {
                    try
                    {
                        var filtroAluno = new FiltroAlunoDto(alunoParaIncluirGoogleEol, parametrosCargaInicialDto.AnoLetivo, parametrosCargaInicialDto.TiposUes.ToList(), parametrosCargaInicialDto.Ues.ToList(), parametrosCargaInicialDto.Turmas.ToList());

                        var publicarAluno = await mediator
                            .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoIncluir, RotasRabbit.FilaAlunoIncluir, filtroAluno));

                        if (!publicarAluno)
                            await IncluirAlunoComErroAsync(alunoParaIncluirGoogleEol, ObterMensagemDeErro(alunoParaIncluirGoogleEol.Codigo));
                    }
                    catch (Exception ex)
                    {
                        await IncluirAlunoComErroAsync(alunoParaIncluirGoogleEol, ObterMensagemDeErro(alunoParaIncluirGoogleEol.Codigo, ex));
                    }
                });

            if (codigoAlunoFiltro is null && filtro.Paginacao.Pagina <= totalPaginas)
            {
                var dtoProximaPagina = new IniciarSyncGoogleAlunoDto(filtro.AnoLetivo, filtro.TiposUes, filtro.Ues, filtro.Turmas, null);
                dtoProximaPagina.Paginacao = new Paginacao(filtro.Paginacao.Pagina + 1, QUANTIDADE_ITENS_POR_PAGINA);

                var publicarSyncAluno = await mediator
                    .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoSync, RotasRabbit.FilaAlunoSync, dtoProximaPagina));

                if (!publicarSyncAluno)
                    throw new NegocioException($"Não foi possível iniciar a sincronização de alunos. Página: {dtoProximaPagina.Paginacao.Pagina}.");
            }
            else if (codigoAlunoFiltro is null)
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AlunoAdicionar, DateTime.Today));

            return true;
        }

        private IniciarSyncGoogleAlunoDto ObterFiltro(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var alunoParaIncluir = JsonConvert.DeserializeObject<IniciarSyncGoogleAlunoDto>(mensagemRabbit.Mensagem.ToString());
                return alunoParaIncluir;
            }
            catch
            {
                return null;
            }
        }

        private async Task IncluirAlunoComErroAsync(AlunoEol alunoParaIncluirGoogle, string mensagem)
        {
            var alunoComErro = new IncluirUsuarioErroCommand(
                                alunoParaIncluirGoogle.Codigo,
                                alunoParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.Aluno,
                                ExecucaoTipo.AlunoAdicionar);
            await mediator.Send(alunoComErro);
        }

        private static string ObterMensagemDeErro(long cdAluno, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o aluno RA{cdAluno} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}";
        }
    }
}