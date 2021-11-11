using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarAtividadesParaSincronizarNotasUseCase : AbstractUseCase, ICarregarAtividadesParaSincronizarNotasUseCase
    {
        public CarregarAtividadesParaSincronizarNotasUseCase(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.ObterObjetoMensagem<FiltroNotasAtividadesSincronizacaoDto>();
            var ultimaExecucao = await ObterUltimaExecucao();

            if (!filtro.CursoId.HasValue && ultimaExecucao.Date.Equals(DateTime.Today.Date))
                return true;

            var periodo = await ObterPeriodoDatasImportacaoAtividades(ultimaExecucao);

            filtro.Pagina = filtro.Pagina ?? 1;

            var retorno = await mediator
                .Send(new ObterAtividadesPorPeriodoQuery(periodo.dataInicio, periodo.dataFim, filtro.CursoId, filtro.Pagina.Value));

            var totalPaginas = retorno.totalPaginas ?? filtro.TotalPaginas;

            Console.WriteLine($">>> Carga Notas - Página: {filtro.Pagina}/{totalPaginas}");

            try
            {
                await PublicarMensagemTratar(retorno);

                if (!filtro.CursoId.HasValue)
                {
                    if (filtro.Pagina > totalPaginas)
                        await AtualizarUltimaExecucao();
                    else
                        await PublicarMensagemProximaPagina(filtro.Pagina.Value + 1, totalPaginas.Value);
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }

            return true;
        }

        private async Task PublicarMensagemTratar((int? totalPaginas, IEnumerable<DadosAvaliacaoDto> atividades) retorno)
        {
            await mediator
                .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesTratar, ListarAtividadesExecutar(retorno.atividades)));
        }

        private IEnumerable<TratarImportacaoNotasAvalidacaoDto> ListarAtividadesExecutar(IEnumerable<DadosAvaliacaoDto> atividades)
        {
            foreach (var atividade in atividades)
                yield return new TratarImportacaoNotasAvalidacaoDto(atividade);
        }

        private async Task AtualizarUltimaExecucao()
        {
            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.NotasAtividadesCarregar));
        }

        private async Task<(DateTime dataInicio, DateTime dataFim)> ObterPeriodoDatasImportacaoAtividades(DateTime ultimaExecucao)
        {
            var anoLetivo = DateTime.Now.Year;

            var totalDiasParaImportacao = await ObterTotalDiasParaImportacaoDeNotas(anoLetivo);
            var dataFim = await ObterDataFim(totalDiasParaImportacao);

            return (ultimaExecucao.AddDays(-totalDiasParaImportacao), dataFim);
        }

        private async Task<DateTime> ObterDataFim(int totalDiasParaImportacao)
        {
            return await EstaEmFechamento() ?
                DateTime.Today :
                DateTime.Today.AddDays(-totalDiasParaImportacao);
        }

        private async Task<bool> EstaEmFechamento()
        {
            var periodoFechamento = await mediator.Send(new ObterPeriodoFechamentoVigentePorAnoModalidadeQuery(DateTime.Now.Year));
            return periodoFechamento != null;
        }

        private async Task<DateTime> ObterUltimaExecucao()
        {
            return await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.NotasAtividadesCarregar));
        }

        private async Task<int> ObterTotalDiasParaImportacaoDeNotas(int anoLetivo)
        {
            var parametroTotalDiasImportacao = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(Dominio.TipoParametroSistema.TotalDiasImportacaoNotas, anoLetivo));
            if (parametroTotalDiasImportacao is null)
                throw new NegocioException($"Parâmetro Total de dias para importação de Notas não localizado para o ano {anoLetivo}");

            return int.Parse(parametroTotalDiasImportacao.Valor) - 1;
        }

        private async Task PublicarMensagemProximaPagina(int proximaPagina, int totalPaginas)
        {
            var filtro = new FiltroNotasAtividadesSincronizacaoDto()
            {
                Pagina = proximaPagina,
                TotalPaginas = totalPaginas
            };

            await mediator
                .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesCarregar, filtro));
        }
    }
}
