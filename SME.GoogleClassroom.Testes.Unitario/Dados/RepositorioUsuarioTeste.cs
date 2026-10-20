using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Dados
{
    public class RepositorioUsuarioTeste
    {
        private readonly RepositorioUsuario repositorioUsuario;

        public RepositorioUsuarioTeste()
        {
            DapperExtensionMethods.Init(new ServicoTelemetria(new TelemetriaOptions { Apm = false, ApplicationInsights = false }));

            var configData = new Dictionary<string, string>
            {
                { "ConnectionStrings:GoogleClassroomConnection", "Host=10.50.1.206;Port=5432;Database=db_googleclassroom;Username=admin;Password=12345qw" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var connectionStrings = new ConnectionStrings(configuration);
            repositorioUsuario = new RepositorioUsuario(connectionStrings);
        }

        [Fact(DisplayName = "ObterProfessoresAsync deve retornar professores com Id preenchido e não zerado")]
        public async Task ObterProfessoresAsync_DeveRetornarProfessoresComIdValido()
        {
            // Arrange
            var paginacao = new Paginacao(1, 5);

            // Act
            var resultado = await repositorioUsuario.ObterProfessoresAsync(paginacao, null, null);

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado.Items);
            foreach (var professor in resultado.Items)
            {
                Assert.True(professor.Id > 0, $"O id do professor RF {professor.Rf} não pode ser zero.");
                Assert.True(professor.Rf > 0, "O RF do professor deve ser maior que zero.");
                Assert.NotNull(professor.Nome);
            }
        }
    }
}
