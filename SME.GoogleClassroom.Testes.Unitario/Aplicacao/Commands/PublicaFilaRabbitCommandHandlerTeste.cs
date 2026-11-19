using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using RabbitMQ.Client;
using SME.GoogleClassroom.Aplicacao;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Commands
{
    public class PublicaFilaRabbitCommandHandlerTeste
    {
        [Fact(DisplayName = "Construtor deve lançar ArgumentNullException quando conexão nula")]
        public void Construtor_ConexaoNula_DeveLancarArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PublicaFilaRabbitCommandHandler(null));
        }

        [Fact(DisplayName = "Deve propagar exceção quando a criação do canal falhar")]
        public async Task Handle_FalhaAoCriarCanal_DevePropagarExcecao()
        {
            // Arrange
            var conexaoMock = new Mock<IConnection>();
            conexaoMock
                .Setup(c => c.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Falha de conexão RabbitMQ"));

            var handler = new PublicaFilaRabbitCommandHandler(conexaoMock.Object);
            var command = new PublicaFilaRabbitCommand("fila.teste", new { Id = 1 });

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
            Assert.Equal("Falha de conexão RabbitMQ", ex.Message);
        }

        [Fact(DisplayName = "Deve publicar mensagem com sucesso e retornar true")]
        public async Task Handle_Sucesso_DeveRetornarTrue()
        {
            // Arrange
            var canalMock = new Mock<IChannel>();
            var conexaoMock = new Mock<IConnection>();
            conexaoMock
                .Setup(c => c.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(canalMock.Object);

            var handler = new PublicaFilaRabbitCommandHandler(conexaoMock.Object);
            var command = new PublicaFilaRabbitCommand("fila.teste", new { Id = 1 });

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado);
            canalMock.Verify(c => c.BasicPublishAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<BasicProperties>(),
                It.IsAny<ReadOnlyMemory<byte>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
