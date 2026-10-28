using Google;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Commands.Cursos.AlterarCurso;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos
{
    public class AtribuirDonoCursoUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly AtribuirDonoCursoUseCase useCase;

        public AtribuirDonoCursoUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new AtribuirDonoCursoUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Cenário 1 e 5: Atribuir dono válido deve atribuir no Google, atualizar email e DataAtualizacao na base local e retornar true")]
        public async Task Executar_UsuarioValido_DeveAtribuirNoGoogleEAtualizarBaseLocalComDataAtualizacao()
        {
            const string novoEmail = "novodono@edu.sme.prefeitura.sp.gov.br";
            const long turmaId = 2251678;
            const long componenteCurricularId = 512;
            var curso = new CursoGoogle("MINI GRUPO 2 A", "EI - 4A", turmaId, componenteCurricularId, "antigo@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 252599106532,
                DataAtualizacao = null
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursoPorTurmaComponenteCurricularQuery>(q => q.TurmaId == turmaId && q.ComponenteCurricularId == componenteCurricularId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(curso);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterUsuarioGoogleQuery>(q => q.Email == novoEmail), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UsuarioGoogleClassroomDto { Id = "113386492810988374897", Email = novoEmail });

            mediatorMock
                .Setup(m => m.Send(It.Is<AtribuirDonoCursoGoogleCommand>(c => c.CursoId == curso.Id && c.UsuarioId == "113386492810988374897"), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            AlterarCursoCommand comandoCapturado = null;
            mediatorMock
                .Setup(m => m.Send(It.IsAny<AlterarCursoCommand>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<bool>, CancellationToken>((cmd, _) => comandoCapturado = (AlterarCursoCommand)cmd)
                .ReturnsAsync(true);

            var antes = DateTime.Now.AddSeconds(-1);
            var resultado = await useCase.Executar(novoEmail, turmaId, componenteCurricularId);

            Assert.True(resultado);
            Assert.NotNull(comandoCapturado);
            Assert.Equal(novoEmail, comandoCapturado.Curso.Email);
            Assert.NotNull(comandoCapturado.Curso.DataAtualizacao);
            Assert.True(comandoCapturado.Curso.DataAtualizacao >= antes);
        }

        [Fact(DisplayName = "Cenário 2: Turma ou componente sem curso na base do GSA deve lançar NegocioException (601)")]
        public async Task Executar_CursoInexistenteNaBase_DeveLancarNegocioException()
        {
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((CursoGoogle)null);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar("prof@edu.sme.prefeitura.sp.gov.br", 9999999, 9999999));

            Assert.Equal("Não foi possível alterar o dono do curso, pois o curso não existe na base do GSA", ex.Message);
        }

        [Fact(DisplayName = "Cenário 3: E-mail externo (teste@mail.com.br) que retorna 403 na Directory API deve retornar mensagem 'Usuário não existe no Google Classroom'")]
        public async Task Executar_EmailExternoRetornando403NaDirectoryApi_DeveLancarMensagemUsuarioNaoExiste()
        {
            const string emailExterno = "teste@mail.com.br";
            var curso = new CursoGoogle("MINI GRUPO 2 A", "EI - 4A", 2251678, 512, "antigo@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 252599106532
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
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

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(emailExterno, 2251678, 512));

            Assert.Equal("Usuário não existe no Google Classroom", ex.Message);
            mediatorMock.Verify(m => m.Send(It.IsAny<AlterarCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Falha no Google Classroom (AtribuirDonoCursoGoogleCommand) não deve retornar sucesso nem alterar a base local")]
        public async Task Executar_FalhaAoAtribuirDonoNoGoogle_NaoDeveAlterarBaseLocalNemRetornarSucesso()
        {
            const string email = "prof@edu.sme.prefeitura.sp.gov.br";
            var curso = new CursoGoogle("MINI GRUPO 2 A", "EI - 4A", 2251678, 512, "antigo@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 252599106532
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
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

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(email, 2251678, 512));

            Assert.Equal("Usuário sem acesso ao Google Classroom", ex.Message);
            Assert.Equal("antigo@edu.sme.prefeitura.sp.gov.br", curso.Email);
            mediatorMock.Verify(m => m.Send(It.IsAny<AlterarCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "AlterarCursoCommandHandler deve atualizar DataAtualizacao ao persistir no repositório")]
        public async Task AlterarCursoCommandHandler_DeveAtualizarDataAtualizacao()
        {
            var repoMock = new Mock<IRepositorioCurso>();
            DateTime? dataAtualizacaoPersistida = null;

            repoMock
                .Setup(r => r.AlterarAsync(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime?>()))
                .Callback<long, string, string, string, long, long, DateTime, DateTime?>((_, _, _, _, _, _, _, dtAtualizacao) => dataAtualizacaoPersistida = dtAtualizacao)
                .ReturnsAsync(true);

            var handler = new AlterarCursoCommandHandler(repoMock.Object);
            var curso = new CursoGoogle("MINI GRUPO 2 A", "EI - 4A", 2251678, 512, "novo@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 252599106532,
                DataAtualizacao = null
            };

            var antes = DateTime.Now.AddSeconds(-1);
            var resultado = await handler.Handle(new AlterarCursoCommand(curso), CancellationToken.None);

            Assert.True(resultado);
            Assert.NotNull(dataAtualizacaoPersistida);
            Assert.True(dataAtualizacaoPersistida >= antes);
        }
    }
}
