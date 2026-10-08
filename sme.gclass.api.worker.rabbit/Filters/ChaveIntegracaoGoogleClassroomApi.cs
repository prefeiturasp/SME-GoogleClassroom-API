using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SME.GoogleClassroom.Worker.Rabbit.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ChaveIntegracaoGoogleClassroomApi : Attribute, IAsyncActionFilter
    {
        public const string ChaveIntegracaoHeader = "x-gca-api-key";
        private const string ChaveIntegracaoEnvironmentVariableName = "ChaveIntegracaoGoogleClassroomApi";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var chaveApi = configuration?[ChaveIntegracaoEnvironmentVariableName] ??
                           Environment.GetEnvironmentVariable(ChaveIntegracaoEnvironmentVariableName);

            if (!context.HttpContext.Request.Headers.TryGetValue(ChaveIntegracaoHeader, out var chaveRecebida) ||
                !string.Equals(chaveRecebida.ToString(), chaveApi, StringComparison.Ordinal))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}