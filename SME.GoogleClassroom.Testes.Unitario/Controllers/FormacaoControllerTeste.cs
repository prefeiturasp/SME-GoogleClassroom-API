using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using SME.GoogleClassroom.Worker.Rabbit.Controllers;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Controllers
{
    public class FormacaoControllerTeste
    {
        private readonly FormacaoController controller;
        private readonly Mock<IListagemInscricoesConfirmadasUseCase> listagemInscricoesConfirmadasUseCaseMock;
        private readonly Mock<IListagemDetalhamentoFormacaoUseCase> listagemDetalhamentoFormacaoUseCaseMock;
        private readonly Mock<IListagemDeAreaPromotoraUseCase> listagemDeAreaPromotoraUseCaseMock;

        public FormacaoControllerTeste()
        {
            controller = new FormacaoController();
            listagemInscricoesConfirmadasUseCaseMock = new Mock<IListagemInscricoesConfirmadasUseCase>();
            listagemDetalhamentoFormacaoUseCaseMock = new Mock<IListagemDetalhamentoFormacaoUseCase>();
            listagemDeAreaPromotoraUseCaseMock = new Mock<IListagemDeAreaPromotoraUseCase>();
        }

        [Fact(DisplayName = "ListagemInscricoesConfirmadasPorTurma deve documentar status 200, 204, 401, 500 e 601")]
        public void ListagemInscricoesConfirmadasPorTurma_DeveDocumentarCodigosEsperados()
        {
            // Arrange
            var metodo = typeof(FormacaoController).GetMethod(nameof(FormacaoController.ListagemInscricoesConfirmadasPorTurma));

            // Act
            var statusCodes = metodo.GetCustomAttributes<ProducesResponseTypeAttribute>().Select(a => a.StatusCode).ToList();

            // Assert
            Assert.Contains(StatusCodes.Status200OK, statusCodes);
            Assert.Contains(StatusCodes.Status204NoContent, statusCodes);
            Assert.Contains(StatusCodes.Status401Unauthorized, statusCodes);
            Assert.Contains(StatusCodes.Status500InternalServerError, statusCodes);
            Assert.Contains(601, statusCodes);
        }

        [Fact(DisplayName = "ListagemInscricoesConfirmadasPorTurma sem resultados deve retornar StatusCode 204")]
        public async Task ListagemInscricoesConfirmadasPorTurma_SemInscricoes_DeveRetornar204()
        {
            // Arrange
            listagemInscricoesConfirmadasUseCaseMock
                .Setup(u => u.Executar(99999))
                .ReturnsAsync(new List<InscricaoRetornoDTO>());

            // Act
            var resultado = await controller.ListagemInscricoesConfirmadasPorTurma(99999, listagemInscricoesConfirmadasUseCaseMock.Object);

            // Assert
            var statusResult = Assert.IsType<StatusCodeResult>(resultado);
            Assert.Equal(StatusCodes.Status204NoContent, statusResult.StatusCode);
        }

        [Fact(DisplayName = "ListagemInscricoesConfirmadasPorTurma com resultados deve retornar 200 OK")]
        public async Task ListagemInscricoesConfirmadasPorTurma_ComInscricoes_DeveRetornar200Ok()
        {
            // Arrange
            var lista = new List<InscricaoRetornoDTO>
            {
                new InscricaoRetornoDTO { CodigoRf = "1234567", Nome = "TESTE" }
            };

            listagemInscricoesConfirmadasUseCaseMock
                .Setup(u => u.Executar(1541))
                .ReturnsAsync(lista);

            // Act
            var resultado = await controller.ListagemInscricoesConfirmadasPorTurma(1541, listagemInscricoesConfirmadasUseCaseMock.Object);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact(DisplayName = "ListagemDetalhamentoFormacaoPorAno deve documentar status 200, 204, 401, 500 e 601")]
        public void ListagemDetalhamentoFormacaoPorAno_DeveDocumentarCodigosEsperados()
        {
            // Arrange
            var metodo = typeof(FormacaoController).GetMethod(nameof(FormacaoController.ListagemDetalhamentoFormacaoPorAno));

            // Act
            var statusCodes = metodo.GetCustomAttributes<ProducesResponseTypeAttribute>().Select(a => a.StatusCode).ToList();

            // Assert
            Assert.Contains(StatusCodes.Status200OK, statusCodes);
            Assert.Contains(StatusCodes.Status204NoContent, statusCodes);
            Assert.Contains(StatusCodes.Status401Unauthorized, statusCodes);
            Assert.Contains(StatusCodes.Status500InternalServerError, statusCodes);
            Assert.Contains(601, statusCodes);
        }

        [Fact(DisplayName = "ListagemDetalhamentoFormacaoPorAno sem resultados deve retornar StatusCode 204")]
        public async Task ListagemDetalhamentoFormacaoPorAno_SemFormacoes_DeveRetornar204()
        {
            // Arrange
            listagemDetalhamentoFormacaoUseCaseMock
                .Setup(u => u.Executar(2024, 11))
                .ReturnsAsync(new List<FormacaoDetalhaDTO>());

            // Act
            var resultado = await controller.ListagemDetalhamentoFormacaoPorAno(2024, 11, listagemDetalhamentoFormacaoUseCaseMock.Object);

            // Assert
            var statusResult = Assert.IsType<StatusCodeResult>(resultado);
            Assert.Equal(StatusCodes.Status204NoContent, statusResult.StatusCode);
        }

        [Fact(DisplayName = "ListagemAreaPromotora deve documentar status 200, 401, 500 e não conter 601")]
        public void ListagemAreaPromotora_DeveDocumentarCodigosEsperados()
        {
            // Arrange
            var metodo = typeof(FormacaoController).GetMethod(nameof(FormacaoController.ListagemAreaPromotora));

            // Act
            var statusCodes = metodo.GetCustomAttributes<ProducesResponseTypeAttribute>().Select(a => a.StatusCode).ToList();

            // Assert
            Assert.Contains(StatusCodes.Status200OK, statusCodes);
            Assert.Contains(StatusCodes.Status401Unauthorized, statusCodes);
            Assert.Contains(StatusCodes.Status500InternalServerError, statusCodes);
            Assert.DoesNotContain(601, statusCodes);
        }
    }
}
