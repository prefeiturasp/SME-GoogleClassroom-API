using Moq;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Testes
{
    public abstract class TesteIntegracaoGoogleClassroom
    {
        protected static IReadOnlyPolicyRegistry<string> GerarPolicy()
        {
            var registry = new Mock<IReadOnlyPolicyRegistry<string>>();
            registry.Setup(x => x.Get<IAsyncPolicy>("RetryPolicy")).Returns(Policy.NoOpAsync());
            return registry.Object;
        }

        protected static VariaveisGlobaisOptions GerarVariaveisGlobais()
            => new VariaveisGlobaisOptions { DeveExecutarIntegracao = true };
    }
}