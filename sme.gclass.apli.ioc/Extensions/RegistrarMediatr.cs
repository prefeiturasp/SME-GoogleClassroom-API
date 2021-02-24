using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SME.GoogleClassroom.Aplicacao;
using System;

namespace SME.GoogleClassroom.IoC
{
    public static class RegistraMediatr
    {
        public static void AdicionarMediatr(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SME.GoogleClassroom.Aplicacao");
            services.AddMediatR(assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacoesPipeline<,>));
        }
    }
}
