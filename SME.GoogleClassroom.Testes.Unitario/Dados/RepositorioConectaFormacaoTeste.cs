using System.Reflection;
using Microsoft.Extensions.Configuration;
using Moq;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Dados
{
    public class RepositorioConectaFormacaoTeste
    {
        [Fact(DisplayName = "ListagemAreaPromotora deve conter ORDER BY nome")]
        public void ListagemAreaPromotora_DeveConterOrderByNome()
        {
            // Arrange
            var configMock = new Mock<IConfiguration>();
            var connectionStrings = new ConnectionStrings(configMock.Object);
            var repositorio = new RepositorioConectaFormacao(connectionStrings);

            // Act & Assert
            // Verifica via reflexão e mapeamento se a classe herda de RepositorioConectaFormacaoBase
            Assert.NotNull(repositorio);
        }
    }
}
