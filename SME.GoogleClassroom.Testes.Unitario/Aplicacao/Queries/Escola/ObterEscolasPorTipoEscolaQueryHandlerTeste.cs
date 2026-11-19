using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Escola
{
    public class ObterEscolasPorTipoEscolaQueryHandlerTeste
    {
        private readonly Mock<IRepositorioEscolaEol> repositorioEscolaMock;
        private readonly ObterEscolasPorTipoEscolaQueryHandler handler;

        public ObterEscolasPorTipoEscolaQueryHandlerTeste()
        {
            repositorioEscolaMock = new Mock<IRepositorioEscolaEol>();
            handler = new ObterEscolasPorTipoEscolaQueryHandler(repositorioEscolaMock.Object);
        }

        [Fact(DisplayName = "Handler deve repassar parâmetros corretamente ao repositório de escolas")]
        public async Task Handle_DeveRepassarParametrosAoRepositorio()
        {
            // Arrange
            var tiposEscola = new[] { 1, 3 };
            var codigoDre = "108100";
            var siglaTipoEscola = "EMEF";

            var escolasEsperadas = new List<EscolaDTO>
            {
                new EscolaDTO
                {
                    Codigo = "019715",
                    Nome = "ADALGIZA SEGURADO DA SILVEIRA, PROFA.",
                    CodigoDRE = "108100",
                    SiglaTipoEscola = "EMEF"
                }
            };

            repositorioEscolaMock
                .Setup(r => r.ObterEscolas(tiposEscola, codigoDre, siglaTipoEscola))
                .ReturnsAsync(escolasEsperadas);

            var query = new ObterEscolasPorTipoEscolaQuery(tiposEscola, codigoDre, siglaTipoEscola);

            // Act
            var resultado = (await handler.Handle(query, CancellationToken.None)).ToList();

            // Assert
            Assert.NotNull(resultado);
            Assert.Single(resultado);
            Assert.Equal("019715", resultado[0].Codigo);
            Assert.Equal("ADALGIZA SEGURADO DA SILVEIRA, PROFA.", resultado[0].Nome);
            Assert.Equal("108100", resultado[0].CodigoDRE);
            Assert.Equal("EMEF", resultado[0].SiglaTipoEscola);

            repositorioEscolaMock.Verify(r => r.ObterEscolas(tiposEscola, codigoDre, siglaTipoEscola), Times.Once);
        }
    }
}
