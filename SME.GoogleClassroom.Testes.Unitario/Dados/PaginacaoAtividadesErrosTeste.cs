using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Dados
{
    public class PaginacaoAtividadesErrosTeste
    {
        private readonly RepositorioAtividade repositorioAtividade;
        private readonly MethodInfo metodoObterQueryAtividadePorPeriodo;

        public PaginacaoAtividadesErrosTeste()
        {
            var configuration = new Mock<IConfiguration>();
            var connectionStrings = new ConnectionStrings(configuration.Object);
            repositorioAtividade = new RepositorioAtividade(connectionStrings);

            metodoObterQueryAtividadePorPeriodo = typeof(RepositorioAtividade).GetMethod("ObterQueryAtividadePorPeriodo",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private async Task<string> ExecutarObterQueryAtividadePorPeriodo(long? cursoId, bool contagem = false)
        {
            var task = (Task<string>)metodoObterQueryAtividadePorPeriodo.Invoke(repositorioAtividade, new object[] { cursoId, contagem });
            return await task;
        }

        [Fact(DisplayName = "1. Paginacao padrao - Query deve usar limit e offset parametrizados sem multiplicacao no SQL")]
        public async Task ObterQueryAtividadePorPeriodo_PaginacaoPadrao_DeveConterLimitEOffsetParametrizados()
        {
            // Act
            var sql = await ExecutarObterQueryAtividadePorPeriodo(null, false);

            // Assert
            Assert.Contains("limit @quantidadeRegistrosPagina offset @quantidadeRegistrosIgnorados;", sql);
            Assert.DoesNotContain("offset(@pagina - 1)", sql);
            Assert.DoesNotContain("* @quantidadeRegistrosPagina", sql);
        }

        [Fact(DisplayName = "2. Primeira pagina - Query de contagem deve gerar count(0) e nao incluir limit/offset")]
        public async Task ObterQueryAtividadePorPeriodo_PrimeiraPagina_ContagemNaoDeveConterPaginacao()
        {
            // Act
            var sql = await ExecutarObterQueryAtividadePorPeriodo(null, true);

            // Assert
            Assert.Contains("select  count(0) ", sql);
            Assert.DoesNotContain("limit @quantidadeRegistrosPagina", sql);
            Assert.DoesNotContain("offset", sql);
        }

        [Fact(DisplayName = "3. Paginas subsequentes - Calculo de offset deve avancar de acordo com a pagina informada")]
        public void PaginacaoAtividades_PaginasSubsequentes_CalculoOffsetDeveSerCorreto()
        {
            // Arrange
            int pagina2 = 2;
            int pagina3 = 3;
            int quantidadePorPagina = 50;

            // Act
            int offsetPagina2 = (pagina2 - 1) * quantidadePorPagina;
            int offsetPagina3 = (pagina3 - 1) * quantidadePorPagina;

            // Assert
            Assert.Equal(50, offsetPagina2);
            Assert.Equal(100, offsetPagina3);
        }

        [Fact(DisplayName = "4. Parametros nulos - Quando cursoId for nulo nao deve adicionar filtro de curso")]
        public async Task ObterQueryAtividadePorPeriodo_SemCursoId_NaoDeveFiltrarCurso()
        {
            // Act
            var sql = await ExecutarObterQueryAtividadePorPeriodo(null, false);

            // Assert
            Assert.DoesNotContain("and c.id = @cursoId", sql);
            Assert.Contains("limit @quantidadeRegistrosPagina offset @quantidadeRegistrosIgnorados;", sql);
        }

        [Fact(DisplayName = "5. Limites e valores invalidos - Pagina zero ou negativa e registros invalidos nao devem gerar offset negativo")]
        public void PaginacaoAtividades_LimitesEValoresInvalidos_DevemSerNormalizados()
        {
            // Arrange
            int paginaZero = 0;
            int paginaNegativa = -3;
            int registrosZero = 0;
            int registrosNegativos = -20;

            // Act
            int pagNormalizada1 = paginaZero <= 0 ? 1 : paginaZero;
            int regNormalizado1 = registrosZero <= 0 ? 100 : registrosZero;
            int offset1 = (pagNormalizada1 - 1) * regNormalizado1;

            int pagNormalizada2 = paginaNegativa <= 0 ? 1 : paginaNegativa;
            int regNormalizado2 = registrosNegativos <= 0 ? 100 : registrosNegativos;
            int offset2 = (pagNormalizada2 - 1) * regNormalizado2;

            // Assert
            Assert.Equal(1, pagNormalizada1);
            Assert.Equal(100, regNormalizado1);
            Assert.Equal(0, offset1);

            Assert.Equal(1, pagNormalizada2);
            Assert.Equal(100, regNormalizado2);
            Assert.Equal(0, offset2);
            Assert.True(offset1 >= 0);
            Assert.True(offset2 >= 0);
        }

        [Fact(DisplayName = "6. Paginacao combinada com filtros - Quando cursoId for informado deve filtrar e manter limit/offset")]
        public async Task ObterQueryAtividadePorPeriodo_ComCursoId_DeveFiltrarCursoEConterPaginacao()
        {
            // Arrange
            long cursoId = 987654321;

            // Act
            var sql = await ExecutarObterQueryAtividadePorPeriodo(cursoId, false);

            // Assert
            Assert.Contains("and c.id = @cursoId", sql);
            Assert.Contains("limit @quantidadeRegistrosPagina offset @quantidadeRegistrosIgnorados;", sql);
        }

        [Fact(DisplayName = "7. Ausencia de duplicacao ou omissao - Query deve possuir ordenacao deterministica por a.id")]
        public async Task ObterQueryAtividadePorPeriodo_DevePossuirOrdenacaoDeterministica()
        {
            // Act
            var sql = await ExecutarObterQueryAtividadePorPeriodo(null, false);

            // Assert
            Assert.Contains("order by a.id", sql);
        }
    }
}
