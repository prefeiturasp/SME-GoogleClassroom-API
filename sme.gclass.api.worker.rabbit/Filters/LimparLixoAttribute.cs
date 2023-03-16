using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LimparLixoAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //RaphaelDias. Invoca o Garbage Collector forçando que passe no Gen2 para remover o que foi direto pra lá. O processo é feito com blocking para garantir que execute
            //Isso é feito antes do return pq vai pegar o lixo das outras requisições, não dessa.
            GC.Collect(2, GCCollectionMode.Forced, blocking:true);

            await next();
        }
    }
}
