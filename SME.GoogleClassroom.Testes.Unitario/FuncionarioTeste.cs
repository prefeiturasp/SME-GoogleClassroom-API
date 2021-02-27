using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes
{
    public class FuncionarioTeste
    {
        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(CorrectData))]
        public void GeracaoDeEmail(long rf, string nome, string emailEsperado)
        {
            Funcionario funcionario = new Funcionario(rf, nome);

            Assert.Equal(emailEsperado, funcionario.Email);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(WrongData))]
        public void GeracaoDeEmailErrado(long rf, string nome, string emailEsperado)
        {
            Funcionario funcionario = new Funcionario(rf, nome);

            Assert.NotEqual(emailEsperado, funcionario.Email);
        }

        public static readonly object[][] CorrectData =
        {
            new object[] { 0, "", "" },
            new object[] { 1234567 , "Maria Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" }
        };

        public static readonly object[][] WrongData =
        {
            new object[] { 1234567, "Maria Jesus", "mariaesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "marjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "marisus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "sjesus.06061992@edu.sme.prefeitura.sp.gov.br" }
        };
    }
}
