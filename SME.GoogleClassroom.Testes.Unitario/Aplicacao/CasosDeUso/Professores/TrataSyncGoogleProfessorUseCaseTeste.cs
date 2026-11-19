using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Professores
{
    public class TrataSyncGoogleProfessorUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly TrataSyncGoogleProfessorUseCase useCase;

        public TrataSyncGoogleProfessorUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new TrataSyncGoogleProfessorUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Executar sem registro prévio de controle deve assumir 1º de janeiro do ano corrente e atualizar controle")]
        public async Task Executar_SemRegistroPrevioExecucaoControle_DeveAssumirPrimeiroDeJaneiroEAtualizarControle()
        {
            // Arrange
            var dataEsperada = new DateTime(DateTime.Today.Year, 1, 1);
            var parametrosCarga = new ParametrosCargaInicialDto();
            var retornoProfessores = new PaginacaoResultadoDto<ProfessorEol> { Items = new List<ProfessorEol>(), TotalRegistros = 0 };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterDataUltimaExecucaoPorTipoQuery>(q => q.ExecucaoTipo == ExecucaoTipo.ProfessorAdicionar), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NegocioException("Não foi possível obter a última data de execução do tipo informado!"));

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterParametrosCargaIncialPorAnoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametrosCarga);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProfessoresParaIncluirGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(retornoProfessores);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<AtualizaExecucaoControleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var mensagemRabbit = new MensagemRabbit(string.Empty);

            // Act
            var resultado = await useCase.Executar(mensagemRabbit);

            // Assert
            Assert.True(resultado);

            mediatorMock.Verify(m => m.Send(
                It.Is<ObterProfessoresParaIncluirGoogleQuery>(q => q.UltimaDataExecucao == dataEsperada),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(m => m.Send(
                It.Is<AtualizaExecucaoControleCommand>(c => c.ExecucaoTipo == ExecucaoTipo.ProfessorAdicionar && c.Data == DateTime.Today),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Executar com registro prévio deve utilizar a data gravada no controle e atualizar controle")]
        public async Task Executar_ComRegistroPrevioExecucaoControle_DeveUtilizarDataGravadaEAtualizarControle()
        {
            // Arrange
            var dataGravada = new DateTime(2026, 3, 20);
            var parametrosCarga = new ParametrosCargaInicialDto();
            var retornoProfessores = new PaginacaoResultadoDto<ProfessorEol> { Items = new List<ProfessorEol>(), TotalRegistros = 0 };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterDataUltimaExecucaoPorTipoQuery>(q => q.ExecucaoTipo == ExecucaoTipo.ProfessorAdicionar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataGravada);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterParametrosCargaIncialPorAnoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametrosCarga);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProfessoresParaIncluirGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(retornoProfessores);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<AtualizaExecucaoControleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var mensagemRabbit = new MensagemRabbit(string.Empty);

            // Act
            var resultado = await useCase.Executar(mensagemRabbit);

            // Assert
            Assert.True(resultado);

            mediatorMock.Verify(m => m.Send(
                It.Is<ObterProfessoresParaIncluirGoogleQuery>(q => q.UltimaDataExecucao == dataGravada),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(m => m.Send(
                It.Is<AtualizaExecucaoControleCommand>(c => c.ExecucaoTipo == ExecucaoTipo.ProfessorAdicionar && c.Data == DateTime.Today),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
