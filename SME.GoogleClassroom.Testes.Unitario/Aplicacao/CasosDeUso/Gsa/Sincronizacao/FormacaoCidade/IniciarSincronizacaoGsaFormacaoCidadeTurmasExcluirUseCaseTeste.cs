using System;
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
            await useCase.Executar(cursoId.ToString());

            // Assert
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

            // Act
            await useCase.Executar(cursoId.ToString());

            // Assert
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
            await useCase.Executar(cursoId.ToString());

            // Assert
            mediatorMock.Verify(m => m.Send(
                It.Is<ExcluirCursoGsaCommand>(c => c.CursoId == cursoId),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
