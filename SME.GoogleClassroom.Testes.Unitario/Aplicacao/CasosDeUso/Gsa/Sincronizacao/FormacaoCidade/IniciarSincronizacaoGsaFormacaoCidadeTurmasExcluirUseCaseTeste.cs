using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Google;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Gsa.Sincronizacao.FormacaoCidade
{
    public class IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase useCase;

        public IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Quando exclusão no Google for bem-sucedida, deve reconciliar public.cursos_gsa")]
        public async Task Executar_QuandoExclusaoGoogleSucesso_DeveReconciliarCursosGsa()
        {
            // Arrange
            const long cursoId = 886920262384;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == cursoId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(cursoId.ToString());

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(
                It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == cursoId),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Quando exclusão no Google falhar, deve preservar o registro local em public.cursos_gsa")]
        public async Task Executar_QuandoExclusaoGoogleFalhar_DevePreservarRegistroLocal()
        {
            // Arrange
            const long cursoId = 886920262384;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == cursoId), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new GoogleApiException("GoogleClassroom", "Internal Server Error")
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError
                });

            // Act & Assert
            await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(cursoId.ToString()));

            mediatorMock.Verify(m => m.Send(
                It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == cursoId),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Quando curso já não existe no Google (404), deve reconciliar public.cursos_gsa")]
        public async Task Executar_QuandoCursoNaoExisteNoGoogle404_DeveReconciliarCursosGsa()
        {
            // Arrange
            const long cursoId = 886920262384;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == cursoId), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new GoogleApiException("GoogleClassroom", "Not Found")
                {
                    HttpStatusCode = HttpStatusCode.NotFound
                });

            // Act
            var resultado = await useCase.Executar(cursoId.ToString());

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(
                It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == cursoId),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Lote totalmente válido deve processar e reconciliar todos os cursos")]
        public async Task Executar_LoteTotalmenteValido_DeveProcessarTodosCursos()
        {
            // Arrange
            const long curso1 = 111111;
            const long curso2 = 222222;
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ExcluirCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar($"{curso1},{curso2}");

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == curso1), It.IsAny<CancellationToken>()), Times.Once);
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == curso2), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Falha no primeiro item não deve interromper os itens seguintes e deve indicar falha")]
        public async Task Executar_FalhaNoPrimeiroItem_DeveContinuarItensSeguintesELancarNegocioException()
        {
            // Arrange
            const long curso1 = 111111;
            const long curso2 = 222222;

            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == curso1), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new GoogleApiException("GoogleClassroom", "Forbidden") { HttpStatusCode = HttpStatusCode.Forbidden });

            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == curso2), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar($"{curso1},{curso2}"));
            Assert.Equal(601, ex.StatusCode);

            // Verifica que curso 1 não foi removido localmente
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == curso1), It.IsAny<CancellationToken>()), Times.Never);
            // Verifica que curso 2 foi processado e removido localmente
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == curso2), It.IsAny<CancellationToken>()), Times.Once);
            // Verifica que log de falha do curso 1 foi gerado
            mediatorMock.Verify(m => m.Send(It.Is<SalvarLogViaRabbitCommand>(l => l.Mensagem.Contains(curso1.ToString())), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Falha intermediária não deve interromper os itens seguintes e deve indicar falha")]
        public async Task Executar_FalhaIntermediaria_DeveContinuarItensSeguintesELancarNegocioException()
        {
            // Arrange
            const long curso1 = 111111;
            const long curso2 = 222222;
            const long curso3 = 333333;

            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == curso1), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == curso2), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Erro inesperado"));

            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == curso3), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar($"{curso1},{curso2},{curso3}"));
            Assert.Equal(601, ex.StatusCode);

            // Verifica que curso 1 e curso 3 foram reconciliados
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == curso1), It.IsAny<CancellationToken>()), Times.Once);
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == curso3), It.IsAny<CancellationToken>()), Times.Once);
            // Curso 2 falhou e não foi reconciliado
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == curso2), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Theory(DisplayName = "Entrada inválida ou vazia deve lançar NegocioException com código 601")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(",,")]
        public async Task Executar_EntradaInvalidaOuVazia_DeveLancarNegocioException(string entrada)
        {
            // Act & Assert
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(entrada));
            Assert.Equal(601, ex.StatusCode);
        }

        [Fact(DisplayName = "Exclusão repetida não deve mascarar falha real e deve manter coerência")]
        public async Task Executar_ExclusaoRepetida_QuandoCursoJaExcluidoGoogle_DeveReconciliarSemLancarErro()
        {
            // Arrange
            const long cursoId = 886920262384;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoGoogleCommand>(c => c.CursoId == cursoId), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new GoogleApiException("GoogleClassroom", "Not Found") { HttpStatusCode = HttpStatusCode.NotFound });

            // Act - Primeira exclusão
            var resultado1 = await useCase.Executar(cursoId.ToString());
            // Act - Repetição da exclusão
            var resultado2 = await useCase.Executar(cursoId.ToString());

            // Assert
            Assert.True(resultado1);
            Assert.True(resultado2);
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == cursoId), It.IsAny<CancellationToken>()), Times.Exactly(2));
        }
    }
}
