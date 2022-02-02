using Elastic.Apm.AspNetCore;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.SqlClient;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using Prometheus;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Metricas;
using SME.GoogleClassroom.IoC;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using SME.GoogleClassroom.Worker.Rabbit.Middlewares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
            ConfiguraVariaveisAmbiente(services);

            RegistraDependencias.Registrar(services, Configuration);

            RegistrarHttpClients(services, Configuration);

            services.AddRabbit();
            services.AddPolicies();
            services.AddHostedService<WorkerRabbitMQ>();

            ConfiguraRabbitParaLogs(services);

            var telemetriaOptions = ConfiguraTelemetria(services);
            var servicoTelemetria = new ServicoTelemetria(telemetriaOptions);

            DapperExtensionMethods.Init(servicoTelemetria);
            services.AddSingleton(servicoTelemetria);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //c.AddServer(new OpenApiServer() { Description = "Dev", Url = "https://dev-gcasync.sme.prefeitura.sp.gov.br" });
                //TODO: Remover rota fixa

                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "SME.GoogleClassroom.Worker.Rabbit", 
                        Description = "Serviço de integração EOL com o Google Classroom",
                        Version = "v1" });
                c.OperationFilter<AdicionaCabecalhoHttp>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var serviceProvider = services.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediator>();
            services.AddSingleton(mediator);

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add(new FiltroExcecoesAttribute(mediator));
            });

            services.UseMetricReporter();
        }

        private void ConfiguraVariaveisAmbiente(IServiceCollection services)
        {
            var variaveisGlobais = new VariaveisGlobaisOptions();
            Configuration.GetSection(VariaveisGlobaisOptions.Secao).Bind(variaveisGlobais, c => c.BindNonPublicProperties = true);

            var consumoDeFilasOptions = new ConsumoDeFilasOptions();
            Configuration.GetSection(nameof(ConsumoDeFilasOptions)).Bind(consumoDeFilasOptions, c => c.BindNonPublicProperties = true);

            var gsaSyncOptions = new GsaSyncOptions();
            Configuration.GetSection(nameof(GsaSyncOptions)).Bind(gsaSyncOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(variaveisGlobais);
            services.AddSingleton(consumoDeFilasOptions);
            services.AddSingleton(gsaSyncOptions);
        }

        private static void RegistrarHttpClients(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(name: "servicoSgp", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("UrlSgp").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("x-sgp-api-key", configuration.GetSection("ChaveIntegracaoSgpApi").Value);
            }).AddPolicyHandler(GetRetryPolicy());
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3,
                                                                            retryAttempt)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseElasticApm(Configuration,
                new SqlClientDiagnosticSubscriber(),
                new HttpDiagnosticsSubscriber());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}" } };
                });
            });

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

        private TelemetriaOptions ConfiguraTelemetria(IServiceCollection services)
        {
            var telemetriaOptions = new TelemetriaOptions();
            Configuration.GetSection(TelemetriaOptions.Secao).Bind(telemetriaOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(telemetriaOptions);

            return telemetriaOptions;
        }

        private void ConfiguraRabbitParaLogs(IServiceCollection services)
        {
            var configuracaoRabbitLogOptions = new ConfiguracaoRabbitLogOptions();
            Configuration.GetSection("ConfiguracaoRabbitLog").Bind(configuracaoRabbitLogOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(configuracaoRabbitLogOptions);
        }
    }
}