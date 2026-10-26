using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSincronizacaoNotasUseCase : AbstractUseCase, IIniciarSincronizacaoNotasUseCase
    {
        public IniciarSincronizacaoNotasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar(FiltroNotasAtividadesSincronizacaoDto filtro)
        {
            var anoAtual = DateTime.Today.Year;
            var parametroTotalDiasImportacao = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistema.TotalDiasImportacaoNotas, anoAtual));
            if (parametroTotalDiasImportacao is null)
                throw new NegocioException($"Parâmetro Total de dias para importação de Notas não localizado para o ano {anoAtual}");

            var publicado = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesCarregar, filtro));
            if (!publicado)
                throw new NegocioException("Não foi possível iniciar a sincronização das notas.");
        }
    }
}
