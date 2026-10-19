using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Controllers;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Controllers
{
    public class EscolaControllerTeste
    {
        private readonly EscolaController controller;
        private readonly Mock<IObterEscolasUseCase> obterEscolasUseCaseMock;

        public EscolaControllerTeste()
        {
            controller = new EscolaController();
            obterEscolasUseCaseMock = new Mock<IObterEscolasUseCase>();
        }

        [Fact(DisplayName = "ObterEscolas não deve possuir o atributo LimparLixo")]
        public void ObterEscolas_NaoDevePossuirAtributoLimparLixo()
        {
            // Arrange
            var metodo = typeof(EscolaController).GetMethod(nameof(EscolaController.ObterEscolas));

            // Act
            var atributoLimparLixo = metodo.GetCustomAttribute<LimparLixoAttribute>();

            // Assert
            Assert.Null(atributoLimparLixo);
        }

        [Fact(DisplayName = "ObterEscolas deve documentar códigos de resposta HTTP 200, 204, 401, 500 e 601")]
        public void ObterEscolas_DeveDocumentarCodigosDeRespostaEsperados()
        {
            // Arrange
            var metodo = typeof(EscolaController).GetMethod(nameof(EscolaController.ObterEscolas));

            // Act
            var atributosProduces = metodo.GetCustomAttributes<ProducesResponseTypeAttribute>().ToList();
            var statusCodes = atributosProduces.Select(a => a.StatusCode).ToList();

            // Assert
            Assert.Contains(StatusCodes.Status200OK, statusCodes);
            Assert.Contains(StatusCodes.Status204NoContent, statusCodes);
            Assert.Contains(StatusCodes.Status401Unauthorized, statusCodes);
            Assert.Contains(StatusCodes.Status500InternalServerError, statusCodes);
            Assert.Contains(601, statusCodes);

            var okAttribute = atributosProduces.First(a => a.StatusCode == StatusCodes.Status200OK);
            Assert.Equal(typeof(IReadOnlyList<EscolaDTO>), okAttribute.Type);
        }

        [Fact(DisplayName = "ObterEscolas quando houver escolas deve retornar 200 OK com a lista")]
        public async Task ObterEscolas_QuandoHouverEscolas_DeveRetornar200Ok()
        {
            // Arrange
            var filtro = new FiltroObterEscolasDto();
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

            obterEscolasUseCaseMock
                .Setup(u => u.Executar(filtro))
                .ReturnsAsync(escolasEsperadas);

            // Act
            var resultado = await controller.ObterEscolas(obterEscolasUseCaseMock.Object, filtro);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(escolasEsperadas, okResult.Value);
        }

        [Fact(DisplayName = "ObterEscolas quando não houver escolas deve retornar StatusCode 204 No Content")]
        public async Task ObterEscolas_QuandoNaoHouverEscolas_DeveRetornarStatusCode204()
        {
            // Arrange
            var filtro = new FiltroObterEscolasDto();
            obterEscolasUseCaseMock
                .Setup(u => u.Executar(filtro))
                .ReturnsAsync(new List<EscolaDTO>());

            // Act
            var resultado = await controller.ObterEscolas(obterEscolasUseCaseMock.Object, filtro);

            // Assert
            var statusResult = Assert.IsType<StatusCodeResult>(resultado);
            Assert.Equal(StatusCodes.Status204NoContent, statusResult.StatusCode);
        }
    }
}
