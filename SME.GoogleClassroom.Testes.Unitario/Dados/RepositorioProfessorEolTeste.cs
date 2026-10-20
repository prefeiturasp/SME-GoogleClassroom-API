using System;
using System.Reflection;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Dados
{
    public class RepositorioProfessorEolTeste
    {
        private readonly MethodInfo metodoMontaQuery;

        public RepositorioProfessorEolTeste()
        {
            metodoMontaQuery = typeof(RepositorioProfessorEol).GetMethod("MontaQueryProfessorParaInclusao",
                BindingFlags.NonPublic | BindingFlags.Static);
        }

        private string ExecutarMontaQuery(bool aplicarPaginacao, DateTime? dataReferencia, string rf, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            return (string)metodoMontaQuery.Invoke(null, new object[] { aplicarPaginacao, dataReferencia, rf, parametrosCargaInicialDto });
        }

        [Fact(DisplayName = "Consulta de novos professores com paginação não deve conter ponto e vírgula antes de OFFSET")]
        public void MontaQueryProfessorParaInclusao_ComPaginacao_NaoDeveConterPontoEVirgulaAntesDeOffset()
        {
            // Arrange
            var parametrosCargaInicial = new ParametrosCargaInicialDto();

            // Act
            var sql = ExecutarMontaQuery(true, new DateTime(2021, 2, 20), null, parametrosCargaInicial);

            // Assert
            Assert.DoesNotContain("Rf; OFFSET", sql);
            Assert.DoesNotContain("Rf;  OFFSET", sql);
            Assert.DoesNotContain("; OFFSET", sql);
            Assert.Contains("OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY", sql);
        }

        [Fact(DisplayName = "Consulta de novos professores com paginação deve conter ORDER BY e paginação válida")]
        public void MontaQueryProfessorParaInclusao_ComPaginacao_DeveConterClausulaOrderByComOffsetValida()
        {
            // Arrange
            var parametrosCargaInicial = new ParametrosCargaInicialDto();

            // Act
            var sql = ExecutarMontaQuery(true, new DateTime(2021, 2, 20), null, parametrosCargaInicial);

            // Assert
            Assert.Contains("ORDER BY", sql);
            Assert.Contains("Rf", sql);
            Assert.Contains("OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY", sql);
        }

        [Fact(DisplayName = "Consulta de novos professores sem paginação deve encerrar com ponto e vírgula")]
        public void MontaQueryProfessorParaInclusao_SemPaginacao_DeveEncerrarComPontoEVirgula()
        {
            // Arrange
            var parametrosCargaInicial = new ParametrosCargaInicialDto();

            // Act
            var sql = ExecutarMontaQuery(false, new DateTime(2021, 2, 20), null, parametrosCargaInicial);

            // Assert
            Assert.DoesNotContain("OFFSET", sql);
            Assert.Contains("Rf", sql);
            Assert.Contains(";", sql);
        }
    }
}
