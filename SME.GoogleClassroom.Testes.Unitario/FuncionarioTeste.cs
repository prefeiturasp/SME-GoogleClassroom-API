using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes
{
    public class FuncionarioTeste
    {
        [Theory(DisplayName = "Formatação de nomes")]
        [InlineData("", "", "")]
        [InlineData("Carlos Augusto Ferreira Dias", "Augusto Ferreira Dias", "Carlos Augusto Ferreira Dias")]
        [InlineData("Maria Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos Fischer", "Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos", "Maria Aparecida da Silva Agnaldo José Kentucky Gonçalvez de Lemos")]
        public void FormatacaoNomes(string nome, string sobrenomeEsperado, string nomeEsperado)
        {
            var professor = new ProfessorGoogle(1, nome, "email", "organizationPath");

            Assert.NotNull(professor);
            Assert.Equal(sobrenomeEsperado, professor.Sobrenome);
            Assert.Equal(nomeEsperado, professor.Nome);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(CorrectData))]
        public void GeracaoDeEmail(long rf, string nome, string organizationPath, string emailEsperado)
        {
            FuncionarioEol funcionario = new FuncionarioEol(rf, nome, organizationPath);

            Assert.Equal(emailEsperado, funcionario.Email);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(WrongData))]
        public void GeracaoDeEmailErrado(long rf, string nome, string organizationPath, string emailEsperado)
        {
            FuncionarioEol funcionario = new FuncionarioEol(rf, nome, organizationPath);

            Assert.NotEqual(emailEsperado, funcionario.Email);
        }

        public static readonly object[][] CorrectData =
        {
            new object[] { 0, "", "", "" },
            new object[] { 1234567 , "Maria Jesus", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "João da Silva", "/FUNCIONARIO", "joaosilva.1234567@edu.sme.prefeitura.sp.gov.br" }
        };

        public static readonly object[][] WrongData =
        {
            new object[] { 1234567, "Maria Jesus", "/FUNCIONARIO", "mariaesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "/FUNCIONARIO", "marjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "/FUNCIONARIO", "marisus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "/FUNCIONARIO", "sjesus.06061992@edu.sme.prefeitura.sp.gov.br" }
        };
    }
}
