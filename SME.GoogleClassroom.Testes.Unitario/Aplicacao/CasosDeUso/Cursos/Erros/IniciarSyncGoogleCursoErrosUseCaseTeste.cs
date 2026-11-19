using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos.Erros
{
    public class IniciarSyncGoogleCursoErrosUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly IniciarSyncGoogleCursoErrosUseCase useCase;

        public IniciarSyncGoogleCursoErrosUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new IniciarSyncGoogleCursoErrosUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Construtor deve lançar ArgumentNullException quando mediator for nulo")]
        public void Construtor_MediatorNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new IniciarSyncGoogleCursoErrosUseCase(null));
        }

        [Fact(DisplayName = "Executar deve publicar na fila FilaCursoErroSync e retornar true em caso de sucesso")]
        public async Task Executar_PublicacaoComSucesso_DeveRetornarTrue()
        {
            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaCursoErroSync && c.NomeRota == RotasRabbit.FilaCursoErroSync), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await useCase.Executar();

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaCursoErroSync), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Executar deve lançar NegocioException (601) quando a publicação na fila retornar false")]
        public async Task Executar_FalhaNaPublicacao_DeveLancarNegocioException()
        {
            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar());

            Assert.Equal("Não foi possível iniciar a sincronização de Cursos Erro.", ex.Message);
        }
    }
}
