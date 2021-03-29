using SME.GoogleClassroom.Dominio;
using System;
using Xunit;

namespace SME.GoogleClassroom.Testes
{
    public class AlunoEolTeste
    {
        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(CorrectData))]
        public void GeracaoDeEmail(string nome, DateTime dataNascimento, string emailEsperado)
        {
            AlunoEol aluno = new AlunoEol(1, nome, string.Empty, string.Empty, dataNascimento);

            Assert.Equal(emailEsperado, aluno.Email);
        }

        [Theory(DisplayName = "Geração de Email"), MemberData(nameof(WrongData))]
        public void GeracaoDeEmailErrado(string nome, DateTime dataNascimento, string emailEsperado)
        {
            AlunoEol aluno = new AlunoEol(1, nome, string.Empty, string.Empty, dataNascimento);

            Assert.NotEqual(emailEsperado, aluno.Email);
        }

        public static readonly object[][] CorrectData =
        {
            new object[] { "", null, null },
            new object[] { "Maria Jesus", new DateTime(1992, 06, 06), "mariajesus.06061992@edu.sme.prefeitura.sp.gov.br" },
            new object[] { "Maria Tereza Jesus", new DateTime(2017, 2, 1), "mariatjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { "Maria Tereza Santos Jesus", new DateTime(2017,3,1), "mariatsjesus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { "Maria Tereza de Santos Jesus", new DateTime(1992, 06, 06),"mariatsjesus.06061992@edu.sme.prefeitura.sp.gov.br" },
            new object[] { "José da Silva", new DateTime(1992, 06, 06) , "josesilva.06061992@edu.sme.prefeitura.sp.gov.br" }
        };

        public static readonly object[][] WrongData =
        {
            new object[] { "Maria Jesus", new DateTime(1992, 06, 06), "mariaesus.06061992@edu.sme.prefeitura.sp.gov.br" },
            new object[] { "Maria Tereza Jesus", new DateTime(2017, 2, 1), "marjesus.01022017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { "Maria Tereza Santos Jesus", new DateTime(2017,3,1), "marisus.01032017@edu.sme.prefeitura.sp.gov.br" },
            new object[] { "Maria Tereza de Santos Jesus", new DateTime(1992, 06, 06),"sjesus.06061992@edu.sme.prefeitura.sp.gov.br" }
        };
    }
}
