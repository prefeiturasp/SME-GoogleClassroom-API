using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Usuarios.Alunos
{
    public class ObterAlunosCadastradosQueryHandlerTeste
    {
        [Fact(DisplayName = "Deve obter alunos cadastrados com Dto mapeado corretamente")]
        public async Task Deve_Obter_Alunos_Cadastrados_Com_Sucesso()
        {
            // Arrange
            var repositorioUsuarioMock = new Mock<IRepositorioUsuario>();
            var paginacao = new Paginacao(1, 10);
            var query = new ObterAlunosCadastradosQuery(paginacao, 1234567, "aluno@edu.sme.prefeitura.sp.gov.br");

            var alunosEsperados = new PaginacaoResultadoDto<AlunoCadastradoDto>
            {
                TotalRegistros = 1,
                TotalPaginas = 1,
                Items = new List<AlunoCadastradoDto>
                {
                    new AlunoCadastradoDto
                    {
                        Id = 1234567,
                        Indice = 10,
                        Nome = "Aluno Teste da Silva",
                        Email = "aluno@edu.sme.prefeitura.sp.gov.br",
                        OrganizationPath = "/Alunos",
                        DataInclusao = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        GoogleClassroomId = "google-id-12345",
                        ExisteGoogle = true,
                        Cpf = "12345678900"
                    }
                }
            };

            repositorioUsuarioMock
                .Setup(r => r.ObterAlunosAsync(query.Paginacao, query.CodigoEol, query.Email))
                .ReturnsAsync(alunosEsperados);

            var handler = new ObterAlunosCadastradosQueryHandler(repositorioUsuarioMock.Object);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.TotalRegistros);
            var item = resultado.Items.First();
            Assert.Equal(1234567, item.Id);
            Assert.Equal(1234567, item.Codigo);
            Assert.True(item.ExisteGoogle);
            Assert.Equal("google-id-12345", item.GoogleClassroomId);
            Assert.Equal("Aluno", item.PrimeiroNome);
            Assert.Equal("Teste da Silva", item.Sobrenome);
            Assert.Equal((int)UsuarioTipo.Aluno, item.UsuarioTipo);
        }

        [Fact(DisplayName = "Valida sincronização entre Id e Codigo no Dto")]
        public void AlunoCadastradoDto_Deve_Sincronizar_Id_E_Codigo()
        {
            var dtoComId = new AlunoCadastradoDto { Id = 9876543 };
            Assert.Equal(9876543, dtoComId.Id);
            Assert.Equal(9876543, dtoComId.Codigo);

            var dtoComCodigo = new AlunoCadastradoDto { Codigo = 5432100 };
            Assert.Equal(5432100, dtoComCodigo.Id);
            Assert.Equal(5432100, dtoComCodigo.Codigo);
        }

        [Theory(DisplayName = "Testa mapeamento do Dapper para AlunoCadastradoDto com diferentes aliases")]
        [InlineData("googleclassroomid")]
        [InlineData("GoogleClassroomId")]
        [InlineData("google_classroom_id")]
        public void Testa_Mapeamento_Dapper_AlunoCadastradoDto(string alias)
        {
            using var conn = new Microsoft.Data.Sqlite.SqliteConnection("Data Source=:memory:");
            conn.Open();
            var sql = $@"SELECT
                           1 as indice,
                           123456 AS Id,
                           'Nome Aluno' AS Nome,
                           'email@teste.com' AS Email,
                           '/org' as organizationpath,
                           '2021-01-01' as datainclusao,
                           '2021-01-02' as dataatualizacao,
                           'google-id-123' as {alias},
                           1 as existegoogle";
            var aluno = Dapper.SqlMapper.QueryFirstOrDefault<AlunoCadastradoDto>(conn, sql);
            Assert.NotNull(aluno);
            Assert.Equal("google-id-123", aluno.GoogleClassroomId);
            Assert.True(aluno.ExisteGoogle);
        }
    }
}

