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
    public class ObterAtribuicaoResponsaveisSgpQueryHandler : IRequestHandler<ObterAtribuicaoResponsaveisSgpQuery, IEnumerable<ResponsaveisSgpDto>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ObterAtribuicaoResponsaveisSgpQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<ResponsaveisSgpDto>> Handle(ObterAtribuicaoResponsaveisSgpQuery request, CancellationToken cancellationToken)
        {
            var responsaveisSgp = new List<ResponsaveisSgpDto>();

            var httpClient = httpClientFactory.CreateClient("servicoSgp");
            var resposta = await httpClient.GetAsync($"v1/atribuicoes/responsaveis/integracoes/escola/{request.CodigoEscola}/tipo/{request.Tipo}", cancellationToken);
            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                    responsaveisSgp = JsonConvert.DeserializeObject<List<ResponsaveisSgpDto>>(json);
            }
            return responsaveisSgp;
        }
    }
}
