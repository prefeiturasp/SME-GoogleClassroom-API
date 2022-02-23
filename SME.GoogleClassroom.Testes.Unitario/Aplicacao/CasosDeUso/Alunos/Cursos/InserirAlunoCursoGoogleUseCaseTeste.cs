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

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Alunos.Cursos
{
    public class InserirAlunoCursoGoogleUseCaseTeste : TesteIntegracaoGoogleClassroom
    {
        private readonly Mock<IMediator> mediator;
        private readonly IInserirAlunoCursoGoogleUseCase inserirAlunoCursoGoogleUseCase;

        public InserirAlunoCursoGoogleUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            inserirAlunoCursoGoogleUseCase = new InserirAlunoCursoGoogleUseCase(mediator.Object, GerarVariaveisGlobais());
        }

        [Fact(DisplayName = "Valida o envio de JSON vazio para incluir o aluno no curso no Google Classroom.")]
        private async Task Valida_Mensagem_Vazia_E_Deve_Disparar_NegocioException()
        {
            // Arrange
            var mensagem = new MensagemRabbit(null);

            // Assert
            await Assert.ThrowsAsync<NegocioException>(() => inserirAlunoCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento para alunos que ainda não foram inclusos.")]
        private async Task Valida_Tratamento_De_Aluno_Nao_Incluso_Deve_Retornar_False()
        {
            // Arrange
            var alunoCurso = new AlunoCursoEol(1234567, 1010, 6);

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle>());

            var alunoCursoJson = JsonConvert.SerializeObject(alunoCurso);
            var mensagem = new MensagemRabbit(alunoCursoJson);

            // Act
            var retorno = await inserirAlunoCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.False(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento para cursos que ainda não foram inclusos.")]
        private async Task Valida_Tratamento_De_Curso_Nao_Incluso_Deve_Retornar_False()
        {
            // Arrange
            var alunoCurso = new AlunoCursoEol(1234567, 1010, 6);
            var alunoGoogle = new AlunoGoogle(1234567, "José da Silva", "josesilva.06061990@edu.sme.prefeitura.sp.gov.br", string.Empty);
            CursoGoogle cursoGoogle = null;

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle> { alunoGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            var alunoCursoJson = JsonConvert.SerializeObject(alunoCurso);
            var mensagem = new MensagemRabbit(alunoCursoJson);

            // Act
            var retorno = await inserirAlunoCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.False(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento para alunos já inclusos no curso.")]
        private async Task Valida_Tratamento_De_Aluno_Ja_Incluso_No_Curso_Deve_Retornar_True()
        {
            // Arrange
            var alunoCurso = new AlunoCursoEol(1234567, 1010, 6);
            var alunoGoogle = new AlunoGoogle(1234567, "José da Silva", "josesilva.06061990@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle> { alunoGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteAlunoCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var alunoCursoJson = JsonConvert.SerializeObject(alunoCurso);
            var mensagem = new MensagemRabbit(alunoCursoJson);

            // Act
            var retorno = await inserirAlunoCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de duplicidade no Google Classroom.")]
        private async Task Valida_Tratamento_De_Duplicidade_No_Google_Deve_Retornar_True()
        {
            // Arrange
            var alunoCurso = new AlunoCursoEol(1234567, 1010, 6);
            var alunoGoogle = new AlunoGoogle(1234567, "José da Silva", "josesilva.06061990@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle> { alunoGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteAlunoCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleDuplicidadeException = GerarExcecaoDeDuplicidadeDoGoogle();

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleDuplicidadeException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var alunoCursoJson = JsonConvert.SerializeObject(alunoCurso);
            var mensagem = new MensagemRabbit(alunoCursoJson);

            // Act
            var retorno = await inserirAlunoCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral do Google Classroom.")]
        private async Task Valida_Tratamento_De_Excecoes_Do_Google_Deve_Devolver_A_GoogleApiExption_Disparada()
        {
            // Arrange
            var alunoCurso = new AlunoCursoEol(1234567, 1010, 6);
            var alunoGoogle = new AlunoGoogle(1234567, "José da Silva", "josesilva.06061990@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle> { alunoGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteAlunoCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleException = new GoogleApiException(string.Empty, "Erro no Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var alunoCursoJson = JsonConvert.SerializeObject(alunoCurso);
            var mensagem = new MensagemRabbit(alunoCursoJson);

            // Assert
            await Assert.ThrowsAsync<GoogleApiException>(() => inserirAlunoCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral ao se comunicar com o Google Classroom.")]
        private async Task Valida_Tratamento_De_Excecoes_Ao_Comunicar_Com_Google_Deve_Devolver_A_Excecao_Disparada()
        {
            // Arrange
            var alunoCurso = new AlunoCursoEol(1234567, 1010, 6);
            var alunoGoogle = new AlunoGoogle(1234567, "José da Silva", "josesilva.06061990@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle> { alunoGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteAlunoCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var excecao = new NullReferenceException("Erro ao se comunicar Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(excecao);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var alunoCursoJson = JsonConvert.SerializeObject(alunoCurso);
            var mensagem = new MensagemRabbit(alunoCursoJson);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => inserirAlunoCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida a inclusão de um aluno no curso válido.")]
        private async Task Valida_Inclusao_De_Aluno_No_Curso_Valido_Deve_Retornar_True()
        {
            // Arrange
            var alunoCurso = new AlunoCursoEol(1234567, 1010, 6);
            var alunoGoogle = new AlunoGoogle(1234567, "José da Silva", "josesilva.06061990@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle> { alunoGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteAlunoCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            mediator.Setup(a => a.Send(It.IsAny<InserirAlunoCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var alunoCursoJson = JsonConvert.SerializeObject(alunoCurso);
            var mensagem = new MensagemRabbit(alunoCursoJson);

            // Act
            var retorno = await inserirAlunoCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }
    }
}
