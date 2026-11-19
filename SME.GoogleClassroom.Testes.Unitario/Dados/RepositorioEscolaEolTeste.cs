using System.Reflection;
using Microsoft.Extensions.Configuration;
using Moq;
using SME.GoogleClassroom.Dados.Escola;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Dados
{
    public class RepositorioEscolaEolTeste
    {
        private readonly RepositorioEscolaEol repositorioEscola;
        private readonly MethodInfo metodoMontaQuery;

        public RepositorioEscolaEolTeste()
        {
            var configuration = new Mock<IConfiguration>();
            var connectionStrings = new ConnectionStrings(configuration.Object);
            repositorioEscola = new RepositorioEscolaEol(connectionStrings);
            metodoMontaQuery = typeof(RepositorioEscolaEol).GetMethod("MontaQueryObterEscolas",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private string ExecutarMontaQuery(int[] tiposEscola, string codigoDre, string siglaTipoEscola)
        {
            return (string)metodoMontaQuery.Invoke(repositorioEscola, new object[] { tiposEscola, codigoDre, siglaTipoEscola });
        }

        [Fact(DisplayName = "Consulta de escolas deve filtrar por unidades ativas (tp_situacao_unidade = 1)")]
        public void MontaQueryObterEscolas_DeveConterFiltroSituacaoUnidadeAtiva()
        {
            // Arrange
            var tiposEscola = new[] { 1, 2, 3 };

            // Act
            var sql = ExecutarMontaQuery(tiposEscola, null, null);

            // Assert
            Assert.Contains("vcue.tp_situacao_unidade = 1", sql);
            Assert.DoesNotContain("tp_situacao_unidade = 2", sql);
        }

        [Fact(DisplayName = "Consulta de escolas não deve projetar colunas NomeDRE e SiglaDRE")]
        public void MontaQueryObterEscolas_NaoDeveProjetarNomeDREESiglaDRE()
        {
            // Arrange
            var tiposEscola = new[] { 1 };

            // Act
            var sql = ExecutarMontaQuery(tiposEscola, null, null);

            // Assert
            Assert.DoesNotContain("NomeDRE", sql);
            Assert.DoesNotContain("SiglaDRE", sql);
        }

        [Fact(DisplayName = "Consulta de escolas deve projetar apenas os campos correspondentes ao EscolaDTO")]
        public void MontaQueryObterEscolas_DeveConterCamposEscolaDTO()
        {
            // Arrange
            var tiposEscola = new[] { 1, 2 };

            // Act
            var sql = ExecutarMontaQuery(tiposEscola, null, null);

            // Assert
            Assert.Contains("esc.cd_escola Codigo", sql);
            Assert.Contains("RTRIM(LTRIM(vcue.nm_unidade_educacao)) Nome", sql);
            Assert.Contains("dre.cd_unidade_educacao CodigoDRE", sql);
            Assert.Contains("RTRIM(LTRIM(te.sg_tp_escola)) SiglaTipoEscola", sql);
        }

        [Fact(DisplayName = "Consulta de escolas com DRE e SiglaTipoEscola deve aplicar filtros combinados")]
        public void MontaQueryObterEscolas_ComFiltrosCombinados_DeveAplicarClausulas()
        {
            // Arrange
            var tiposEscola = new[] { 1, 3 };
            var codigoDre = "108100";
            var siglaTipoEscola = "EMEF";

            // Act
            var sql = ExecutarMontaQuery(tiposEscola, codigoDre, siglaTipoEscola);

            // Assert
            Assert.Contains("AND dre.cd_unidade_educacao = @codigoDre", sql);
            Assert.Contains("AND RTRIM(LTRIM(te.sg_tp_escola)) = @siglaTipoEscola", sql);
            Assert.Contains("vcue.tp_situacao_unidade = 1", sql);
        }

        [Fact(DisplayName = "Consulta de escolas sem filtros opcionais não deve incluir cláusulas adicionais")]
        public void MontaQueryObterEscolas_SemFiltrosOpcionais_NaoDeveIncluirClausulasExtras()
        {
            // Arrange
            var tiposEscola = new[] { 1 };

            // Act
            var sql = ExecutarMontaQuery(tiposEscola, string.Empty, null);

            // Assert
            Assert.DoesNotContain("@codigoDre", sql);
            Assert.DoesNotContain("@siglaTipoEscola", sql);
            Assert.Contains("vcue.tp_situacao_unidade = 1", sql);
        }

        [Fact(DisplayName = "Consulta de escolas deve interpolar corretamente a lista de tipos de escola")]
        public void MontaQueryObterEscolas_DeveInterpolarTiposEscolaCorretamente()
        {
            // Arrange
            var tiposEscola = new[] { 1, 3, 10, 16 };

            // Act
            var sql = ExecutarMontaQuery(tiposEscola, null, null);

            // Assert
            Assert.Contains("esc.tp_escola in(1,3,10,16)", sql);
        }
    }
}
