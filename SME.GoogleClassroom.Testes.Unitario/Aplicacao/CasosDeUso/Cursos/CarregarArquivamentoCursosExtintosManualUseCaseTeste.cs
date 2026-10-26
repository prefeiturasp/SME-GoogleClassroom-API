using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos
{
    public class CarregarArquivamentoCursosExtintosManualUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly CarregarArquivamentoCursosExtintosManualUseCase useCase;

        public CarregarArquivamentoCursosExtintosManualUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new CarregarArquivamentoCursosExtintosManualUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "TurmaId informado inexistente deve lançar NegocioException (601)")]
        public async Task Executar_TurmaInexistente_DeveLancarNegocioException()
        {
            // Arrange
            long turmaId = 9999999999999;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorCodigoQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(turmaId, DateTime.Today));
            Assert.Equal("A turma informada não foi localizada na base do EOL.", ex.Message);
            Assert.Equal(601, ex.StatusCode);

            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "TurmaId informado existente deve publicar na fila e retornar true")]
        public async Task Executar_TurmaExistente_DevePublicarERetornarTrue()
        {
            // Arrange
            long turmaId = 2251678;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorCodigoQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaCursoExtintoArquivarCarregar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(turmaId, DateTime.Today);

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Sem TurmaId informado deve publicar na fila sem validar turma e retornar true")]
        public async Task Executar_SemTurmaId_DevePublicarERetornarTrue()
        {
            // Arrange
            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaCursoExtintoArquivarCarregar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(null, null);

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExisteTurmaPorCodigoQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Falha na publicação deve lançar NegocioException e não retornar true")]
        public async Task Executar_FalhaNaPublicacao_DeveLancarNegocioException()
        {
            // Arrange
            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaCursoExtintoArquivarCarregar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(null, null));
            Assert.Equal("Não foi possível publicar a mensagem para arquivamento de turmas extintas.", ex.Message);
        }
    }
}
