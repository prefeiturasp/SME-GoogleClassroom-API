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
        private readonly IMediator mediator;

        public TrataSyncGoogleAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível iniciar a sincronização de alunos. A mensagem enviada é inválida.");

            var filtroCargaManual = ObterParametrosFiltro(mensagemRabbit);

            var codigoAlunoFiltro = ObterCodigoAlunoFiltro(mensagemRabbit);
            var ultimaAtualizacao = codigoAlunoFiltro is null ? await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AlunoAdicionar)) : default(DateTime?);
            var paginacao = new Paginacao(0, 0);

            if (filtroCargaManual != null) ultimaAtualizacao = new DateTime(filtroCargaManual.AnoLetivo, 1, 1);
            var parametrosCargaInicialDto = filtroCargaManual != null ? new ParametrosCargaInicialDto(filtroCargaManual.TiposUes, filtroCargaManual.Ues, filtroCargaManual.Turmas, filtroCargaManual.AnoLetivo) :
                await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            var alunosParaIncluirGoogle = await mediator.Send(new ObterAlunosNovosQuery(paginacao, ultimaAtualizacao, codigoAlunoFiltro, parametrosCargaInicialDto));

            alunosParaIncluirGoogle.Items
                .AsParallel()
                .WithDegreeOfParallelism(10)
                .ForAll(async alunoParaIncluirGoogleEol =>
                {
                    try
                    {
                        var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoIncluir, RotasRabbit.FilaAlunoIncluir, alunoParaIncluirGoogleEol));                        
                        if (!publicarAluno)
                            await IncluirAlunoComErroAsync(alunoParaIncluirGoogleEol, ObterMensagemDeErro(alunoParaIncluirGoogleEol.Codigo));
                    }
                    catch (Exception ex)
                    {
                        await IncluirAlunoComErroAsync(alunoParaIncluirGoogleEol, ObterMensagemDeErro(alunoParaIncluirGoogleEol.Codigo, ex));
                    }
                });

            if(codigoAlunoFiltro is null)
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AlunoAdicionar, DateTime.Today));

            return true;
        }

        private long? ObterCodigoAlunoFiltro(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var alunoParaIncluir = JsonConvert.DeserializeObject<IniciarSyncGoogleAlunoDto>(mensagemRabbit.Mensagem.ToString());
                return alunoParaIncluir?.CodigoAluno;
            }
            catch
            {
                return null;
            }
        }

        private FiltroCargaInicialDto ObterParametrosFiltro(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var filtro = JsonConvert.DeserializeObject<FiltroCargaInicialDto>(mensagemRabbit.Mensagem.ToString());
                return filtro;
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