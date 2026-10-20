using System;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries
{
    public class PaginacaoConsultasAtribuicoesProfessoresValidacaoTeste
    {
        [Theory(DisplayName = "ObterAtribuicoesDeCursosDoProfessorQueryValidator deve invalidar quando registrosQuantidade ou pagina for menor ou igual a zero")]
        [InlineData(0, 1)]
        [InlineData(-1, 1)]
        [InlineData(10, 0)]
        [InlineData(10, -1)]
        public void ObterAtribuicoesDeCursosDoProfessorQueryValidator_DeveInvalidarPaginacaoInvalida(int registrosQuantidade, int paginaNumero)
        {
            // Arrange
            var validator = new ObterAtribuicoesDeCursosDoProfessorQueryValidator();
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            var query = new ObterAtribuicoesDeCursosDosProfessoresQuery(DateTime.Today, paginacao, new ParametrosCargaInicialDto());

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.ErrorMessage == "O número da página e a quantidade de registro devem ser informados.");
        }

        [Fact(DisplayName = "ObterAtribuicoesDeCursosDoProfessorQueryValidator deve validar quando paginacao for valida")]
        public void ObterAtribuicoesDeCursosDoProfessorQueryValidator_DeveValidarPaginacaoValida()
        {
            // Arrange
            var validator = new ObterAtribuicoesDeCursosDoProfessorQueryValidator();
            var paginacao = new Paginacao(1, 20);
            var query = new ObterAtribuicoesDeCursosDosProfessoresQuery(DateTime.Today, paginacao, new ParametrosCargaInicialDto());

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.True(resultado.IsValid);
        }

        [Theory(DisplayName = "ObterProfessoresParaRemoverCursoPaginadoQueryValidator deve invalidar quando registrosQuantidade ou pagina for menor ou igual a zero")]
        [InlineData(0, 1)]
        [InlineData(-1, 1)]
        [InlineData(10, 0)]
        [InlineData(10, -1)]
        public void ObterProfessoresParaRemoverCursoPaginadoQueryValidator_DeveInvalidarPaginacaoInvalida(int registrosQuantidade, int paginaNumero)
        {
            // Arrange
            var validator = new ObterProfessoresParaRemoverCursoPaginadoQueryValidator();
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            var query = new ObterProfessoresParaRemoverCursoPaginadoQuery("12345", DateTime.Today.AddDays(-10), DateTime.Today, paginacao);

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.ErrorMessage == "O número da página e a quantidade de registro devem ser informados.");
        }

        [Fact(DisplayName = "ObterProfessoresParaRemoverCursoPaginadoQueryValidator deve validar quando paginacao for valida")]
        public void ObterProfessoresParaRemoverCursoPaginadoQueryValidator_DeveValidarPaginacaoValida()
        {
            // Arrange
            var validator = new ObterProfessoresParaRemoverCursoPaginadoQueryValidator();
            var paginacao = new Paginacao(1, 20);
            var query = new ObterProfessoresParaRemoverCursoPaginadoQuery("12345", DateTime.Today.AddDays(-10), DateTime.Today, paginacao);

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.True(resultado.IsValid);
        }
    }
}
