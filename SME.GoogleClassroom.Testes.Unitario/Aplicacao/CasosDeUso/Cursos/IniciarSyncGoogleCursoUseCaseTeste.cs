using FluentValidation.TestHelper;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos
{
    public class IniciarSyncGoogleCursoUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly IniciarSyncGoogleCursoUseCase useCase;

        public IniciarSyncGoogleCursoUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new IniciarSyncGoogleCursoUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Cenário 1: Sem filtros (recriarCursoSeExistirNaBaseDeDados=false) deve iniciar sincronização e retornar true")]
        public async Task Executar_SemFiltros_DeveRetornarTrue()
        {
            mediatorMock
                .Setup(m => m.Send(It.Is<IniciarSyncGoogleCursoCommand>(c => !c.TurmaId.HasValue && !c.ComponenteCurricularId.HasValue), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await useCase.Executar(null, null, false);

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExisteTurmaPorIdQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExisteComponenteCurricularPorIdQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExcluirCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Cenário 2: turmaId e componenteCurricularId existentes com recriar=false deve validar e iniciar sincronização sem excluir")]
        public async Task Executar_ComTurmaEComponenteExistentes_RecriarFalse_DeveRetornarTrue()
        {
            const long turmaId = 3019661;
            const long componenteCurricularId = 525;

            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorIdQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteComponenteCurricularPorIdQuery>(q => q.ComponenteCurricularId == componenteCurricularId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<IniciarSyncGoogleCursoCommand>(c => c.TurmaId == turmaId && c.ComponenteCurricularId == componenteCurricularId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await useCase.Executar(turmaId, componenteCurricularId, false);

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExcluirCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Cenário 3: turmaId e componenteCurricularId existentes com recriar=true deve excluir curso existente e iniciar sincronização")]
        public async Task Executar_ComTurmaEComponenteExistentes_RecriarTrue_DeveExcluirCursoEIniciarSincronizacao()
        {
            const long turmaId = 3019661;
            const long componenteCurricularId = 525;
            var cursoExistente = new CursoGoogle("MATEMATICA", "EF - 9A", turmaId, componenteCurricularId, "prof@edu.sme.prefeitura.sp.gov.br")
            {
                Id = 886385498930
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorIdQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteComponenteCurricularPorIdQuery>(q => q.ComponenteCurricularId == componenteCurricularId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterCursoPorTurmaComponenteCurricularQuery>(q => q.TurmaId == turmaId && q.ComponenteCurricularId == componenteCurricularId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursoExistente);

            mediatorMock
                .Setup(m => m.Send(It.Is<ExcluirCursoCommand>(c => c.CursoId == cursoExistente.Id), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<IniciarSyncGoogleCursoCommand>(c => c.TurmaId == turmaId && c.ComponenteCurricularId == componenteCurricularId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await useCase.Executar(turmaId, componenteCurricularId, true);

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.Is<ExcluirCursoCommand>(c => c.CursoId == cursoExistente.Id), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Cenário 4: recriar=true sem componenteCurricularId deve lançar NegocioException (601)")]
        public async Task Executar_RecriarTrueSemComponenteCurricular_DeveLancarNegocioException()
        {
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(3019661, null, true));

            Assert.Equal("Para recriar o curso deve-se informar a turma e o componente curricular.", ex.Message);
            mediatorMock.Verify(m => m.Send(It.IsAny<IniciarSyncGoogleCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Cenário 4b: filtro parcial (turmaId sem componenteCurricularId e recriar=false) deve lançar NegocioException (601)")]
        public async Task Executar_TurmaSemComponente_RecriarFalse_DeveLancarNegocioException()
        {
            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(3019661, null, false));

            Assert.Equal("Para utilizar o filtro de sincronização deve-se informar a turma e o componente curricular.", ex.Message);
            mediatorMock.Verify(m => m.Send(It.IsAny<IniciarSyncGoogleCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Cenário 5: turmaId inexistente deve lançar NegocioException (601) sem excluir curso nem enfileirar")]
        public async Task Executar_TurmaInexistente_DeveLancarNegocioException()
        {
            const long turmaIdInexistente = 74685214045;
            const long componenteCurricularId = 525;

            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorIdQuery>(q => q.TurmaId == turmaIdInexistente), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(turmaIdInexistente, componenteCurricularId, true));

            Assert.Equal("A turma informada não existe.", ex.Message);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExcluirCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.IsAny<IniciarSyncGoogleCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Cenário 5b: componenteCurricularId inexistente deve lançar NegocioException (601) sem excluir curso nem enfileirar")]
        public async Task Executar_ComponenteCurricularInexistente_DeveLancarNegocioException()
        {
            const long turmaId = 3019661;
            const long componenteInexistente = 9999999;

            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteTurmaPorIdQuery>(q => q.TurmaId == turmaId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.Is<ExisteComponenteCurricularPorIdQuery>(q => q.ComponenteCurricularId == componenteInexistente), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(turmaId, componenteInexistente, true));

            Assert.Equal("O componente curricular informado não existe.", ex.Message);
            mediatorMock.Verify(m => m.Send(It.IsAny<ExcluirCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            mediatorMock.Verify(m => m.Send(It.IsAny<IniciarSyncGoogleCursoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Validator: TurmaId informado sem ComponenteCurricularId deve ser inválido")]
        public void Validator_TurmaIdSemComponenteCurricularId_DeveTerErro()
        {
            var validator = new IniciarSyncGoogleCursoCommandValidator();
            var command = new IniciarSyncGoogleCursoCommand(3019661, null);

            var result = validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.ComponenteCurricularId);
        }

        [Fact(DisplayName = "Validator: ComponenteCurricularId informado sem TurmaId deve ser inválido")]
        public void Validator_ComponenteCurricularIdSemTurmaId_DeveTerErro()
        {
            var validator = new IniciarSyncGoogleCursoCommandValidator();
            var command = new IniciarSyncGoogleCursoCommand(null, 525);

            var result = validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.TurmaId);
        }

        [Fact(DisplayName = "ExisteTurmaPorIdQueryHandler e ExisteComponenteCurricularPorIdQueryHandler devem delegar ao IRepositorioCursoEol")]
        public async Task QueryHandlers_DevemDelegarAoRepositorioCursoEol()
        {
            var repoMock = new Mock<IRepositorioCursoEol>();
            repoMock.Setup(r => r.ExisteTurmaPorId(3019661)).ReturnsAsync(true);
            repoMock.Setup(r => r.ExisteComponenteCurricularPorId(525)).ReturnsAsync(true);

            var turmaHandler = new ExisteTurmaPorIdQueryHandler(repoMock.Object);
            var componenteHandler = new ExisteComponenteCurricularPorIdQueryHandler(repoMock.Object);

            Assert.True(await turmaHandler.Handle(new ExisteTurmaPorIdQuery(3019661), CancellationToken.None));
            Assert.True(await componenteHandler.Handle(new ExisteComponenteCurricularPorIdQuery(525), CancellationToken.None));
        }
    }
}
