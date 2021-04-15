using Google;
using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Professores
{
    public class InserirProfessorGoogleUseCaseTeste : TesteIntegracaoGoogleClassroom
    {
        private readonly Mock<IMediator> mediator;
        private readonly IInserirProfessorGoogleUseCase inserirProfessorGoogleUseCase;

        public InserirProfessorGoogleUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            inserirProfessorGoogleUseCase = new InserirProfessorGoogleUseCase(mediator.Object, GerarVariaveisGlobais());
        }

        [Fact(DisplayName = "Valida o envio de JSON vazio para incluir um novo professor no Google Classroom.")]
        private async Task Valida_Mensagem_Vazia_E_Deve_Disparar_NegocioException()
        {
            // Arrange
            var mensagem = new MensagemRabbit(null);

            // Assert
            await Assert.ThrowsAsync<NegocioException>(() => inserirProfessorGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento para professores já inclusos.")]
        private async Task Valida_Tratamento_De_Professor_Ja_Incluso_Deve_Retornar_True()
        {
            // Arrange
            var professor = new ProfessorEol(123456, "José da Silva", string.Empty, string.Empty);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorPorRfQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var professorJson = JsonConvert.SerializeObject(professor);
            var mensagem = new MensagemRabbit(professorJson);

            // Act
            var retorno = await inserirProfessorGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de duplicidade no Google Classroom.")]
        private async Task Valida_Tratamento_De_Duplicidade_No_Google_Deve_Retornar_True()
        {
            // Arrange
            var professor = new ProfessorEol(123456, "José da Silva", string.Empty, string.Empty);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorPorRfQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleDuplicidadeException = new GoogleApiException(string.Empty, GoogleApiExceptionMensagens.Erro409EntityAlreadyExists);
            googleDuplicidadeException.HttpStatusCode = HttpStatusCode.Conflict;
            googleDuplicidadeException.Error = new Google.Apis.Requests.RequestError
            {
                Code = (int)HttpStatusCode.Conflict,
                Message = GoogleApiExceptionMensagens.Erro409EntityAlreadyExists
            };

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleDuplicidadeException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            mediator.Setup(a => a.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var professorJson = JsonConvert.SerializeObject(professor);
            var mensagem = new MensagemRabbit(professorJson);

            // Act
            var retorno = await inserirProfessorGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral do Google Classroom.")]
        private async Task Valida_Tratamento_De_Duplicidade_No_Google_Deve_Devolver_A_GoogleApiExption_Disparada()
        {
            // Arrange
            var professor = new ProfessorEol(123456, "José da Silva", string.Empty, string.Empty);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorPorRfQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleException = new GoogleApiException(string.Empty, "Erro no Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleException);

            var professorJson = JsonConvert.SerializeObject(professor);
            var mensagem = new MensagemRabbit(professorJson);

            // Assert
            await Assert.ThrowsAsync<GoogleApiException>(() => inserirProfessorGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral ao se comunicar com o Google Classroom.")]
        private async Task Valida_Tratamento_De_Excecoes_Ao_Comunicar_Com_Google_Deve_Devolver_A_Excecao_Disparada()
        {
            // Arrange
            var professor = new ProfessorEol(123456, "José da Silva", string.Empty, string.Empty);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorPorRfQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var excecao = new NullReferenceException("Erro ao se comunicar Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(excecao);

            var professorJson = JsonConvert.SerializeObject(professor);
            var mensagem = new MensagemRabbit(professorJson);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => inserirProfessorGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida a inclusão de um professor válido.")]
        private async Task Valida_Inclusao_De_Professor_Valido_Deve_Retornar_True()
        {
            // Arrange
            var professor = new ProfessorEol(123456, "José da Silva", string.Empty, string.Empty);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorPorRfQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            mediator.Setup(a => a.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var professorJson = JsonConvert.SerializeObject(professor);
            var mensagem = new MensagemRabbit(professorJson);

            // Act
            var retorno = await inserirProfessorGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }
    }
}