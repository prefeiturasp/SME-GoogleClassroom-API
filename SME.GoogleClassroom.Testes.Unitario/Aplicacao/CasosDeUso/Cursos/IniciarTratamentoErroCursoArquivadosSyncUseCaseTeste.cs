using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using RabbitMQ.Client;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos
{
    public class IniciarTratamentoErroCursoArquivadosSyncUseCaseTeste
    {
        private class TestableSyncErrosUseCase : IniciarTratamentoErroCursoArquivadosSyncUseCase
        {
            private readonly IConnection _conexao;

            public TestableSyncErrosUseCase(
                IConnection conexao,
                IConfiguration configuration,
                IMediator mediator,
                IReadOnlyPolicyRegistry<string> registry)
                : base(configuration, mediator, registry)
            {
                _conexao = conexao;
            }

            protected override Task<IConnection> ObterConexaoRabbitAsync(ConnectionFactory factory)
                => Task.FromResult(_conexao);
        }

        private static IReadOnlyPolicyRegistry<string> ObterPolicyRegistry()
        {
            var registry = new Mock<IReadOnlyPolicyRegistry<string>>();
            registry.Setup(x => x.Get<IAsyncPolicy>(PoliticaPolly.PolicyPublicaFila)).Returns(Policy.NoOpAsync());
            return registry.Object;
        }

        private static IConfiguration ObterConfiguration()
        {
            var config = new Mock<IConfiguration>();
            var section = new Mock<IConfigurationSection>();
            section.Setup(s => s.Value).Returns("dev");
            config.Setup(c => c.GetSection(It.IsAny<string>())).Returns(section.Object);
            return config.Object;
        }

        [Fact(DisplayName = "Fila de sync de erros vazia deve retornar true sem publicar")]
        public async Task Executar_FilaVazia_DeveRetornarTrue()
        {
            // Arrange
            var channelMock = new Mock<IChannel>();
            channelMock
                .Setup(c => c.BasicGetAsync(It.IsAny<string>(), false, It.IsAny<CancellationToken>()))
                .ReturnsAsync((BasicGetResult)null);

            var connectionMock = new Mock<IConnection>();
            connectionMock
                .Setup(c => c.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(channelMock.Object);

            var mediatorMock = new Mock<IMediator>();

            var useCase = new TestableSyncErrosUseCase(
                connectionMock.Object,
                ObterConfiguration(),
                mediatorMock.Object,
                ObterPolicyRegistry());

            // Act
            var resultado = await useCase.Executar();

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Mensagem na fila de sync deve fazer ack apos republicacao com sucesso e retornar true")]
        public async Task Executar_SucessoRepublicacao_DeveFazerAckERetornarTrue()
        {
            // Arrange
            var payload = new MensagemRabbit(new ArquivarCursoDto(1001, DateTime.Today, false));
            var json = JsonConvert.SerializeObject(payload);
            var body = new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(json));
            var basicGetResult = new BasicGetResult(9876, false, "exchange", "rota", 1, new BasicProperties(), body);

            var channelMock = new Mock<IChannel>();
            var chamado = false;
            channelMock
                .Setup(c => c.BasicGetAsync(It.IsAny<string>(), false, It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    if (!chamado)
                    {
                        chamado = true;
                        return basicGetResult;
                    }
                    return null;
                });

            var connectionMock = new Mock<IConnection>();
            connectionMock
                .Setup(c => c.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(channelMock.Object);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaCursoArquivarSync), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var useCase = new TestableSyncErrosUseCase(
                connectionMock.Object,
                ObterConfiguration(),
                mediatorMock.Object,
                ObterPolicyRegistry());

            // Act
            var resultado = await useCase.Executar();

            // Assert
            Assert.True(resultado);
            channelMock.Verify(c => c.BasicAckAsync(9876, false, It.IsAny<CancellationToken>()), Times.Once);
            channelMock.Verify(c => c.BasicNackAsync(It.IsAny<ulong>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Falha na republicacao na fila de sync deve fazer nack com requeue e retornar false")]
        public async Task Executar_FalhaRepublicacao_DeveFazerNackERetornarFalse()
        {
            // Arrange
            var payload = new MensagemRabbit(new ArquivarCursoDto(1001, DateTime.Today, false));
            var json = JsonConvert.SerializeObject(payload);
            var body = new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(json));
            var basicGetResult = new BasicGetResult(9876, false, "exchange", "rota", 1, new BasicProperties(), body);

            var channelMock = new Mock<IChannel>();
            channelMock
                .Setup(c => c.BasicGetAsync(It.IsAny<string>(), false, It.IsAny<CancellationToken>()))
                .ReturnsAsync(basicGetResult);

            var connectionMock = new Mock<IConnection>();
            connectionMock
                .Setup(c => c.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(channelMock.Object);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var useCase = new TestableSyncErrosUseCase(
                connectionMock.Object,
                ObterConfiguration(),
                mediatorMock.Object,
                ObterPolicyRegistry());

            // Act
            var resultado = await useCase.Executar();

            // Assert
            Assert.False(resultado);
            channelMock.Verify(c => c.BasicAckAsync(It.IsAny<ulong>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()), Times.Never);
            channelMock.Verify(c => c.BasicNackAsync(9876, false, true, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
