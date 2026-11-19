using FluentValidation.TestHelper;
using Moq;
using SME.GoogleClassroom.Aplicacao;
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
    public class ObterCursosExtintosPorPeriodoPaginadoQueryTeste
    {
        [Fact(DisplayName = "Construtor deve atribuir ParametrosCargaInicialDto corretamente")]
        public void Construtor_DeveAtribuirParametrosCargaInicialDto()
        {
            // Arrange
            var parametrosCarga = new ParametrosCargaInicialDto();
            var dataInicio = DateTime.Today.AddDays(-10);
            var dataFim = DateTime.Today;
            var anoLetivo = 2026;
            long? turmaId = 12345;
            var paginacao = new Paginacao(1, 10);

            // Act
            var query = new ObterCursosExtintosPorPeriodoPaginadoQuery(parametrosCarga, dataInicio, dataFim, anoLetivo, turmaId, paginacao);

            // Assert
            Assert.NotNull(query.ParametrosCargaInicialDto);
            Assert.Same(parametrosCarga, query.ParametrosCargaInicialDto);
            Assert.Equal(dataInicio, query.DataInicio);
            Assert.Equal(dataFim, query.DataFim);
            Assert.Equal(anoLetivo, query.AnoLetivo);
            Assert.Equal(turmaId, query.TurmaId);
            Assert.Equal(paginacao, query.Paginacao);
        }

        [Fact(DisplayName = "Validador deve falhar quando ParametrosCargaInicialDto for nulo")]
        public void Validador_ParametrosCargaInicialNulo_DeveFalhar()
        {
            // Arrange
            var validator = new ObterCursosExtintosPorPeriodoPaginadoQueryValidator();
            var query = new ObterCursosExtintosPorPeriodoPaginadoQuery(null, DateTime.Today.AddDays(-1), DateTime.Today, 2026, null, new Paginacao(1, 10));

            // Act
            var resultado = validator.TestValidate(query);

            // Assert
            resultado.ShouldHaveValidationErrorFor(x => x.ParametrosCargaInicialDto)
                     .WithErrorMessage("A configuração de parâmetros deve ser informada.");
        }

        [Fact(DisplayName = "Validador deve passar quando todos os dados obrigatórios estiverem preenchidos")]
        public void Validador_DadosCompletos_DevePassar()
        {
            // Arrange
            var validator = new ObterCursosExtintosPorPeriodoPaginadoQueryValidator();
            var parametros = new ParametrosCargaInicialDto();
            var query = new ObterCursosExtintosPorPeriodoPaginadoQuery(parametros, DateTime.Today.AddDays(-1), DateTime.Today, 2026, null, new Paginacao(1, 10));

            // Act
            var resultado = validator.TestValidate(query);

            // Assert
            resultado.ShouldNotHaveAnyValidationErrors();
        }

        [Fact(DisplayName = "Handler deve invocar RepositorioCursoEol com parâmetros corretos")]
        public async Task Handler_DeveInvocarRepositorioComSucesso()
        {
            // Arrange
            var repoMock = new Mock<IRepositorioCursoEol>();
            var retornoEsperado = new PaginacaoResultadoDto<CursoExtintoEolDto>
            {
                TotalRegistros = 1,
                TotalPaginas = 1,
                Items = new List<CursoExtintoEolDto>
                {
                    new CursoExtintoEolDto { TurmaId = 123, DataExtincao = DateTime.Today }
                }
            };

            repoMock.Setup(r => r.ObterCursosExtintosPorPeriodoPaginado(
                It.IsAny<ParametrosCargaInicialDto>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>(),
                It.IsAny<int>(),
                It.IsAny<long?>(),
                It.IsAny<Paginacao>()))
                .ReturnsAsync(retornoEsperado);

            var handler = new ObterCursosExtintosPorPeriodoPaginadoQueryHandler(repoMock.Object);
            var query = new ObterCursosExtintosPorPeriodoPaginadoQuery(new ParametrosCargaInicialDto(), DateTime.Today.AddDays(-5), DateTime.Today, 2026, 123, new Paginacao(1, 10));

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.TotalRegistros);
            repoMock.Verify(r => r.ObterCursosExtintosPorPeriodoPaginado(
                query.ParametrosCargaInicialDto,
                query.DataInicio,
                query.DataFim,
                query.AnoLetivo,
                query.TurmaId,
                query.Paginacao), Times.Once);
        }
    }
}
