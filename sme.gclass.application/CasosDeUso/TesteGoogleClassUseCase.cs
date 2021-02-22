using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using System.Net.Http;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TesteGoogleClassUseCase : ITesteGoogleClassUseCase
    {
        public TesteGoogleClassUseCase(IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry)
        {
            var a = configuration.GetSection("ronaldo");
            var policy = registry.Get<IAsyncPolicy<HttpResponseMessage>>("SimpleHttpRetryPolicy");
        }
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var resposta = JsonConvert.SerializeObject(mensagemRabbit);
            return await Task.FromResult(true);
        }
    }
}
