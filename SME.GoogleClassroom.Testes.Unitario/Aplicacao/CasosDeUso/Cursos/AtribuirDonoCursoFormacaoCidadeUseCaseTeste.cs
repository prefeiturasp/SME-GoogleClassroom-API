using Google;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos
{
    public class AtribuirDonoCursoFormacaoCidadeUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly AtribuirDonoCursoFormacaoCidadeUseCase useCase;

        public AtribuirDonoCursoFormacaoCidadeUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new AtribuirDonoCursoFormacaoCidadeUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Cenário 1 e 2: Trocar dono de salaVirtual para outro usuário válido deve encontrar o curso pelo nome, atribuir no Google e atualizar base local com DataAtualizacao")]
        public async Task Executar_OutroUsuarioValidoESalaVirtualExistente_DeveTrocarDonoEAtualizarCurso()
        {
            const string emailAntigo = "dono.antigo@edu.sme.prefeitura.sp.gov.br";
            const string emailNovo = "dono.novo@edu.sme.prefeitura.sp.gov.br";
            const string salaVirtual = "GSA-E2E-2026-REM-OWNER-001";

            var curso = new CursoGoogle(salaVirtual, "Seção Formação Cidade", 0, 0, emailAntigo)
            {
                Id = 886385498930,
                DataAtualizacao = null
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursoPorEmailNomeQuery>(q => q.Nome == salaVirtual), It.IsAny<CancellationToken>()))
                .ReturnsAsync(curso);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterUsuarioGoogleQuery>(q => q.Email == emailNovo), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UsuarioGoogleClassroomDto { Id = "999888777", Email = emailNovo });

            mediatorMock
                .Setup(m => m.Send(It.Is<AtribuirDonoCursoGoogleCommand>(c => c.CursoId == curso.Id && c.UsuarioId == "999888777"), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            AlterarCursoCommand comandoCapturado = null;
            mediatorMock
                .Setup(m => m.Send(It.IsAny<AlterarCursoCommand>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<bool>, CancellationToken>((cmd, _) => comandoCapturado = (AlterarCursoCommand)cmd)
                .ReturnsAsync(true);

            var antes = DateTime.Now.AddSeconds(-1);
            var resultado = await useCase.Executar(emailNovo, salaVirtual);

            Assert.True(resultado);
            Assert.NotNull(comandoCapturado);
            Assert.Equal(emailNovo, comandoCapturado.Curso.Email);
            Assert.NotNull(comandoCapturado.Curso.DataAtualizacao);
            Assert.True(comandoCapturado.Curso.DataAtualizacao >= antes);
        }

        [Fact(DisplayName = "Cenário 3: Sala virtual inexistente na base do GSA deve lançar NegocioException (601)")]
        public async Task Executar_SalaVirtualInexistente_DeveLancarNegocioException()
        {
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((CursoGoogle)null);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar("prof@edu.sme.prefeitura.sp.gov.br", "SALA INEXISTENTE"));

            Assert.Equal("Não foi possível alterar o dono do curso, pois o curso não existe na base do GSA", ex.Message);
        }

        [Fact(DisplayName = "Cenário 4: Validator de ObterCursoPorEmailNomeQuery deve rejeitar email e salaVirtual vazios")]
        public void Validator_SemEmailESemSalaVirtual_DeveRetornarErrosDeValidacao()
        {
            var validator = new ObterCursoPorEmailNomeQueryValidator();
            var resultado = validator.Validate(new ObterCursoPorEmailNomeQuery(string.Empty, string.Empty));

            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.ErrorMessage == "O email deve ser informado.");
            Assert.Contains(resultado.Errors, e => e.ErrorMessage == "O nome deve ser informado.");
        }

        [Fact(DisplayName = "E-mail externo (403 na Directory API) deve retornar 'Usuário não existe no Google Classroom'")]
        public async Task Executar_EmailExternoRetornando403NaDirectoryApi_DeveLancarMensagemUsuarioNaoExiste()
        {
            const string emailExterno = "teste@mail.com.br";
            const string salaVirtual = "GSA-E2E-2026-REM-OWNER-001";
            var curso = new CursoGoogle(salaVirtual, "Seção", 0, 0, "antigo@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 886385498930
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(curso);

            var directory403Ex = new GoogleApiException("admin", "Not Authorized")
            {
                HttpStatusCode = HttpStatusCode.Forbidden,
                Error = new Google.Apis.Requests.RequestError
                {
                    Code = (int)HttpStatusCode.Forbidden,
                    Message = GoogleApiExceptionMensagens.Erro403NotAuthorizedToAccess
                }
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterUsuarioGoogleQuery>(q => q.Email == emailExterno), It.IsAny<CancellationToken>()))
                .ThrowsAsync(directory403Ex);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(emailExterno, salaVirtual));

            Assert.Equal("Usuário não existe no Google Classroom", ex.Message);
            mediatorMock.Verify(m => m.Send(It.IsAny<AlterarCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Falha no Google Classroom não deve retornar sucesso nem alterar base local")]
        public async Task Executar_FalhaAoAtribuirDonoNoGoogle_NaoDeveAlterarBaseLocal()
        {
            const string email = "prof@edu.sme.prefeitura.sp.gov.br";
            const string salaVirtual = "GSA-E2E-2026-REM-OWNER-001";
            var curso = new CursoGoogle(salaVirtual, "Seção", 0, 0, "antigo@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 886385498930
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorEmailNomeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(curso);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterUsuarioGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UsuarioGoogleClassroomDto { Id = "123456", Email = email });

            var classroom403Ex = new GoogleApiException("classroom", "Forbidden")
            {
                HttpStatusCode = HttpStatusCode.Forbidden,
                Error = new Google.Apis.Requests.RequestError
                {
                    Code = (int)HttpStatusCode.Forbidden,
                    Message = GoogleApiExceptionMensagens.Erro403NotAuthorizedToAccess
                }
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<AtribuirDonoCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(classroom403Ex);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(email, salaVirtual));

            Assert.Equal("Usuário sem acesso ao Google Classroom", ex.Message);
            Assert.Equal("antigo@edu.sme.prefeitura.sp.gov.br", curso.Email);
            mediatorMock.Verify(m => m.Send(It.IsAny<AlterarCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
