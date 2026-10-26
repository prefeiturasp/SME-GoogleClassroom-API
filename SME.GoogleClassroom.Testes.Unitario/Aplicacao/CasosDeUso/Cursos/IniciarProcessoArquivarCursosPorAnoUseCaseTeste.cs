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
    public class IniciarProcessoArquivarCursosPorAnoUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly IniciarProcessoArquivarCursosPorAnoUseCase useCase;

        public IniciarProcessoArquivarCursosPorAnoUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new IniciarProcessoArquivarCursosPorAnoUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Ano letivo nulo deve lançar NegocioException (601)")]
        public async Task Executar_AnoLetivoNulo_DeveLancarNegocioException()
        {
            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(null));
            Assert.Equal("O ano letivo deve ser informado e válido.", ex.Message);
            Assert.Equal(601, ex.StatusCode);

            mediatorMock.Verify(m => m.Send(It.IsAny<ExisteTurmaPorCodigoQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Theory(DisplayName = "Ano letivo inválido deve lançar NegocioException (601)")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1899)]
        [InlineData(999999)]
        public async Task Executar_AnoLetivoInvalido_DeveLancarNegocioException(int anoInvalido)
        {
            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(anoInvalido));
            Assert.Equal("O ano letivo deve ser informado e válido.", ex.Message);
            Assert.Equal(601, ex.StatusCode);

            mediatorMock.Verify(m => m.Send(It.IsAny<ExisteTurmaPorCodigoQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "TurmaId informado inexistente deve lançar NegocioException (601)")]
        public async Task Executar_TurmaInexistente_DeveLancarNegocioException()
        {
            // Arrange
            int anoLetivo = DateTime.Today.Year;
            long turmaId = 9999999999999;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorCodigoQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(anoLetivo, turmaId));
            Assert.Equal("A turma informada não foi localizada na base do EOL.", ex.Message);
            Assert.Equal(601, ex.StatusCode);

            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Ano letivo e TurmaId válidos devem publicar na fila e retornar true")]
        public async Task Executar_AnoLetivoETurmaValidos_DevePublicarERetornarTrue()
        {
            // Arrange
            int anoLetivo = 2025;
            long turmaId = 2251678;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorCodigoQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaCursoArquivarCarregar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(anoLetivo, turmaId);

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c =>
                c.NomeRota == RotasRabbit.FilaCursoArquivarCarregar &&
                c.Mensagem is FiltroArquivamentoCursoDto), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Ano letivo válido sem turmaId deve publicar na fila e retornar true")]
        public async Task Executar_AnoLetivoValidoSemTurma_DevePublicarERetornarTrue()
        {
            // Arrange
            int anoLetivo = 2025;
            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaCursoArquivarCarregar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(anoLetivo, null);

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExisteTurmaPorCodigoQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c =>
                c.NomeRota == RotasRabbit.FilaCursoArquivarCarregar &&
                c.Mensagem is FiltroArquivamentoCursoDto), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Falha na publicação deve lançar NegocioException e não retornar true")]
        public async Task Executar_FalhaNaPublicacao_DeveLancarNegocioException()
        {
            // Arrange
            int anoLetivo = 2025;
            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaCursoArquivarCarregar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(anoLetivo, null));
            Assert.Equal("Não foi possível publicar a mensagem para arquivamento de cursos.", ex.Message);
        }
    }
}
