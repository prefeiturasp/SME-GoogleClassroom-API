using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra.Dtos.Sga;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterProfessorCjSgp
{
    public class ObterProfessorCjSgpQueryHandler : IRequestHandler<ObterProfessorCjSgpQuery, IEnumerable<ProfessorCjSgpDto>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ObterProfessorCjSgpQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<ProfessorCjSgpDto>> Handle(ObterProfessorCjSgpQuery request, CancellationToken cancellationToken)
        {
            var listaCj = new List<ProfessorCjSgpDto>();

            var httpClient = httpClientFactory.CreateClient("servicoSgp");
            var resposta = await httpClient.GetAsync($"/v1/atribuicoes/cjs/integracoes?UeId=${request.CodigoEscola}&AnoLetivo=${request.AnoLetivo}");
            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                listaCj = JsonConvert.DeserializeObject<List<ProfessorCjSgpDto>>(json);
            }
            return listaCj;
        }
    }
}
