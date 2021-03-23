using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario
{
    public class FuncionarioIndiretoEolTeste
    {
        [Theory(DisplayName = "Definição de nome, considerando nome social")]
        [InlineData("28541640086", "Maria de Jesus", "", "Maria de Jesus", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "Maria de Jesus", "José da Silva", "José da Silva", "josesilva.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "Maria de Jesus", "Maria Jesus", "Maria de Jesus", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "Maria de Jesus", "Maria", "Maria de Jesus", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "José da Silva", "José Gonçalves", "José da Silva", "josesilva.28541640086@edu.sme.prefeitura.sp.gov.br")]
        public void DefinicaoDeNome(string cpf, string nomePessoa, string nomeSocial, string nomeEsperado, string emailEsperado)
        {
            var funcionarioEol = new FuncionarioIndiretoEol(cpf, nomePessoa, nomeSocial, string.Empty);

            Assert.NotNull(funcionarioEol);
            Assert.Equal(nomeEsperado, funcionarioEol.Nome);
            Assert.Equal(emailEsperado, funcionarioEol.Email);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(CorrectData))]
        public void GeracaoDeEmail(string cpf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            var funcionario = new FuncionarioIndiretoEol(cpf, nomePessoa, nomeSocial, organizationPath);

            Assert.Equal(emailEsperado, funcionario.Email);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(WrongData))]
        public void GeracaoDeEmailErrado(string cpf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            var funcionario = new FuncionarioIndiretoEol(cpf, nomePessoa, nomeSocial, organizationPath);

            Assert.NotEqual(emailEsperado, funcionario.Email);
        }

        public static readonly object[][] CorrectData =
        {
            new object[] { 0, "", "", "", null },
            new object[] { 28541640086 , "Maria Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Santos Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza de Santos Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "João da Silva", "", "/Professores/Conveniadas", "joaosilva.28541640086@edu.sme.prefeitura.sp.gov.br" }
        };

        public static readonly object[][] WrongData =
        {
            new object[] { 28541640086, "Maria Jesus", "", "/Professores/Conveniadas", "mariaesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Jesus", "", "/Professores/Conveniadas", "marjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Santos Jesus", "", "/Professores/Conveniadas", "marisus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza de Santos Jesus", "", "/Professores/Conveniadas", "sjesus.06061992@edu.sme.prefeitura.sp.gov.br" }
        };
    }
}