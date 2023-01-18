using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAulasPorDataTurmaComponenteCurricularQueryHandler : IRequestHandler<ObterAulasPorDataTurmaComponenteCurricularQuery, IEnumerable<AulaQuantidadeTipoDto>>
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ObterAulasPorDataTurmaComponenteCurricularQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<AulaQuantidadeTipoDto>> Handle(ObterAulasPorDataTurmaComponenteCurricularQuery request, CancellationToken cancellationToken)
        {
            var httpClient = httpClientFactory.CreateClient("servicoSgp");

            var resposta = await httpClient.GetAsync($"v1/aula/integracoes/turma/{request.CodigoTurma}/componente-curricular/{request.CodigoComponenteCurricular}/data/{request.DataAulaTicks}");

            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<AulaQuantidadeTipoDto>>(json);
            }

            return null;
        }
    }
}
