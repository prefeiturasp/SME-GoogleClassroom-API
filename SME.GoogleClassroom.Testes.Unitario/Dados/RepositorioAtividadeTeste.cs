using System.Reflection;
using Microsoft.Extensions.Configuration;
using Moq;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Dados
{
    public class RepositorioAtividadeTeste
    {
        private readonly RepositorioAtividade repositorioAtividade;
        private readonly MethodInfo metodoMontaQuery;

        public RepositorioAtividadeTeste()
        {
            var configuration = new Mock<IConfiguration>();
            var connectionStrings = new ConnectionStrings(configuration.Object);
            repositorioAtividade = new RepositorioAtividade(connectionStrings);
            metodoMontaQuery = typeof(RepositorioAtividade).GetMethod("MontaQueryObterAtividadesPorData",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private string ExecutarMontaQuery(bool ehParaPaginacao, Paginacao paginacao, long? cursoId)
        {
            return (string)metodoMontaQuery.Invoke(repositorioAtividade, new object[] { ehParaPaginacao, paginacao, cursoId });
        }

        [Fact(DisplayName = "Consulta de atividades com cursoId deve filtrar por A.curso_gsa_id e não por A.ID")]
        public void MontaQueryObterAtividadesPorData_ComCursoId_DeveFiltrarPorCursoGsaId()
        {
            // Arrange
            var paginacao = new Paginacao(1, 20);
            long? cursoId = 12345;

            // Act
            var sql = ExecutarMontaQuery(false, paginacao, cursoId);

            // Assert
            Assert.Contains("A.curso_gsa_id = @cursoId", sql);
            Assert.DoesNotContain("A.ID = @cursoId", sql);
        }

        [Fact(DisplayName = "Consulta de atividades sem paginação deve finalizar com ponto e vírgula")]
        public void MontaQueryObterAtividadesPorData_SemPaginacao_DeveFinalizarComPontoEVirgula()
        {
            // Arrange
            var paginacao = new Paginacao(0, 0);

            // Act
            var sql = ExecutarMontaQuery(false, paginacao, null);

            // Assert
            Assert.EndsWith(";\r\n", sql);
        }

        [Fact(DisplayName = "Consulta de contagem de atividades deve finalizar com ponto e vírgula")]
        public void MontaQueryObterAtividadesPorData_ParaPaginacao_DeveFinalizarComPontoEVirgula()
        {
            // Arrange
            var paginacao = new Paginacao(1, 20);

            // Act
            var sql = ExecutarMontaQuery(true, paginacao, null);

            // Assert
            Assert.EndsWith(";\r\n", sql);
        }

        [Fact(DisplayName = "Consulta de atividades deve preservar o filtro de dataReferencia")]
        public void MontaQueryObterAtividadesPorData_DevePreservarFiltroDataReferencia()
        {
            // Arrange
            var paginacao = new Paginacao(1, 20);

            // Act
            var sql = ExecutarMontaQuery(false, paginacao, null);

            // Assert
            Assert.Contains("A.DATA_INCLUSAO = @dataReferencia", sql);
        }
    }
}
