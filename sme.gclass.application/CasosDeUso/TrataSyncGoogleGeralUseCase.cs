using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Infra;
using System.Net.Http;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleGeralUseCase : ITrataSyncGoogleGeralUseCase
    {
        public TrataSyncGoogleGeralUseCase(IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry)
        {
            var policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var resposta = JsonConvert.SerializeObject(mensagemRabbit);
            return await Task.FromResult(true);
        }
    }
}
