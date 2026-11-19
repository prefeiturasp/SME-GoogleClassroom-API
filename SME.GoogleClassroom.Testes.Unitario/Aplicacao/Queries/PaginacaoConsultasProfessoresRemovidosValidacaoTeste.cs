using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries
{
    public class PaginacaoConsultasProfessoresRemovidosValidacaoTeste
    {
        [Theory(DisplayName = "ObterProfessoresRemovidosCursosPorIdQueryValidator deve invalidar quando registrosQuantidade ou pagina for menor ou igual a zero")]
        [InlineData(0, 1)]
        [InlineData(-1, 1)]
        [InlineData(10, 0)]
        [InlineData(10, -1)]
        public void ObterProfessoresRemovidosCursosPorIdQueryValidator_DeveInvalidarPaginacaoInvalida(int registrosQuantidade, int paginaNumero)
        {
            // Arrange
            var validator = new ObterProfessoresRemovidosCursosPorIdQuery.ObterProfessoresRemovidosCursosPorIdQueryValidator();
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);
            var query = new ObterProfessoresRemovidosCursosPorIdQuery(paginacao, 0);

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.ErrorMessage == "O número da página e a quantidade de registro devem ser informados.");
        }

        [Fact(DisplayName = "ObterProfessoresRemovidosCursosPorIdQueryValidator deve validar quando paginacao for valida")]
        public void ObterProfessoresRemovidosCursosPorIdQueryValidator_DeveValidarPaginacaoValida()
        {
            // Arrange
            var validator = new ObterProfessoresRemovidosCursosPorIdQuery.ObterProfessoresRemovidosCursosPorIdQueryValidator();
            var paginacao = new Paginacao(1, 20);
            var query = new ObterProfessoresRemovidosCursosPorIdQuery(paginacao, 0);

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.True(resultado.IsValid);
        }

        [Fact(DisplayName = "QueryUsuariosRemovidos deve conter ORDER BY e joins no count")]
        public void QueryUsuariosRemovidos_DeveConterOrderByEJoinsNoCount()
        {
            // Arrange
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "ConnectionStrings:GoogleClassroomConnection", "Host=localhost;Database=test;Username=postgres;Password=test" }
                })
                .Build();
            var connectionStrings = new ConnectionStrings(config);
            var repositorio = new RepositorioCursoUsuarioRemovidoGsa(connectionStrings);

            var metodo = typeof(RepositorioCursoUsuarioRemovidoGsa).GetMethod("QueryUsuariosRemovidos",
                BindingFlags.NonPublic | BindingFlags.Instance);

            var paginacao = new Paginacao(1, 20);

            // Act
            var sql = (string)metodo.Invoke(repositorio, new object[] { paginacao, 0L });

            // Assert
            Assert.Contains("ORDER BY ucr.removido_em DESC, ucr.id", sql);
            Assert.Contains("OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY", sql);
            Assert.Contains("SELECT count(*)", sql);
            Assert.Contains("inner join cursos c on c.id = ucr.curso_id", sql);
            Assert.Contains("inner join usuarios u on u.indice = ucr.usuario_id", sql);
        }
    }
}
