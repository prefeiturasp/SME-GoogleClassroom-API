using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Alunos.Cursos
{
    public class ObterAlunosCursosParaCadastrarGoogleUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly IObterAlunosCursosParaCadastrarGoogleUseCase useCase;

        public ObterAlunosCursosParaCadastrarGoogleUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new ObterAlunosCursosParaCadastrarGoogleUseCase(mediatorMock.Object);
        }

        [Theory(DisplayName = "Deve lançar NegocioException quando codigoAluno for inválido")]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task Deve_Lancar_NegocioException_Quando_CodigoAluno_Invalido(long codigoAluno)
        {
            var excecao = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(codigoAluno));
            Assert.Equal("O código do aluno deve ser informado.", excecao.Message);
        }

        [Fact(DisplayName = "Deve retornar AlunoCursosParaCadastrarDto com lista de cursos mapeada corretamente")]
        public async Task Deve_Retornar_AlunoCursosParaCadastrarDto_Com_Sucesso()
        {
            // Arrange
            const long codigoAluno = 1234567;
            var parametrosCargaInicialDto = new ParametrosCargaInicialDto();

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterParametrosCargaIncialPorAnoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametrosCargaInicialDto);

            var cursosEol = new List<AlunoCursoEol>
            {
                new AlunoCursoEol(codigoAluno, 1001, 10) { UeCodigo = "012345" },
                new AlunoCursoEol(codigoAluno, 1002, 20) { UeCodigo = "012345" }
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursosDoAlunoParaIncluirGoogleQuery>(q => q.CodigoAluno == codigoAluno), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursosEol);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursoPorTurmaComponenteCurricularQuery>(q => q.TurmaId == 1001 && q.ComponenteCurricularId == 10), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CursoGoogle("Matemática - 5º Ano", "Turma A", 1001, 10, "prof@edu.sme.prefeitura.sp.gov.br") { Id = 9001 });

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursoPorTurmaComponenteCurricularQuery>(q => q.TurmaId == 1002 && q.ComponenteCurricularId == 20), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CursoGoogle("Português - 5º Ano", "Turma A", 1002, 20, "prof@edu.sme.prefeitura.sp.gov.br") { Id = 9002 });

            // Act
            var resultado = await useCase.Executar(codigoAluno);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(codigoAluno, resultado.CodigoAluno);
            Assert.NotNull(resultado.Cursos);

            var lista = resultado.Cursos.ToList();
            Assert.Equal(2, lista.Count);

            var primeiro = lista[0];
            Assert.Equal(10, primeiro.ComponenteCurricularId);
            Assert.Equal(9001, primeiro.CursoId);
            Assert.Equal(1001, primeiro.TurmaId);
            Assert.Equal("012345", primeiro.UeCodigo);
            Assert.Equal("Matemática - 5º Ano", primeiro.NomeCurso);

            var segundo = lista[1];
            Assert.Equal(20, segundo.ComponenteCurricularId);
            Assert.Equal(9002, segundo.CursoId);
            Assert.Equal(1002, segundo.TurmaId);
            Assert.Equal("012345", segundo.UeCodigo);
            Assert.Equal("Português - 5º Ano", segundo.NomeCurso);
        }

        [Fact(DisplayName = "Deve retornar cursos vazio quando aluno não possuir cursos")]
        public async Task Deve_Retornar_Cursos_Vazio_Quando_Aluno_Nao_Possuir_Cursos()
        {
            // Arrange
            const long codigoAluno = 9999999;
            var parametrosCargaInicialDto = new ParametrosCargaInicialDto();

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterParametrosCargaIncialPorAnoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametrosCargaInicialDto);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursosDoAlunoParaIncluirGoogleQuery>(q => q.CodigoAluno == codigoAluno), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoCursoEol>());

            // Act
            var resultado = await useCase.Executar(codigoAluno);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(codigoAluno, resultado.CodigoAluno);
            Assert.NotNull(resultado.Cursos);
            Assert.Empty(resultado.Cursos);
        }
    }
}
