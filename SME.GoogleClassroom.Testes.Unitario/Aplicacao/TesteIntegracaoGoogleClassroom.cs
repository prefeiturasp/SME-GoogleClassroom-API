using Google;
using Moq;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System.Net;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao
{
    public abstract class TesteIntegracaoGoogleClassroom
    {
        protected static IReadOnlyPolicyRegistry<string> GerarPolicy()
        {
            var registry = new Mock<IReadOnlyPolicyRegistry<string>>();
            registry.Setup(x => x.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync)).Returns(Policy.NoOpAsync());
            return registry.Object;
        }

        protected static VariaveisGlobaisOptions GerarVariaveisGlobais()
            => new VariaveisGlobaisOptions { DeveExecutarIntegracao = true };

        protected static GoogleApiException GerarExcecaoDeDuplicidadeDoGoogle()
        {
            var googleDuplicidadeException = new GoogleApiException(string.Empty, GoogleApiExceptionMensagens.Erro409EntityAlreadyExists);
            googleDuplicidadeException.HttpStatusCode = HttpStatusCode.Conflict;
            googleDuplicidadeException.Error = new Google.Apis.Requests.RequestError
            {
                Code = (int)HttpStatusCode.Conflict,
                Message = GoogleApiExceptionMensagens.Erro409EntityAlreadyExists
            };

            return googleDuplicidadeException;
        }
    }
}