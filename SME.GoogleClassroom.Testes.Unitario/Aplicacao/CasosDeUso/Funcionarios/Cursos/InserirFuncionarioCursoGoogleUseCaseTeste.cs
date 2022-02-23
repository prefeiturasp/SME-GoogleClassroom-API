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

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Funcionarios.Cursos
{
    public class InserirFuncionarioCursoGoogleUseCaseTeste : TesteIntegracaoGoogleClassroom
    {
        private readonly Mock<IMediator> mediator;
        private readonly IInserirFuncionarioCursoGoogleUseCase inserirFuncionarioCursoGoogleUseCase;

        public InserirFuncionarioCursoGoogleUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            inserirFuncionarioCursoGoogleUseCase = new InserirFuncionarioCursoGoogleUseCase(mediator.Object, GerarVariaveisGlobais());
        }

        [Fact(DisplayName = "Valida o envio de JSON vazio para incluir o funcionário no curso no Google Classroom.")]
        private async Task Valida_Mensagem_Vazia_E_Deve_Disparar_NegocioException()
        {
            // Arrange
            var mensagem = new MensagemRabbit(null);

            // Assert
            await Assert.ThrowsAsync<NegocioException>(() => inserirFuncionarioCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento para funcionários que ainda não foram inclusos.")]
        private async Task Valida_Tratamento_De_Funcionario_Nao_Incluso_Deve_Retornar_False()
        {
            // Arrange
            var funcionarioCurso = new FuncionarioCursoEol(1234567, 1010, 6);

            mediator.Setup(a => a.Send(It.IsAny<ObterFuncionariosGooglePorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<FuncionarioGoogle>());

            var funcionarioCursoJson = JsonConvert.SerializeObject(funcionarioCurso);
            var mensagem = new MensagemRabbit(funcionarioCursoJson);

            // Act
            var retorno = await inserirFuncionarioCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.False(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento para cursos que ainda não foram inclusos.")]
        private async Task Valida_Tratamento_De_Curso_Nao_Incluso_Deve_Retornar_False()
        {
            // Arrange
            var funcionarioCurso = new FuncionarioCursoEol(1234567, 1010, 6);
            var funcionarioGoogle = new FuncionarioGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            CursoGoogle cursoGoogle = null;

            mediator.Setup(a => a.Send(It.IsAny<ObterFuncionariosGooglePorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<FuncionarioGoogle> { funcionarioGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            var funcionarioCursoJson = JsonConvert.SerializeObject(funcionarioCurso);
            var mensagem = new MensagemRabbit(funcionarioCursoJson);

            // Act
            var retorno = await inserirFuncionarioCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.False(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento para funcionários já inclusos no curso.")]
        private async Task Valida_Tratamento_De_Funcionario_Ja_Incluso_No_Curso_Deve_Retornar_True()
        {
            // Arrange
            var funcionarioCurso = new FuncionarioCursoEol(1234567, 1010, 6);
            var funcionarioGoogle = new FuncionarioGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterFuncionariosGooglePorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<FuncionarioGoogle> { funcionarioGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteFuncionarioCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var funcionarioCursoJson = JsonConvert.SerializeObject(funcionarioCurso);
            var mensagem = new MensagemRabbit(funcionarioCursoJson);

            // Act
            var retorno = await inserirFuncionarioCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de duplicidade no Google Classroom.")]
        private async Task Valida_Tratamento_De_Duplicidade_No_Google_Deve_Retornar_True()
        {
            // Arrange
            var funcionarioCurso = new FuncionarioCursoEol(1234567, 1010, 6);
            var funcionarioGoogle = new FuncionarioGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterFuncionariosGooglePorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<FuncionarioGoogle> { funcionarioGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteFuncionarioCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleDuplicidadeException = GerarExcecaoDeDuplicidadeDoGoogle();

            mediator.Setup(a => a.Send(It.IsAny<InserirFuncionarioCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleDuplicidadeException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var funcionarioCursoJson = JsonConvert.SerializeObject(funcionarioCurso);
            var mensagem = new MensagemRabbit(funcionarioCursoJson);

            // Act
            var retorno = await inserirFuncionarioCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral do Google Classroom.")]
        private async Task Valida_Tratamento_De_Excecoes_Do_Google_Deve_Devolver_A_GoogleApiExption_Disparada()
        {
            // Arrange
            var funcionarioCurso = new FuncionarioCursoEol(1234567, 1010, 6);
            var funcionarioGoogle = new FuncionarioGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterFuncionariosGooglePorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<FuncionarioGoogle> { funcionarioGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteFuncionarioCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var googleException = new GoogleApiException(string.Empty, "Erro no Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirFuncionarioCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(googleException);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var funcionarioCursoJson = JsonConvert.SerializeObject(funcionarioCurso);
            var mensagem = new MensagemRabbit(funcionarioCursoJson);

            // Assert
            await Assert.ThrowsAsync<GoogleApiException>(() => inserirFuncionarioCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida o tratamento de exceções em geral ao se comunicar com o Google Classroom.")]
        private async Task Valida_Tratamento_De_Excecoes_Ao_Comunicar_Com_Google_Deve_Devolver_A_Excecao_Disparada()
        {
            // Arrange
            var funcionarioCurso = new FuncionarioCursoEol(1234567, 1010, 6);
            var funcionarioGoogle = new FuncionarioGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterFuncionariosGooglePorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<FuncionarioGoogle> { funcionarioGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteFuncionarioCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var excecao = new NullReferenceException("Erro ao se comunicar Google Classroom.");

            mediator.Setup(a => a.Send(It.IsAny<InserirFuncionarioCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .Throws(excecao);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var funcionarioCursoJson = JsonConvert.SerializeObject(funcionarioCurso);
            var mensagem = new MensagemRabbit(funcionarioCursoJson);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => inserirFuncionarioCursoGoogleUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Valida a inclusão de um funcionário no curso válido.")]
        private async Task Valida_Inclusao_De_Funcionario_No_Curso_Valido_Deve_Retornar_True()
        {
            // Arrange
            var funcionarioCurso = new FuncionarioCursoEol(1234567, 1010, 6);
            var funcionarioGoogle = new FuncionarioGoogle(1234567, "José da Silva", "josesilva.1234567@edu.sme.prefeitura.sp.gov.br", string.Empty);
            var cursoGoogle = new CursoGoogle("Curso Google", "Seção", 1010, 6, "criadorDoCurso.784512@edu.sme.prefeitura.sp.gov.br");

            mediator.Setup(a => a.Send(It.IsAny<ObterFuncionariosGooglePorRfsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<FuncionarioGoogle> { funcionarioGoogle });

            mediator.Setup(a => a.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoGoogle);

            mediator.Setup(a => a.Send(It.IsAny<ExisteFuncionarioCursoGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            mediator.Setup(a => a.Send(It.IsAny<InserirFuncionarioCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(a => a.Send(It.IsAny<IncluirCursoUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var funcionarioCursoJson = JsonConvert.SerializeObject(funcionarioCurso);
            var mensagem = new MensagemRabbit(funcionarioCursoJson);

            // Act
            var retorno = await inserirFuncionarioCursoGoogleUseCase.Executar(mensagem);

            // Assert
            Assert.True(retorno);
        }
    }
}
