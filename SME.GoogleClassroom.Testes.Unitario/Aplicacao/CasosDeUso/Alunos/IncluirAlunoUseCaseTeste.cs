using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes
{
    public class IncluirAlunoUseCaseTeste : TesteIntegracaoGoogleClassroom
    {
        private readonly Mock<IMediator> mediator;
        private readonly IIncluirAlunoUseCase incluirAlunoUseCase;

        public IncluirAlunoUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            incluirAlunoUseCase = new IncluirAlunoUseCase(mediator.Object, GerarVariaveisGlobais());
        }

        [Fact(DisplayName = "Valida o envio de JSON vazio para incluir um novo aluno no Google Classroom")]
        private async Task Valida_Mensagem_Vazia_E_Deve_Disparar_Excecao()
        {
            // Arrange
            var mensagem = new MensagemRabbit(null);

            // Assert
            await Assert.ThrowsAsync<NegocioException>(() => incluirAlunoUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento para alunos já inclusos.")]
        private async Task Valida_Tratamento_De_Aluno_Ja_Incluso_Deve_Retornar_True()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            var alunoComEmailFormatado = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            alunoComEmailFormatado.DefinirEmail(1);

            mediator.Setup(a => a.Send(It.IsAny<VerificarEmailExistenteAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(alunoComEmailFormatado);

            mediator.Setup(a => a.Send(It.IsAny<ExisteAlunoPorRfQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var alunoJson = JsonConvert.SerializeObject(aluno);
            var mensagem = new MensagemRabbit(alunoJson);

            // Act
            var retorno = await incluirAlunoUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }
    }
}