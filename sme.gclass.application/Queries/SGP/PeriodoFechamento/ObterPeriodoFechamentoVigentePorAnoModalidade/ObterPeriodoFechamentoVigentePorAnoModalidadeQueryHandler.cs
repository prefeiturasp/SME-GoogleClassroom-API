using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterPeriodoFechamentoVigentePorAnoModalidadeQueryHandler : IRequestHandler<ObterPeriodoFechamentoVigentePorAnoModalidadeQuery, PeriodoFechamentoVigenteDto>
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ObterPeriodoFechamentoVigentePorAnoModalidadeQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<PeriodoFechamentoVigenteDto> Handle(ObterPeriodoFechamentoVigentePorAnoModalidadeQuery request, CancellationToken cancellationToken)
        {
            var httpClient = httpClientFactory.CreateClient("servicoSgp");

            var modalidade = request.ModalidadeTipoCalendario.HasValue ? $"&modalidadeTipoCalendario={request.ModalidadeTipoCalendario}" : "";
            var resposta = await httpClient.GetAsync($"v1/periodos/fechamentos/aberturas/integracoes/vigente?anoLetivo={request.AnoLetivo}{modalidade}");

            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PeriodoFechamentoVigenteDto>(json);
            }

            return null;
        }
    }
}
