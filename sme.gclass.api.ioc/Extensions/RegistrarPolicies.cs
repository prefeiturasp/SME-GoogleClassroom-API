using Google;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.IoC
{
    public static class RegistrarPolicies
    {
        public static void AddPolicies(this IServiceCollection services)
        {
            IPolicyRegistry<string> registry = services.AddPolicyRegistry();

            Random jitterer = new Random();
            var policy = Policy.Handle<Exception>(ex => !(ex is GoogleApiException || ex is NegocioException))
              .WaitAndRetryAsync(3,    // exponential back-off plus some jitter
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                      + TimeSpan.FromMilliseconds(jitterer.Next(0, 30)));

            registry.Add("RetryPolicy", policy);

            RegistrarPolicyComparativoDeDados(services);
        }

        private static void RegistrarPolicyComparativoDeDados(IServiceCollection services)
        {
            IPolicyRegistry<string> registry = services.AddPolicyRegistry();

            var policy = Policy.Handle<Exception>(ex => !(ex is GoogleApiException))
              .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(60));

            registry.Add("RetryComparativoDeDadosPolicy", policy);
        }
    }
}