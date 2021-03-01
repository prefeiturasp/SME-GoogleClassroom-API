using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes
{
    public class ProfessorTeste
    {
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
