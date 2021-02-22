using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sentry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.IoC;
using System;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration ??
               throw new ArgumentNullException(nameof(configuration));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            RegistraDependencias.Registrar(services, Configuration);
            RegistrarHttpClients(services, Configuration);


            services.AddRabbit();
            services.AddPolicies();


            services.AddHostedService<WorkerRabbitMQ>();


            // Teste para injeção do client de telemetria em classe estática 
            SentrySdk.Init(Configuration.GetValue<string>("Sentry:DSN"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SME.GoogleClassroom.Worker.Rabbit", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("WorkerRabbitMQ!");
            });
        }

        private static void RegistrarHttpClients(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHttpClient<IServicoJurema, ServicoJurema>(c =>
            //{
            //    c.BaseAddress = new Uri(configuration.GetSection("UrlApiJurema").Value);
            //    c.DefaultRequestHeaders.Add("Accept", "application/json");
            //});
        }
    }
}
