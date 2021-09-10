using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterPeriodoAtualPorTurmaEDataQueryHandler : IRequestHandler<ObterPeriodoAtualPorTurmaEDataQuery, PeriodoDto>
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ObterPeriodoAtualPorTurmaEDataQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<PeriodoDto> Handle(ObterPeriodoAtualPorTurmaEDataQuery request, CancellationToken cancellationToken)
        {
            var httpClient = httpClientFactory.CreateClient("servicoSgp");
            var resposta = await httpClient.GetAsync($"v1/periodo-escolar/integracoes/periodo-atual?turmaId={request.TurmaId}&dataReferencia={request.DataReferencia}");
            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PeriodoDto>(json);
            }
            else
            {
                return null;
            }
        }
    }
}
