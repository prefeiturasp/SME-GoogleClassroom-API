using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Usuarios.Alunos
{
    public class ObterAlunosQueSeraoInativadosPorAnoLetivoQueryHandlerTeste
    {
        [Fact(DisplayName = "Deve obter alunos que serão inativados com sucesso e DTO mapeado")]
        public async Task Deve_Obter_Alunos_Que_Serao_Inativados_Com_Sucesso()
        {
            // Arrange
            var repositorioAlunoEolMock = new Mock<IRepositorioAlunoEol>();
            var paginacao = new Paginacao(1, 10);
            var anoLetivo = 2026;
            var dataReferencia = new DateTime(2026, 1, 1);
            var query = new ObterAlunosQueSeraoInativadosPorAnoLetivoQuery(paginacao, anoLetivo, dataReferencia);

            var retornoEsperado = new PaginacaoResultadoDto<AlunoInativoDto>
            {
                TotalRegistros = 1,
                TotalPaginas = 1,
                Items = new List<AlunoInativoDto>
                {
                    new AlunoInativoDto
                    {
                        Codigo = 1234567,
                        Nome = "Nome Social do Aluno",
                        NomeSocial = "Nome Social do Aluno",
                        DataNascimento = new DateTime(2005, 5, 20),
                        TurmaId = 98765,
                        SituacaoMatricula = 2,
                        DataSituacao = new DateTime(2026, 2, 10)
                    }
                }
            };

            repositorioAlunoEolMock
                .Setup(r => r.ObterAlunosQueSeraoInativosPorAnoLetivo(query.Paginacao, query.AnoLetivo, query.DataReferencia))
                .ReturnsAsync(retornoEsperado);

            var handler = new ObterAlunosQueSeraoInativadosPorAnoLetivoQueryHandler(repositorioAlunoEolMock.Object);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.TotalRegistros);
            var item = resultado.Items.First();
            Assert.Equal(1234567, item.Codigo);
            Assert.Equal("Nome Social do Aluno", item.Nome);
            Assert.Equal("Nome Social do Aluno", item.NomeSocial);
            Assert.Equal(98765, item.TurmaId);
            Assert.Equal(2, item.SituacaoMatricula);
        }

        [Theory(DisplayName = "Deve falhar na validação quando ano letivo for inválido")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_Falhar_Validacao_AnoLetivo_Invalido(int anoLetivo)
        {
            // Arrange
            var paginacao = new Paginacao(1, 10);
            var query = new ObterAlunosQueSeraoInativadosPorAnoLetivoQuery(paginacao, anoLetivo, DateTime.Now);
            var validator = new ObterAlunosQueSeraoInativadosPorAnoLetivoQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.PropertyName == nameof(query.AnoLetivo));
        }

        [Fact(DisplayName = "Deve falhar na validação quando data de referência for padrão/vazia")]
        public void Deve_Falhar_Validacao_DataReferencia_Vazia()
        {
            // Arrange
            var paginacao = new Paginacao(1, 10);
            var query = new ObterAlunosQueSeraoInativadosPorAnoLetivoQuery(paginacao, 2026, default);
            var validator = new ObterAlunosQueSeraoInativadosPorAnoLetivoQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.PropertyName == nameof(query.DataReferencia));
        }

        [Theory(DisplayName = "Deve falhar na validação quando registros quantidade for inválido")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_Falhar_Validacao_RegistrosQuantidade_Invalido(int registrosQuantidade)
        {
            // Arrange
            var paginacao = new Paginacao(1, registrosQuantidade);
            var query = new ObterAlunosQueSeraoInativadosPorAnoLetivoQuery(paginacao, 2026, DateTime.Now);
            var validator = new ObterAlunosQueSeraoInativadosPorAnoLetivoQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.PropertyName == "Paginacao.QuantidadeRegistros");
        }

        [Fact(DisplayName = "Deve validar com sucesso quando parâmetros forem válidos")]
        public void Deve_Validar_Com_Sucesso_Parametros_Validos()
        {
            // Arrange
            var paginacao = new Paginacao(1, 10);
            var query = new ObterAlunosQueSeraoInativadosPorAnoLetivoQuery(paginacao, 2026, new DateTime(2026, 1, 1));
            var validator = new ObterAlunosQueSeraoInativadosPorAnoLetivoQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.True(resultado.IsValid);
        }
    }
}
