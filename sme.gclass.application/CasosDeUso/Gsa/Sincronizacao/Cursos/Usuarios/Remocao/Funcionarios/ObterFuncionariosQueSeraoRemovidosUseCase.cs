using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosQueSeraoRemovidosUseCase : AbstractUseCase, IObterFuncionariosQueSeraoRemovidosUseCase
    {
        public ObterFuncionariosQueSeraoRemovidosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>> Executar(FiltroObterUsuariosQueSeraoRemovidosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            var ano = DateTime.Now.Year;
            var periodo = await ObterDatas(ano);

            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            return await mediator.Send(new ObterFuncionariosParaRemoverCursoPaginadoQuery(filtro.TurmaId, periodo.dataInicio, periodo.dataFim, paginacao, parametrosCargaInicialDto));
        }

        private async Task<(DateTime dataInicio, DateTime dataFim)> ObterDatas(int ano)
        {

            var parametroDiasRemocaoFuncionarios = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistema.DiasRemocaoFuncionario, ano));
            if (parametroDiasRemocaoFuncionarios is null || !parametroDiasRemocaoFuncionarios.Ativo)
                throw new NegocioException($"Não foi possível localizar o parâmetro de Dias para Reomoção de Funcionários para o ano {ano}");

            if (!int.TryParse(parametroDiasRemocaoFuncionarios.Valor, out var diasParaRemocao))
                throw new NegocioException("Erro ao obter o valor do parâmetro de Dias para Remoção de Funcionários");

            var ultimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));
            return (ultimaExecucao.AddDays(-diasParaRemocao), DateTime.Today.AddDays(-diasParaRemocao));
        }
    }
}
