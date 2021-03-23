using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes
{
    public class FuncionarioEolTeste
    {
        [Theory(DisplayName = "Definição de nome, considerando nome social")]
        [InlineData(1234567, "Maria de Jesus", "", "Maria de Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "Maria de Jesus", "José da Silva", "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "Maria de Jesus", "Maria Jesus", "Maria de Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "Maria de Jesus", "Maria", "Maria de Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "José da Silva", "José Gonçalves", "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br")]
        public void DefinicaoDeNome(long rf, string nomePessoa, string nomeSocial, string nomeEsperado, string emailEsperado)
        {
            var funcionarioEol = new FuncionarioEol(rf, nomePessoa, nomeSocial, string.Empty);

            Assert.NotNull(funcionarioEol);
            Assert.Equal(nomeEsperado, funcionarioEol.Nome);
            Assert.Equal(emailEsperado, funcionarioEol.Email);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(CorrectData))]
        public void GeracaoDeEmail(long rf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            var funcionario = new FuncionarioEol(rf, nomePessoa, nomeSocial, organizationPath);

            Assert.Equal(emailEsperado, funcionario.Email);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(WrongData))]
        public void GeracaoDeEmailErrado(long rf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            var funcionario = new FuncionarioEol(rf, nomePessoa, nomeSocial, organizationPath);

            Assert.NotEqual(emailEsperado, funcionario.Email);
        }

        public static readonly object[][] CorrectData =
        {
            new object[] { 0, "", "", "", null },
            new object[] { 1234567 , "Maria Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "João da Silva", "", "/FUNCIONARIO", "joaosilva.1234567@edu.sme.prefeitura.sp.gov.br" }
        };

        public static readonly object[][] WrongData =
        {
            new object[] { 1234567, "Maria Jesus", "", "/FUNCIONARIO", "mariaesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "", "/FUNCIONARIO", "marjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "", "/FUNCIONARIO", "marisus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "", "/FUNCIONARIO", "sjesus.06061992@edu.sme.prefeitura.sp.gov.br" }
        };
    }
}
