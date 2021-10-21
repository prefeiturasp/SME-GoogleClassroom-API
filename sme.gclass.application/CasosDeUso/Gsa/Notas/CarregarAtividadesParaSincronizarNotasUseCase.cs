using MediatR;
using Newtonsoft.Json;
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
        private readonly IExecutarImportacaoDeNotasDaAtividadeUseCase executarImportacaoDeNotasDaAtividadeUseCase;

        public CarregarAtividadesParaSincronizarNotasUseCase(IMediator mediator,
                                                             IExecutarImportacaoDeNotasDaAtividadeUseCase executarImportacaoDeNotasDaAtividadeUseCase)
            : base(mediator)
        {
            this.executarImportacaoDeNotasDaAtividadeUseCase = executarImportacaoDeNotasDaAtividadeUseCase ?? throw new ArgumentNullException(nameof(executarImportacaoDeNotasDaAtividadeUseCase));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.ObterObjetoMensagem<FiltroNotasAtividadesSincronizacaoDto>();
            var ultimaExecucao = await ObterUltimaExecucao();

            if (ultimaExecucao.Date.Equals(DateTime.Today.Date))
                return true;

            var periodo = await ObterPeriodoDatasImportacaoAtividades(ultimaExecucao);

            var pagina = 1;
            long totalPaginas;

            do
            {
                var retorno = await mediator.Send(new ObterAtividadesPorPeriodoQuery(periodo.dataInicio, periodo.dataFim, filtro.CursoId, pagina));
                totalPaginas = retorno.totalPaginas;

                await ExecutarImportacaoNotasAtividades(retorno.atividades);

                pagina++;

            } while (pagina <= totalPaginas);

            if (!filtro.CursoId.HasValue)
                await AtualizarUltimaExecucao();

            return true;
        }

        private async Task ExecutarImportacaoNotasAtividades(IEnumerable<DadosAvaliacaoDto> atividades)
        {
            foreach (var atividade in atividades)
            {
                var consultaNotas = await mediator.Send(new ObterNotasGooglePorAtividadeQuery(atividade));
                foreach (var nota in consultaNotas.Notas)
                {
                    var filtroNota = JsonConvert.SerializeObject(new SincronizarImportacaoNotasDto(atividade, nota));
                    await executarImportacaoDeNotasDaAtividadeUseCase.Executar(new MensagemRabbit(filtroNota));
                }
            }
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
    }
}
