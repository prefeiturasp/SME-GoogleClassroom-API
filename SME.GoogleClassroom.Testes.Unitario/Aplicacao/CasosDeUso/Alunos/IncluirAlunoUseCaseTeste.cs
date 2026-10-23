using Google;
using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Alunos
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

        private static MensagemRabbit CriarMensagemRabbit(AlunoEol aluno)
        {
            var filtro = new FiltroAlunoDto(aluno, 2021, new List<int>(), new List<long>(), new List<long>());
            return new MensagemRabbit(JsonConvert.SerializeObject(filtro));
        }

        [Fact(DisplayName = "Valida o envio de JSON vazio para incluir um novo aluno no Google Classroom.")]
        public async Task Valida_Mensagem_Vazia_E_Deve_Disparar_NegocioException()
        {
            // Arrange
            var mensagem = new MensagemRabbit(null);

            // Assert
            await Assert.ThrowsAsync<NegocioException>(() => incluirAlunoUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento para alunos já inclusos.")]
        public async Task Valida_Tratamento_De_Aluno_Ja_Incluso_Deve_Retornar_True()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            var alunoComEmailTratado = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            alunoComEmailTratado.DefinirEmail(1);

            var alunoJaCadastrado = new AlunoGoogle(1, "José da Silva", "jose.silva@sme.prefeitura.sp.gov.br", "/Alunos")
            {
                Indice = 10,
                GoogleClassroomId = "google-id-existente"
            };

            mediator.Setup(a => a.Send(It.IsAny<VerificarEmailExistenteAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(alunoComEmailTratado);

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle> { alunoJaCadastrado });

            mediator.Setup(a => a.Send(It.IsAny<AtualizarAlunoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<AtualizarUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<AtualizarUsuarioGoogleClassroomIdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var mensagem = CriarMensagemRabbit(aluno);

            // Act
            var retorno = await incluirAlunoUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de duplicidade no Google Classroom.")]
        public async Task Valida_Tratamento_De_Duplicidade_No_Google_Deve_Retornar_True()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            var alunoComEmailTratado = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle>());

            mediator.Setup(a => a.Send(It.IsAny<VerificarEmailExistenteAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(alunoComEmailTratado);

            var googleDuplicidadeException = new GoogleApiException(string.Empty, GoogleApiExceptionMensagens.Erro409EntityAlreadyExists);
            googleDuplicidadeException.HttpStatusCode = HttpStatusCode.Conflict;
            googleDuplicidadeException.Error = new Google.Apis.Requests.RequestError
            {
                Code = (int)HttpStatusCode.Conflict,
                Message = GoogleApiExceptionMensagens.Erro409EntityAlreadyExists
            };

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleDuplicidadeException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            mediator.Setup(a => a.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var mensagem = CriarMensagemRabbit(aluno);

            // Act
            var retorno = await incluirAlunoUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral do Google Classroom.")]
        public async Task Valida_Tratamento_De_Excecoes_Do_Google_Deve_Devolver_A_GoogleApiExption_Disparada()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            var alunoComEmailTratado = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle>());

            mediator.Setup(a => a.Send(It.IsAny<VerificarEmailExistenteAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(alunoComEmailTratado);

            var googleDuplicidadeException = new GoogleApiException(string.Empty, "Erro no Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleDuplicidadeException);

            var mensagem = CriarMensagemRabbit(aluno);

            // Assert
            await Assert.ThrowsAsync<GoogleApiException>(() => incluirAlunoUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral ao se comunicar com o Google Classroom.")]
        public async Task Valida_Tratamento_De_Excecoes_Ao_Comunicar_Com_Google_Deve_Devolver_A_Excecao_Disparada()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            var alunoComEmailTratado = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle>());

            mediator.Setup(a => a.Send(It.IsAny<VerificarEmailExistenteAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(alunoComEmailTratado);

            var excecao = new NullReferenceException("Erro ao se comunicar Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(excecao);

            var mensagem = CriarMensagemRabbit(aluno);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => incluirAlunoUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida a inclusão de um aluno válido.")]
        public async Task Valida_Inclusao_De_Aluno_Valido_Deve_Retornar_True()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));
            var alunoComEmailTratado = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle>());

            mediator.Setup(a => a.Send(It.IsAny<VerificarEmailExistenteAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(alunoComEmailTratado);

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            mediator.Setup(a => a.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var mensagem = CriarMensagemRabbit(aluno);

            // Act
            var retorno = await incluirAlunoUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }
    }
}
