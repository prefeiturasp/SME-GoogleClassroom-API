using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Gsa.Atividades
{
    public class ObterAtividadesUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly ObterAtividadesUseCase useCase;

        public ObterAtividadesUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new ObterAtividadesUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "UseCase deve enviar AtividadesQuery e retornar PaginacaoResultadoDto de AtividadeDto")]
        public async Task Executar_DeveEnviarAtividadesQueryERetornarPaginacaoResultadoDtoAtividadeDto()
        {
            // Arrange
            var filtro = new FiltroAtividadesDto
            {
                DataReferencia = new DateTime(2021, 5, 10),
                CursoId = 12345,
                PaginaNumero = 1,
                RegistrosQuantidade = 10
            };

            var retornoEsperado = new PaginacaoResultadoDto<AtividadeDto>
            {
                TotalPaginas = 1,
                TotalRegistros = 1,
                Items = new List<AtividadeDto>
                {
                    new AtividadeDto
                    {
                        Id = 1,
                        Titulo = "Atividade 1",
                        CursoGsaId = 12345
                    }
                }
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<AtividadesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(retornoEsperado);

            // Act
            var resultado = await useCase.Executar(filtro);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(retornoEsperado, resultado);
            mediatorMock.Verify(m => m.Send(
                It.Is<AtividadesQuery>(q => q.DataReferencia == filtro.DataReferencia &&
                                            q.CursoId == filtro.CursoId &&
                                            q.Paginacao.Pagina == 1 &&
                                            q.Paginacao.QuantidadeRegistros == 10),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
