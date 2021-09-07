using MediatR;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ComponenteLancaNotaQueryHandler : IRequestHandler<ComponenteLancaNotaQuery, bool>
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ComponenteLancaNotaQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<bool> Handle(ComponenteLancaNotaQuery request, CancellationToken cancellationToken)
        {
            var podeLancarNota = false;
            var httpClient = httpClientFactory.CreateClient("servicoSgp");
            var resposta = await httpClient.GetAsync($"v1/componente-curricular/integracoes/lanca-nota?componenteCurricularId={request.ComponenteCurricularId}");
            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                podeLancarNota = JsonConvert.DeserializeObject<bool>(json);
            }
            else
            {
                throw new Exception($"Não foi possível verificar se o componente currícular {request.ComponenteCurricularId} laça nota.");
            }
            return podeLancarNota;
        }
    }
}
