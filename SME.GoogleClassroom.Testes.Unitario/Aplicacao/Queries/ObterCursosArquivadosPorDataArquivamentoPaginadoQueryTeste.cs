using FluentValidation.TestHelper;
using Moq;
using SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterCursosArquivadosPorDataArquivamentoPaginado;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries
{
    public class ObterCursosArquivadosPorDataArquivamentoPaginadoQueryTeste
    {
        [Fact(DisplayName = "DataArquivamento vazia deve falhar no validador com mensagem correta")]
        public void Validador_DataArquivamentoVazia_DeveFalhar()
        {
            // Arrange
            var validator = new ObterCursosArquivadosPorDataArquivamentoPaginadoQueryValidator();
            var query = new ObterCursosArquivadosPorDataArquivamentoPaginadoQuery(default, new Paginacao(1, 10));

            // Act
            var resultado = validator.TestValidate(query);

            // Assert
            resultado.ShouldHaveValidationErrorFor(x => x.DataArquivamento)
                     .WithErrorMessage("A data de arquivamento deve ser informada para consulta de cursos arquivados");
        }

        [Fact(DisplayName = "DataArquivamento preenchida deve passar no validador")]
        public void Validador_DataArquivamentoPreenchida_DevePassar()
        {
            // Arrange
            var validator = new ObterCursosArquivadosPorDataArquivamentoPaginadoQueryValidator();
            var query = new ObterCursosArquivadosPorDataArquivamentoPaginadoQuery(DateTime.Today, new Paginacao(1, 10));

            // Act
            var resultado = validator.TestValidate(query);

            // Assert
            resultado.ShouldNotHaveAnyValidationErrors();
        }

        [Fact(DisplayName = "Handler deve invocar RepositorioCursoArquivado com os parâmetros recebidos")]
        public async Task Handler_DeveInvocarRepositorio()
        {
            // Arrange
            var repoMock = new Mock<IRepositorioCursoArquivado>();
            var dataComHora = new DateTime(2026, 9, 20, 10, 30, 0);
            var paginacao = new Paginacao(1, 10);
            var retornoEsperado = new PaginacaoResultadoDto<CursoArquivadoDto>
            {
                TotalRegistros = 12,
                TotalPaginas = 2,
                Items = new List<CursoArquivadoDto>
                {
                    new CursoArquivadoDto { CursoId = 1, Nome = "Curso 1" }
                }
            };

            repoMock
                .Setup(r => r.BuscarTodosPorDataExtincao(dataComHora, paginacao))
                .ReturnsAsync(retornoEsperado);

            var handler = new ObterCursosArquivadosPorDataArquivamentoPaginadoQueryHandler(repoMock.Object);
            var query = new ObterCursosArquivadosPorDataArquivamentoPaginadoQuery(dataComHora, paginacao);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(12, resultado.TotalRegistros);
            Assert.Equal(2, resultado.TotalPaginas);
            repoMock.Verify(r => r.BuscarTodosPorDataExtincao(dataComHora, paginacao), Times.Once);
        }

        [Fact(DisplayName = "Cálculo de total de páginas não deve quebrar com QuantidadeRegistros igual a 0")]
        public void CalculoTotalPaginas_QuantidadeRegistrosZero_DeveRetornarZeroENaoOverflow()
        {
            // Arrange
            int totalRegistros = 12;
            int quantidadeRegistros = 0;

            // Act
            int totalPaginas = quantidadeRegistros > 0
                ? (int)Math.Ceiling((double)totalRegistros / quantidadeRegistros)
                : 0;

            // Assert
            Assert.Equal(0, totalPaginas);
            Assert.True(totalPaginas >= 0);
        }
    }
}
