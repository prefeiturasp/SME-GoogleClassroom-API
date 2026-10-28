using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Escolas
{
    public class ObterEscolasUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly ObterEscolasUseCase useCase;

        public ObterEscolasUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new ObterEscolasUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "UseCase deve consultar tipo_escola_sgp e repassar filtros para ObterEscolasPorTipoEscolaQuery")]
        public async Task Executar_DeveConsultarParametroERepassarFiltros()
        {
            // Arrange
            var parametro = new ParametroAPIEol
            {
                Nome = "tipo_escola_sgp",
                Valor = "1,3,10"
            };

            var filtro = new FiltroObterEscolasDto
            {
                CodigoDRE = "108100",
                SiglaTipoEscola = "EMEF"
            };

            var retornoEsperado = new List<EscolaDTO>
            {
                new EscolaDTO
                {
                    Codigo = "019715",
                    Nome = "ADALGIZA SEGURADO DA SILVEIRA, PROFA.",
                    CodigoDRE = "108100",
                    SiglaTipoEscola = "EMEF"
                }
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterParametrosAPIEolPorNomeQuery>(q => q.Nome == "tipo_escola_sgp"), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametro);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterEscolasPorTipoEscolaQuery>(q =>
                    q.CodigoDRE == filtro.CodigoDRE &&
                    q.SiglaTipoEscola == filtro.SiglaTipoEscola &&
                    q.TiposEscola.SequenceEqual(new[] { 1, 3, 10 })), It.IsAny<CancellationToken>()))
                .ReturnsAsync(retornoEsperado);

            // Act
            var resultado = (await useCase.Executar(filtro)).ToList();

            // Assert
            Assert.NotNull(resultado);
            Assert.Single(resultado);
            Assert.Equal("019715", resultado[0].Codigo);

            mediatorMock.Verify(m => m.Send(It.IsAny<ObterParametrosAPIEolPorNomeQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediatorMock.Verify(m => m.Send(It.IsAny<ObterEscolasPorTipoEscolaQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
