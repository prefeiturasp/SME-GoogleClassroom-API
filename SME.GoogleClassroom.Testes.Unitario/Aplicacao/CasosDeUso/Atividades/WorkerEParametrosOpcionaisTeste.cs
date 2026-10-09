using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Atividades
{
    public class WorkerEParametrosOpcionaisTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly VariaveisGlobaisOptions variaveisGlobaisOptions;

        public WorkerEParametrosOpcionaisTeste()
        {
            mediatorMock = new Mock<IMediator>();
            variaveisGlobaisOptions = new VariaveisGlobaisOptions { DeveExecutarIntegracao = true };
        }

        [Fact(DisplayName = "FiltroCargaInicialDto - Parâmetros totalmente omitidos no construtor padrão não devem lançar exceção")]
        public void FiltroCargaInicialDto_ParametrosTotalmenteOmitidos_NaoDeveLancarExcecao()
        {
            // Act
            var filtro = new FiltroCargaInicialDto();

            // Assert
            Assert.NotNull(filtro.TiposUes);
            Assert.NotNull(filtro.Ues);
            Assert.NotNull(filtro.Turmas);
            Assert.Empty(filtro.TiposUes);
            Assert.Empty(filtro.Ues);
            Assert.Empty(filtro.Turmas);
            Assert.Equal(0, filtro.AnoLetivo);
        }

        [Fact(DisplayName = "FiltroCargaInicialDto - Parâmetros explicitamente nulos não devem lançar NullReferenceException ou ArgumentNullException")]
        public void FiltroCargaInicialDto_ParametrosExplicitamenteNulos_NaoDeveLancarExcecao()
        {
            // Act
            var filtro = new FiltroCargaInicialDto(2026, null, null, null);

            // Assert
            Assert.Equal(2026, filtro.AnoLetivo);
            Assert.NotNull(filtro.TiposUes);
            Assert.NotNull(filtro.Ues);
            Assert.NotNull(filtro.Turmas);
            Assert.Empty(filtro.TiposUes);
            Assert.Empty(filtro.Ues);
            Assert.Empty(filtro.Turmas);
        }

        [Fact(DisplayName = "FiltroCargaInicialDto - Apenas um filtro informado deve preservar valor e inicializar os demais")]
        public void FiltroCargaInicialDto_ApenasUmFiltroInformado_DevePreservarValor()
        {
            // Act - Apenas TiposUes
            var filtroTiposUes = new FiltroCargaInicialDto(2026, new List<int> { 1, 2 }, null, null);
            // Act - Apenas Ues
            var filtroUes = new FiltroCargaInicialDto(2026, null, new List<long> { 1001, 1002 }, null);
            // Act - Apenas Turmas
            var filtroTurmas = new FiltroCargaInicialDto(2026, null, null, new List<long> { 5001, 5002 });

            // Assert
            Assert.Equal(new List<int> { 1, 2 }, filtroTiposUes.TiposUes);
            Assert.Empty(filtroTiposUes.Ues);
            Assert.Empty(filtroTiposUes.Turmas);

            Assert.Equal(new List<long> { 1001, 1002 }, filtroUes.Ues);
            Assert.Empty(filtroUes.TiposUes);
            Assert.Empty(filtroUes.Turmas);

            Assert.Equal(new List<long> { 5001, 5002 }, filtroTurmas.Turmas);
            Assert.Empty(filtroTurmas.TiposUes);
            Assert.Empty(filtroTurmas.Ues);
        }

        [Fact(DisplayName = "FiltroCargaInicialDto - Combinações de filtros e valores válidos devem ser preservados")]
        public void FiltroCargaInicialDto_CombinacoesDeFiltros_DevePreservarValores()
        {
            // Act
            var tipos = new List<int> { 1 };
            var ues = new List<long> { 12345 };
            var turmas = new List<long> { 67890 };
            var filtro = new FiltroCargaInicialDto(2026, tipos, ues, turmas);

            // Assert
            Assert.Equal(2026, filtro.AnoLetivo);
            Assert.Equal(tipos, filtro.TiposUes);
            Assert.Equal(ues, filtro.Ues);
            Assert.Equal(turmas, filtro.Turmas);
        }

        [Fact(DisplayName = "ConsumoDeFilasOptions - Gsa deve ser inicializado por padrão para evitar NullReferenceException")]
        public void ConsumoDeFilasOptions_GsaInicializadoPorPadrao_NaoDeveSerNulo()
        {
            // Act
            var options = new ConsumoDeFilasOptions();

            // Assert
            Assert.NotNull(options.Gsa);
            Assert.False(options.Gsa.CargaAtividadesGsa);
            Assert.False(options.Gsa.CargaCursoGsa);
            Assert.False(options.ConsumirFilasSync);
            Assert.False(options.ConsumirFilasDeInclusao);
        }

        [Fact(DisplayName = "TrataSyncGoogleAlunoErrosUseCase - Mensagem com filtro nulo não deve lançar NullReferenceException")]
        public async Task TrataSyncGoogleAlunoErrosUseCase_QuandoFiltroForNulo_NaoDeveLancarNullReferenceException()
        {
            // Arrange
            var useCase = new TrataSyncGoogleAlunoErrosUseCase(mediatorMock.Object, variaveisGlobaisOptions);
            var usuarioErros = new List<UsuarioErro>
            {
                new UsuarioErro(123456, "aluno@edu.sme.prefeitura.sp.gov.br", "Erro teste", UsuarioTipo.Aluno, ExecucaoTipo.AlunoAdicionar)
            };

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObtemUsuariosErrosPorTipoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioErros);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ExcluirUsuarioErroCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Mensagem Rabbit sem FiltroCargaInicialDto (conteúdo de string simples)
            var mensagemRabbit = new MensagemRabbit("mensagem_sem_filtro_carga");

            // Act
            var resultado = await useCase.Executar(mensagemRabbit);

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(
                It.Is<PublicaFilaRabbitCommand>(c =>
                    c.NomeFila == RotasRabbit.FilaAlunoErroTratar &&
                    c.Mensagem is FiltroAlunoErroDto &&
                    ((FiltroAlunoErroDto)c.Mensagem).AnoLetivo == null),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "CargaInicialUseCase - Parâmetros com listas nulas não devem lançar NullReferenceException")]
        public async Task CargaInicialUseCase_ParametrosComListasNulas_NaoDeveLancarExcecao()
        {
            // Arrange
            var useCase = new CargaInicialUseCase(mediatorMock.Object);
            var filtro = new FiltroCargaInicialDto(2026, null, null, null);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<IncluirParametroCargaInicialCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ReplicarParametrosDoSistemaPorAnoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterParametrosCargaIncialPorAnoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ParametrosCargaInicialDto(null, null, null, 2026));

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await useCase.Executar(filtro);

            // Assert
            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(
                It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaGsaCargaInicial),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "IncluirParametroCargaInicialCommandHandler - Request com filtros nulos ou parciais não deve lançar exceção")]
        public async Task IncluirParametroCargaInicialCommandHandler_FiltrosParciais_DeveMesclarComSeguranca()
        {
            // Arrange
            var repositorioMock = new Mock<IRepositorioCargaInicial>();
            var handler = new IncluirParametroCargaInicialCommandHandler(repositorioMock.Object, mediatorMock.Object);

            var parametrosExistentes = new ParametrosCargaInicialDto
            {
                AnoLetivo = 2026,
                TiposUes = new List<int> { 1 },
                Ues = new List<long> { 100 },
                Turmas = new List<long> { 200 }
            };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterParametrosCargaIncialPorAnoQuery>(q => q.Ano == 2026), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametrosExistentes);

            var command = new IncluirParametroCargaInicialCommand(new FiltroCargaInicialDto(2026, new List<int> { 2 }, null, null));

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado);
            repositorioMock.Verify(r => r.InserirCargaInicial(
                2026,
                "2",
                "100",
                "200"), Times.Once);
        }
    }
}
