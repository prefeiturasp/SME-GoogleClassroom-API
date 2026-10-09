using System.Threading;
using System.Threading.Tasks;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Commands.Gsa.Cursos.ExcluirCursoGsa
{
    public class ExcluirCursoGsaCommandHandlerTeste
    {
        private readonly Mock<IRepositorioCursoGsa> repositorioCursoGsaMock;
        private readonly ExcluirCursoGsaCommandHandler handler;

        public ExcluirCursoGsaCommandHandlerTeste()
        {
            repositorioCursoGsaMock = new Mock<IRepositorioCursoGsa>();
            handler = new ExcluirCursoGsaCommandHandler(repositorioCursoGsaMock.Object);
        }

        [Fact(DisplayName = "Handler deve invocar exclusão no repositório com o id informado")]
        public async Task Handle_DeveInvocarExclusaoNoRepositorioComIdInformado()
        {
            // Arrange
            const long cursoId = 886920262384;
            repositorioCursoGsaMock
                .Setup(r => r.ExcluirCursoGsaAsync(cursoId))
                .ReturnsAsync(true);

            var command = new ExcluirCursoGsaCommand(cursoId);

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado);
            repositorioCursoGsaMock.Verify(r => r.ExcluirCursoGsaAsync(cursoId), Times.Once);
        }
    }
}
