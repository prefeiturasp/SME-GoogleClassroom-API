using Google;
using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Professores.Cursos
{
    public class InserirProfessorCursoGoogleUseCaseTeste : TesteIntegracaoGoogleClassroom
    {
        private readonly Mock<IMediator> mediator;
        private readonly IIncluirProfessorCursoGoogleUseCase incluirProfessorCursoGoogleUseCase;

        public InserirProfessorCursoGoogleUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            incluirProfessorCursoGoogleUseCase = new IncluirProfessorCursoGoogleUseCase(mediator.Object, GerarVariaveisGlobais());
        }

        [Fact(DisplayName = "Valida o envio de JSON vazio para incluir o professor no curso no Google Classroom.")]
        private async Task Valida_Mensagem_Vazia_E_Deve_Disparar_NegocioException()
        {
            // Arrange
            var mensagem = new MensagemRabbit(null);

            // Assert
            await Assert.ThrowsAsync<NegocioException>(() => incluirProfessorCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento para professores que ainda não foram inclusos.")]
        private async Task Valida_Tratamento_De_Professor_Nao_Incluso_Deve_Retornar_False()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6);

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle>());

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.False(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento para cursos que ainda não foram inclusos.")]
        private async Task Valida_Tratamento_De_Curso_Nao_Incluso_Deve_Retornar_False()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            CursoGoogle cursoGoogle = null;

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.False(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento para professores já inclusos no curso.")]
        private async Task Valida_Tratamento_De_Professor_Ja_Incluso_No_Curso_Deve_Retornar_True()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de duplicidade no Google Classroom.")]
        private async Task Valida_Tratamento_De_Duplicidade_No_Google_Deve_Retornar_True()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleDuplicidadeException = GerarExcecaoDeDuplicidadeDoGoogle();

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleDuplicidadeException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral do Google Classroom.")]
        private async Task Valida_Tratamento_De_Excecoes_Do_Google_Deve_Devolver_A_GoogleApiExption_Disparada()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleException = new GoogleApiException(string.Empty, "Erro no Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Assert
            await Assert.ThrowsAsync<GoogleApiException>(() => incluirProfessorCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral ao se comunicar com o Google Classroom.")]
        private async Task Valida_Tratamento_De_Excecoes_Ao_Comunicar_Com_Google_Deve_Devolver_A_Excecao_Disparada()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var excecao = new NullReferenceException("Erro ao se comunicar Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(excecao);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => incluirProfessorCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida a inclusão de um professor no curso válido.")]
        private async Task Valida_Inclusao_De_Professor_No_Curso_Valido_Deve_Retornar_True()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida atribuição do professor como dono quando o dono atual for gestor.")]
        public async Task Valida_Atribuicao_Dono_Quando_Dono_Atual_Eh_Gestor()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6, 5);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty) { GoogleClassroomId = "googleProf123" };
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "gestor.escola@edu.sme.prefeitura.sp.gov.br") { Id = 98765 };
            var usuarioGestor = new UsuarioGoogleDto { UsuarioTipo = 3, Email = "gestor.escola@edu.sme.prefeitura.sp.gov.br" };

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            mediator.Setup(a => a.Send(It.IsAny<ObterUsuarioPorEmailQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioGestor);

            mediator.Setup(a => a.Send(It.IsAny<AtribuirDonoCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<AlterarCursoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
            mediator.Verify(a => a.Send(It.Is<AtribuirDonoCursoGoogleCommand>(c => c.CursoId == cursoGoogle.Id && c.UsuarioId == "googleProf123"), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(a => a.Send(It.Is<AlterarCursoCommand>(c => c.Curso.Email == professorGoogle.Email), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Valida que professor não é atribuído como dono quando dono atual for nulo.")]
        public async Task Valida_Nao_Atribuicao_Dono_Quando_Dono_Atual_Eh_Nulo()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6, 5);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", "googleProf123");
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "desconhecido@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            mediator.Setup(a => a.Send(It.IsAny<ObterUsuarioPorEmailQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((UsuarioGoogleDto)null);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
            mediator.Verify(a => a.Send(It.IsAny<AtribuirDonoCursoGoogleCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Valida que professor não é atribuído como dono quando dono atual não for gestor.")]
        public async Task Valida_Nao_Atribuicao_Dono_Quando_Dono_Atual_Nao_Eh_Gestor()
        {
            // Arrange
            var professorCurso = new ProfessorCursoEol(1234567, 1010, 6, 5);
            var professorGoogle = new ProfessorGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", "googleProf123");
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "outro.professor@edu.sme.prefeitura.sp.gov.br");
            var usuarioProfessor = new UsuarioGoogleDto { UsuarioTipo = 2, Email = "outro.professor@edu.sme.prefeitura.sp.gov.br" };

            mediator.Setup(a => a.Send(It.IsAny<ObterProfessoresPorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProfessorGoogle> { professorGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteProfessorCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            mediator.Setup(a => a.Send(It.IsAny<InserirProfessorCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            mediator.Setup(a => a.Send(It.IsAny<ObterUsuarioPorEmailQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioProfessor);

            var professorCursoJson = JsonConvert.SerializeObject(professorCurso);
            var mensagem = new MensagemRabbit(professorCursoJson);

            // Act
            var retorno = await incluirProfessorCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
            mediator.Verify(a => a.Send(It.IsAny<AtribuirDonoCursoGoogleCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
