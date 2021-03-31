using SME.GoogleClassroom.Dominio;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario
{
    public class FuncionarioIndiretoEolTeste
    {
        [Theory(DisplayName = "Valida a definição do nome e e-mail tratando nome social.")]
        [InlineData("28541640086", "Maria de Jesus", "", "Maria de Jesus", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "Maria de Jesus", "José da Silva", "José da Silva", "josesilva.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "Maria de Jesus", "Maria Jesus", "Maria de Jesus", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "Maria de Jesus", "Maria", "Maria de Jesus", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br")]
        [InlineData("28541640086", "José da Silva", "José Gonçalves", "José da Silva", "josesilva.28541640086@edu.sme.prefeitura.sp.gov.br")]
        public void Valida_Definicao_Do_Nome_E_Email_Valido_Passando_Os_Resultados_Esperados(string cpf, string nomePessoa, string nomeSocial, string nomeEsperado, string emailEsperado)
        {
            // Arrange
            var funcionarioEol = new FuncionarioIndiretoEol(cpf, nomePessoa, nomeSocial, string.Empty);

            // Assert
            Assert.NotNull(funcionarioEol);
            Assert.Equal(nomeEsperado, funcionarioEol.Nome);
            Assert.Equal(emailEsperado, funcionarioEol.Email);
        }

        [Theory(DisplayName = "Valida a geração de e-mail válido de aluno."), MemberData(nameof(DadosParaValidacaoDeEmailValido))]
        public void Valida_Geracao_Email_Valido_Passando_O_Resultado_Esperado(string cpf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            // Arrange
            var funcionario = new FuncionarioIndiretoEol(cpf, nomePessoa, nomeSocial, organizationPath);

            // Assert
            Assert.Equal(emailEsperado, funcionario.Email);
        }

        [Theory(DisplayName = "Valida a geração de e-mail inválido de aluno."), MemberData(nameof(DadosParaValidacaoDeEmailInvalido))]
        public void Valida_Geracao_Email_Invalido_Passando_O_Resultado_Esperado(string cpf, string nomePessoa, string nomeSocial, string organizationPath, string emailEsperado)
        {
            // Arrange
            var funcionario = new FuncionarioIndiretoEol(cpf, nomePessoa, nomeSocial, organizationPath);

            // Assert
            Assert.NotEqual(emailEsperado, funcionario.Email);
        }

        public static readonly object[][] DadosParaValidacaoDeEmailValido =
        {
            new object[] { 0, "", "", "", null },
            new object[] { 28541640086 , "Maria Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Santos Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza de Santos Jesus", "", "/Professores/Conveniadas", "mariajesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "João da Silva", "", "/Professores/Conveniadas", "joaosilva.28541640086@edu.sme.prefeitura.sp.gov.br" }
        };

        public static readonly object[][] DadosParaValidacaoDeEmailInvalido =
        {
            new object[] { 28541640086, "Maria Jesus", "", "/Professores/Conveniadas", "mariaesus.28541640086@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Jesus", "", "/Professores/Conveniadas", "marjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza Santos Jesus", "", "/Professores/Conveniadas", "marisus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { 28541640086, "Maria Tereza de Santos Jesus", "", "/Professores/Conveniadas", "sjesus.06061992@edu.sme.prefeitura.sp.gov.br" }
        };
    }
}