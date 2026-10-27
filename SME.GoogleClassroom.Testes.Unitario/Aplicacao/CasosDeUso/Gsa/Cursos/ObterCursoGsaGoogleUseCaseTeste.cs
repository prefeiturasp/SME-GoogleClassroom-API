using Google;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Gsa.Cursos
{
    public class ObterCursoGsaGoogleUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly ObterCursoGsaGoogleUseCase useCase;

        public ObterCursoGsaGoogleUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new ObterCursoGsaGoogleUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "ConsultaCursoGsaDto não deve expor a propriedade de controle UltimoItemDaFila")]
        public void ConsultaCursoGsaDto_NaoDevePossuirPropriedadeUltimoItemDaFila()
        {
            var propriedade = typeof(ConsultaCursoGsaDto).GetProperty("UltimoItemDaFila", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            Assert.Null(propriedade);
        }

        [Fact(DisplayName = "Cenário 1: Executar com curso existente na base e no Google deve retornar ConsultaCursoGsaDto preenchido")]
        public async Task Executar_CursoExistente_DeveRetornarConsultaCursoGsaDto()
        {
            const long turmaId = 2251678;
            const long componenteCurricularId = 512;
            var cursoBase = new CursoGoogle("MINI GRUPO 2 A", "EI - 4A", turmaId, componenteCurricularId, "prof@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 252599106532
            };

            var esperado = new ConsultaCursoGsaDto
            {
                Id = cursoBase.Id,
                Nome = "MINI GRUPO 2 A",
                Secao = "EI - 4A - 2251678 - 400535 - CEU CEI PAZ",
                CriadorId = "113386492810988374897",
                Situacao = "ARCHIVED",
                DataInclusao = new DateTime(2021, 1, 30)
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursoPorTurmaComponenteCurricularQuery>(q => q.TurmaId == turmaId && q.ComponenteCurricularId == componenteCurricularId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoBase);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursoGsaGoogleQuery>(q => q.CursoId == cursoBase.Id.ToString()), It.IsAny<CancellationToken>()))
                .ReturnsAsync(esperado);

            var resultado = await useCase.Executar(turmaId, componenteCurricularId);

            Assert.NotNull(resultado);
            Assert.IsType<ConsultaCursoGsaDto>(resultado);
            Assert.Equal(esperado.Id, resultado.Id);
            Assert.Equal(esperado.Nome, resultado.Nome);
            Assert.Equal(esperado.Situacao, resultado.Situacao);
        }

        [Fact(DisplayName = "Cenário 2: Executar quando curso não existir na base local deve lançar NegocioException (601)")]
        public async Task Executar_CursoInexistenteNaBase_DeveLancarNegocioException()
        {
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((CursoGoogle)null);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(99999999, 99999999));

            Assert.Contains("Não foi encontrado um curso para a Turma 99999999 e Componente Curricular 99999999 na base de dados.", ex.Message);
        }

        [Fact(DisplayName = "Cenário 3: Executar quando curso não existir no Google Classroom (404) deve lançar NegocioException (601)")]
        public async Task Executar_CursoInexistenteNoGoogle_DeveLancarNegocioException()
        {
            var cursoBase = new CursoGoogle("MINI GRUPO 2 A", "EI - 4A", 2251678, 512, "prof@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 252599106532
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoBase);

            var googleEx = new GoogleApiException("classroom", "Not Found")
            {
                HttpStatusCode = HttpStatusCode.NotFound,
                Error = new Google.Apis.Requests.RequestError
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = GoogleApiExceptionMensagens.Erro404EntityNotFound
                }
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoGsaGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(googleEx);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(2251678, 512));

            Assert.Equal("Curso não existe no Google Classroom.", ex.Message);
        }
    }
}
