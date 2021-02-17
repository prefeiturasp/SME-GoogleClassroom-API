using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sentry;
using SME.GoogleClassroom.IoC;

namespace SME.GoogleClassroom.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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

            // Teste para injeção do client de telemetria em classe estática 
            SentrySdk.Init(Configuration.GetValue<string>("Sentry:DSN"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SME.GoogleClassroom.api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SME.GoogleClassroom.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
