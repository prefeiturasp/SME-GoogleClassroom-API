using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prometheus;
using Sentry;
using SME.GoogleClassroom.Infra.Metricas;
using SME.GoogleClassroom.IoC;
using SME.GoogleClassroom.Worker.Rabbit.Middlewares;
using System;
using System.IO;
using System.Reflection;

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

            services.AddRabbit();
            services.AddPolicies();
            services.AddHostedService<WorkerRabbitMQ>();

            // Teste para injeção do client de telemetria em classe estática
            SentrySdk.Init(Configuration.GetValue<string>("Sentry:DSN"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.AddServer(new OpenApiServer() { Description = "Dev", Url = "https://dev-gcasync.sme.prefeitura.sp.gov.br" });
                //TODO: Remover rota fixa

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SME.GoogleClassroom.Worker.Rabbit", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add(new FiltroExcecoesAttribute(Configuration));
            });

            services.UseMetricReporter();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SME.GoogleClassroom.Worker.Rabbit"));

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            app.UseAuthorization();

            app.UseHttpMetrics();
            app.UseMetricServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("GoogleClassroom Worker!");
            });
        }
    }
}