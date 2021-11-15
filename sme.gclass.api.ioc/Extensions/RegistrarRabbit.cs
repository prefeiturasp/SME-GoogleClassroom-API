using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.IoC
{
    public static class RegistrarRabbit
    {
        public static void AddRabbit(this IServiceCollection services, ConfiguracaoRabbitOptions configuracaoRabbitOptions)
        {
          
            var factory = new ConnectionFactory
            {
                HostName = configuracaoRabbitOptions.HostName,
                UserName = configuracaoRabbitOptions.UserName,
                Password = configuracaoRabbitOptions.Password,
                VirtualHost = configuracaoRabbitOptions.Virtualhost,
                AutomaticRecoveryEnabled = true,
                RequestedHeartbeat = TimeSpan.FromSeconds(30)
            };

            var conexaoRabbit = factory.CreateConnection();
            IModel _channel = conexaoRabbit.CreateModel();
            services.AddSingleton(conexaoRabbit);
            services.AddSingleton(_channel);
        }
    }
}
