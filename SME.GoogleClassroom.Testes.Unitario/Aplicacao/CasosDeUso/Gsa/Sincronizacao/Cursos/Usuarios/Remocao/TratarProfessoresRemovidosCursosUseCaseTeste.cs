using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Gsa.Sincronizacao.Cursos.Usuarios.Remocao
{
    public class TratarProfessoresRemovidosCursosUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly TratarProfessoresRemovidosCursosUseCase useCase;

        public TratarProfessoresRemovidosCursosUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            useCase = new TratarProfessoresRemovidosCursosUseCase(mediator.Object);
        }

        private MensagemRabbit CriarMensagemRabbit(FiltroTurmaRemoverCursoUsuarioDto filtro)
        {
            var json = JsonConvert.SerializeObject(filtro);
            return new MensagemRabbit(json);
        }

        [Fact(DisplayName = "Executar quando sucesso deve publicar na fila de sincronização de remoção")]
        public async Task Executar_QuandoSucesso_DevePublicarNaFilaGsaCursoUsuarioRemovidoSync()
        {
            // Arrange
            var vigencia = new VigenciaDto(DateTime.Today.AddDays(-10), DateTime.Today);
            var filtro = new FiltroTurmaRemoverCursoUsuarioDto(vigencia, vigencia, vigencia, 12345, false, true, false);

            var professorRemover = new RemoverAtribuicaoProfessorCursoEolDto
            {
                UsuarioRf = "1234567",
                TurmaCodigo = 12345,
                ComponenteCurricularCodigo = 6
            };

            var professorCadastrado = new ProfessorCursosCadastradosDto
            {
                Indice = 100,
                GoogleClassRoomId = "google-prof-123",
                Email = "professor@edu.sme.prefeitura.sp.gov.br",
                CursoUsuarioId = 999,
                Cursos = new List<CursoDto>
                {
                    new CursoDto { CursoId = 555, TurmaId = 12345, ComponenteCurricularId = 6, Email = "outro.dono@edu.sme.prefeitura.sp.gov.br" }
                }
            };

            var paginacaoResultado = new PaginacaoResultadoDto<ProfessorCursosCadastradosDto>
            {
                Items = new List<ProfessorCursosCadastradosDto> { professorCadastrado }
            };

            mediator.Setup(m => m.Send(It.IsAny<ObterProfessoresParaRemoverCursoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<RemoverAtribuicaoProfessorCursoEolDto> { professorRemover });

            mediator.Setup(m => m.Send(It.IsAny<ObterProfessoresCursosGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paginacaoResultado);

            mediator.Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(CriarMensagemRabbit(filtro));

            // Assert
            Assert.True(resultado);
            mediator.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaGsaCursoUsuarioRemovidoSync), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Executar quando professor é dono e alteração falha deve publicar na fila de erro")]
        public async Task Executar_QuandoProfessorEhDonoEFalhaAoAlterarDono_DevePublicarNaFilaDeErro()
        {
            // Arrange
            var vigencia = new VigenciaDto(DateTime.Today.AddDays(-10), DateTime.Today);
            var filtro = new FiltroTurmaRemoverCursoUsuarioDto(vigencia, vigencia, vigencia, 12345, false, true, false);

            var professorRemover = new RemoverAtribuicaoProfessorCursoEolDto
            {
                UsuarioRf = "1234567",
                TurmaCodigo = 12345,
                ComponenteCurricularCodigo = 6
            };

            var professorCadastrado = new ProfessorCursosCadastradosDto
            {
                Indice = 100,
                GoogleClassRoomId = "google-prof-123",
                Email = "professor.dono@edu.sme.prefeitura.sp.gov.br",
                CursoUsuarioId = 999,
                Cursos = new List<CursoDto>
                {
                    new CursoDto { CursoId = 555, TurmaId = 12345, ComponenteCurricularId = 6, Email = "professor.dono@edu.sme.prefeitura.sp.gov.br" }
                }
            };

            var paginacaoResultado = new PaginacaoResultadoDto<ProfessorCursosCadastradosDto>
            {
                Items = new List<ProfessorCursosCadastradosDto> { professorCadastrado }
            };

            var gestorCurso = new UsuarioGoogleDto
            {
                GoogleClassroomId = "gestor-id-1",
                Email = "gestor@edu.sme.prefeitura.sp.gov.br",
                OrganizationPath = "/Admin/CP"
            };

            mediator.Setup(m => m.Send(It.IsAny<ObterProfessoresParaRemoverCursoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<RemoverAtribuicaoProfessorCursoEolDto> { professorRemover });

            mediator.Setup(m => m.Send(It.IsAny<ObterProfessoresCursosGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paginacaoResultado);

            mediator.Setup(m => m.Send(It.IsAny<ObterFuncionariosPorCursoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<UsuarioGoogleDto> { gestorCurso });

            mediator.Setup(m => m.Send(It.IsAny<AtribuirDonoCursoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false); // Falha ao atribuir novo dono

            mediator.Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(CriarMensagemRabbit(filtro));

            // Assert
            Assert.True(resultado);
            mediator.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaGsaCursoUsuarioRemovidoSync), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Executar quando ocorre exceção ao obter dados deve publicar na fila de erro")]
        public async Task Executar_QuandoOcorreExcecao_DevePublicarNaFilaDeErro()
        {
            // Arrange
            var vigencia = new VigenciaDto(DateTime.Today.AddDays(-10), DateTime.Today);
            var filtro = new FiltroTurmaRemoverCursoUsuarioDto(vigencia, vigencia, vigencia, 12345, false, true, false);

            var professorRemover = new RemoverAtribuicaoProfessorCursoEolDto
            {
                UsuarioRf = "1234567",
                TurmaCodigo = 12345,
                ComponenteCurricularCodigo = 6
            };

            mediator.Setup(m => m.Send(It.IsAny<ObterProfessoresParaRemoverCursoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<RemoverAtribuicaoProfessorCursoEolDto> { professorRemover });

            mediator.Setup(m => m.Send(It.IsAny<ObterProfessoresCursosGoogleQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Erro de teste ao buscar professor do curso"));

            mediator.Setup(m => m.Send(It.IsAny<SalvarLogViaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator.Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(CriarMensagemRabbit(filtro));

            // Assert
            Assert.True(resultado);
            mediator.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<SalvarLogViaRabbitCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
