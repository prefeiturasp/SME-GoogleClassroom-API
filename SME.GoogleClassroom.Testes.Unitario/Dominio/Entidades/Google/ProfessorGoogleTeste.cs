using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Dominio.Entidades.Google
{
    public class ProfessorGoogleTeste
    {
        [Theory(DisplayName = "Valida o tratamento da formatação de nomes.")]
        [InlineData("", "", "")]
        [InlineData("Carlos Augusto Ferreira Dias", "Augusto Ferreira Dias", "Carlos Augusto Ferreira Dias")]
        [InlineData("Maria Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos Fischer", "Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos", "Maria Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos")]
        public void Valida_Tratamento_Da_Formatacao_De_Nomes_Passandos_Os_Resultados_Esperados(string nome, string sobrenomeEsperado, string nomeEsperado)
        {
            // Arrange
            var professor = new ProfessorGoogle(1, nome, "email", "organizationPath");

            // Assert
            Assert.NotNull(professor);
            Assert.Equal(sobrenomeEsperado, professor.Sobrenome);
            Assert.Equal(nomeEsperado, professor.Nome);
        }
    }
}