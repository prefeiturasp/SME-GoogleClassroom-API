using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes
{
    public class FuncionarioEolTeste
    {
        [Theory(DisplayName = "Valida a definição do nome e e-mail tratando nome social.")]
        [InlineData(1234567, "Maria de Jesus", "", "Maria de Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "Maria de Jesus", "José da Silva", "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "Maria de Jesus", "Maria Jesus", "Maria de Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "Maria de Jesus", "Maria", "Maria de Jesus", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br")]
        [InlineData(1234567, "José da Silva", "José Gonçalves", "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br")]
        public void Valida_Definicao_Do_Nome_E_Email_Valido_Passando_Os_Resultados_Esperados(long rf, string nomePessoa, string nomeSocial, string nomeEsperado, string emailEsperado)
        {
            // Arrange
            var funcionarioEol = new FuncionarioEol(rf, nomePessoa, nomeSocial, string.Empty);

            // Assert
            Assert.NotNull(funcionarioEol);
            Assert.Equal(nomeEsperado, funcionarioEol.Nome);
            Assert.Equal(emailEsperado, funcionarioEol.Email);
        }

        [Theory(DisplayName = "Valida a geração de e-mail válido de aluno."), MemberData(nameof(DadosParaValidacaoDeEmailValido))]
        public void Valida_Geracao_Email_Valido_Passando_O_Resultado_Esperado(long rf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            // Arrange
            var funcionario = new FuncionarioEol(rf, nomePessoa, nomeSocial, organizationPath);

            // Assert
            Assert.Equal(emailEsperado, funcionario.Email);
        }

        [Theory(DisplayName = "Valida a geração de e-mail inválido de aluno."), MemberData(nameof(DadosParaValidacaoDeEmailInvalido))]
        public void Valida_Geracao_Email_Invalido_Passando_O_Resultado_Esperado(long rf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            // Arrange
            var funcionario = new FuncionarioEol(rf, nomePessoa, nomeSocial, organizationPath);

            // Assert
            Assert.NotEqual(emailEsperado, funcionario.Email);
        }

        public static readonly object[][] DadosParaValidacaoDeEmailValido =
        {
            new object[] { 0, "", "", "", null },
            new object[] { 1234567 , "Maria Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "", "/FUNCIONARIO", "mariajesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "João da Silva", "", "/FUNCIONARIO", "joaosilva.1234567@edu.sme.prefeitura.sp.gov.br" }
        };

        public static readonly object[][] DadosParaValidacaoDeEmailInvalido =
        {
            new object[] { 1234567, "Maria Jesus", "", "/FUNCIONARIO", "mariaesus.1234567@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Jesus", "", "/FUNCIONARIO", "marjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza Santos Jesus", "", "/FUNCIONARIO", "marisus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 1234567, "Maria Tereza de Santos Jesus", "", "/FUNCIONARIO", "sjesus.06061992@edu.sme.prefeitura.sp.gov.br" }
        };
    }
}
