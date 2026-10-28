using FluentValidation.TestHelper;
using SME.GoogleClassroom.Aplicacao;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.ConectaFormacao
{
    public class ListagemInscricoesConfirmadasQueryValidatorTeste
    {
        private readonly ListagemInscricoesConfirmadasQueryValidator validator;

        public ListagemInscricoesConfirmadasQueryValidatorTeste()
        {
            validator = new ListagemInscricoesConfirmadasQueryValidator();
        }

        [Theory(DisplayName = "Código da turma zerado ou negativo deve gerar exatamente uma falha de validação")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validar_CodigoDaTurmaInvalido_DeveRetornarApenasUmaMensagem(long codigoTurma)
        {
            // Arrange
            var query = new ListagemInscricoesConfirmadasQuery(codigoTurma);

            // Act
            var resultado = validator.TestValidate(query);

            // Assert
            resultado.ShouldHaveValidationErrorFor(x => x.CodigoDaTurma)
                .WithErrorMessage("O código da turma deve ser informado para a listagem de inscrições confirmadas.");

            Assert.Single(resultado.Errors);
        }

        [Fact(DisplayName = "Código da turma positivo deve ser considerado válido")]
        public void Validar_CodigoDaTurmaValido_NaoDeveConterErros()
        {
            // Arrange
            var query = new ListagemInscricoesConfirmadasQuery(1541);

            // Act
            var resultado = validator.TestValidate(query);

            // Assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.CodigoDaTurma);
            Assert.Empty(resultado.Errors);
        }
    }
}
