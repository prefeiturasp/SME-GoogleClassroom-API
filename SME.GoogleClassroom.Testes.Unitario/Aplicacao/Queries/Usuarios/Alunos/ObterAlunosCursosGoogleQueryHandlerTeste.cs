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
    public class ObterAlunosCursosGoogleQueryHandlerTeste
    {
        [Fact(DisplayName = "Deve obter alunos com cursos cadastrados com Dto mapeado corretamente sem email no curso")]
        public async Task Deve_Obter_Alunos_Cursos_Google_Com_Sucesso()
        {
            // Arrange
            var repositorioCursoUsuarioMock = new Mock<IRepositorioCursoUsuario>();
            var paginacao = new Paginacao(1, 10);
            var query = new ObterAlunosCursosGoogleQuery(paginacao, 1234567, 1001, 10);

            var retornoEsperado = new PaginacaoResultadoDto<AlunoCursosCadastradosDto>
            {
                TotalRegistros = 1,
                TotalPaginas = 1,
                Items = new List<AlunoCursosCadastradosDto>
                {
                    new AlunoCursosCadastradosDto
                    {
                        CodigoAluno = 1234567,
                        Nome = "Aluno Teste",
                        Email = "aluno.teste@edu.sme.prefeitura.sp.gov.br",
                        Cursos = new List<CursoCadastradoDto>
                        {
                            new CursoCadastradoDto
                            {
                                CursoId = 9001,
                                Nome = "Matemática",
                                Secao = "Turma A",
                                TurmaId = 1001,
                                ComponenteCurricularId = 10
                            }
                        }
                    }
                }
            };

            repositorioCursoUsuarioMock
                .Setup(r => r.ObterAlunosCursosAsync(query.Paginacao, query.CodigoAluno, query.TurmaId, query.ComponenteCurricularId))
                .ReturnsAsync(retornoEsperado);

            var handler = new ObterAlunosCursosGoogleQueryHandler(repositorioCursoUsuarioMock.Object);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.TotalRegistros);
            Assert.Equal(1, resultado.TotalPaginas);

            var aluno = resultado.Items.First();
            Assert.Equal(1234567, aluno.CodigoAluno);
            Assert.Equal("Aluno Teste", aluno.Nome);
            Assert.Equal("aluno.teste@edu.sme.prefeitura.sp.gov.br", aluno.Email);

            var curso = aluno.Cursos.First();
            Assert.Equal(9001, curso.CursoId);
            Assert.Equal("Matemática", curso.Nome);
            Assert.Equal("Turma A", curso.Secao);
            Assert.Equal(1001, curso.TurmaId);
            Assert.Equal(10, curso.ComponenteCurricularId);
        }

        [Theory(DisplayName = "Deve falhar na validação quando paginação for inválida")]
        [InlineData(0, 10)]
        [InlineData(-1, 10)]
        [InlineData(1, 0)]
        [InlineData(1, -5)]
        public void Deve_Falhar_Validacao_Paginacao_Invalida(int pagina, int quantidadeRegistros)
        {
            // Arrange
            var paginacao = new Paginacao(pagina, quantidadeRegistros);
            var query = new ObterAlunosCursosGoogleQuery(paginacao, null, null, null);
            var validator = new ObterAlunosCursosGoogleQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
        }

        [Fact(DisplayName = "Deve validar com sucesso quando paginação for válida")]
        public void Deve_Validar_Com_Sucesso_Paginacao_Valida()
        {
            // Arrange
            var paginacao = new Paginacao(1, 20);
            var query = new ObterAlunosCursosGoogleQuery(paginacao, 1234567, 1001, 10);
            var validator = new ObterAlunosCursosGoogleQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.True(resultado.IsValid);
        }
    }
}
