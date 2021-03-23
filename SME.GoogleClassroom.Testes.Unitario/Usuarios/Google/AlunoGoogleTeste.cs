using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Usuarios.Google
{
    public class AlunoGoogleTeste
    {
        [Theory(DisplayName = "Formatação de nomes")]
        [InlineData("", "", "")]
        [InlineData("Carlos Augusto Ferreira Dias", "Augusto Ferreira Dias", "Carlos Augusto Ferreira Dias")]
        [InlineData("Maria Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos Fischer", "Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos", "Maria Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos")]
        public void FormatacaoNomes(string nome, string sobrenomeEsperado, string nomeEsperado)
        {
            var professor = new AlunoGoogle(1, nome, "email", "organizationPath");

            Assert.NotNull(professor);
            Assert.Equal(sobrenomeEsperado, professor.Sobrenome);
            Assert.Equal(nomeEsperado, professor.Nome);
        }
    }
}