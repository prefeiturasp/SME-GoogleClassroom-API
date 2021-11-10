using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.IoC
{
    public static class RegistrarRabbit
    {
        public static void AddRabbit(this IServiceCollection services)
        {
            //var factory = new ConnectionFactory
            //{
            //    HostName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__HostName"),
            //    UserName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__UserName"),
            //    Password = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Password"),
            //    VirtualHost = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Virtualhost"),
            //    AutomaticRecoveryEnabled = true,
            //    RequestedHeartbeat = TimeSpan.FromSeconds(60)
            //};

            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__HostName"),
                UserName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__UserName"),
                Password = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Password"),
                VirtualHost = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Virtualhost"),
                AutomaticRecoveryEnabled = true,
                RequestedHeartbeat = TimeSpan.FromSeconds(60)
            };

            var conexaoRabbit = factory.CreateConnection();
            IModel _channel = conexaoRabbit.CreateModel();
            services.AddSingleton(conexaoRabbit);
            services.AddSingleton(_channel);

            //_channel.ExchangeDeclare(RotasRabbit.ExchangeSgp, ExchangeType.Topic);
            //_channel.QueueDeclare(RotasRabbit.FilaSgp, false, false, false, null);
            //_channel.QueueBind(RotasRabbit.FilaSgp, RotasRabbit.ExchangeSgp, "*");
        }
    }
}
