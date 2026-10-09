using System;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Atividades
{
    public class AtividadesQueryValidatorTeste
    {
        private readonly AtividadesQueryValidator validator;

        public AtividadesQueryValidatorTeste()
        {
            validator = new AtividadesQueryValidator();
        }

        [Fact(DisplayName = "Validação deve passar quando DataReferencia é informada")]
        public void Validar_QuandoDataReferenciaValida_DeveSerValido()
        {
            // Arrange
            var query = new AtividadesQuery(new Paginacao(1, 20), DateTime.Today, 123);

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.True(resultado.IsValid);
        }

        [Fact(DisplayName = "Validação deve falhar quando DataReferencia é nula/vazia")]
        public void Validar_QuandoDataReferenciaVazia_DeveRetornarErro()
        {
            // Arrange
            var query = new AtividadesQuery(new Paginacao(1, 20), default, 123);

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.ErrorMessage == "Parâmetro data de referência não pode ser nulo");
        }
    }
}
