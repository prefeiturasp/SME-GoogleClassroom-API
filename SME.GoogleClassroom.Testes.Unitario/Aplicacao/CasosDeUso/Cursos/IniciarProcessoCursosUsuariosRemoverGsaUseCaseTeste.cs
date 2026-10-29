using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos
{
    public class IniciarProcessoCursosUsuariosRemoverGsaUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly IniciarProcessoCursosUsuariosRemoverGsaUseCase useCase;

        public IniciarProcessoCursosUsuariosRemoverGsaUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new IniciarProcessoCursosUsuariosRemoverGsaUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "TurmaId inexistente deve lançar NegocioException (601) e não publicar")]
        public async Task Executar_TurmaInexistente_DeveLancarNegocioException()
        {
            long turmaId = 9999999999999;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorCodigoQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(turmaId, false, false));

            Assert.Equal(601, ex.StatusCode);
            mediatorMock.Verify(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "TurmaId existente deve publicar e retornar true")]
        public async Task Executar_TurmaExistente_DevePublicarERetornarTrue()
        {
            long turmaId = 1296019;
            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorCodigoQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            mediatorMock
                .Setup(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeRota == RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await useCase.Executar(turmaId, false, false);

            Assert.True(resultado);
        }

        [Fact(DisplayName = "Sem TurmaId deve publicar sem validar turma")]
        public async Task Executar_SemTurmaId_DevePublicarSemValidar()
        {
            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await useCase.Executar(null, false, false);

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExisteTurmaPorCodigoQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Falha na publicação não deve retornar sucesso")]
        public async Task Executar_FalhaNaPublicacao_DeveLancarNegocioException()
        {
            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(null, false, false));
        }
    }
}