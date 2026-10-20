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

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Alunos
{
    public class TrataSyncGoogleAlunoUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly ITrataSyncGoogleAlunoUseCase trataSyncGoogleAlunoUseCase;

        public TrataSyncGoogleAlunoUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            trataSyncGoogleAlunoUseCase = new TrataSyncGoogleAlunoUseCase(mediator.Object);
        }

        [Fact(DisplayName = "Quando mensagem rabbit for nula, deve lançar NegocioException.")]
        public async Task Executar_MensagemNula_DeveLancarNegocioException()
        {
            var mensagem = new MensagemRabbit(null);

            await Assert.ThrowsAsync<NegocioException>(() => trataSyncGoogleAlunoUseCase.Executar(mensagem));
        }

        [Fact(DisplayName = "Quando não houver alunos retornados do EOL, não deve disparar ObterAlunosPorCodigosQuery e deve retornar true.")]
        public async Task Executar_SemAlunosEol_NaoDeveChamarObterAlunosPorCodigosQuery()
        {
            // Arrange
            var dto = new IniciarSyncGoogleAlunoDto { CodigoAluno = 123456 };
            var mensagem = new MensagemRabbit(JsonConvert.SerializeObject(dto));

            mediator.Setup(m => m.Send(It.IsAny<ObterParametrosCargaIncialPorAnoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ParametrosCargaInicialDto(new List<int> { 1 }, new List<long> { 1 }, new List<long> { 1 }, DateTime.Today.Year));

            mediator.Setup(m => m.Send(It.IsAny<ObterAlunosNovosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PaginacaoResultadoDto<AlunoEol>
                {
                    Items = new List<AlunoEol>(),
                    TotalRegistros = 0,
                    TotalPaginas = 0
                });

            // Act
            var resultado = await trataSyncGoogleAlunoUseCase.Executar(mensagem);

            // Assert
            Assert.True(resultado);
            mediator.Verify(m => m.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Quando houver alunos retornados do EOL, deve buscar alunos cadastrados e publicar na fila de inclusão.")]
        public async Task Executar_ComAlunosEol_DeveBuscarCadastradosEPublicarFila()
        {
            // Arrange
            var dto = new IniciarSyncGoogleAlunoDto { CodigoAluno = 123456 };
            var mensagem = new MensagemRabbit(JsonConvert.SerializeObject(dto));
            var alunoEol = new AlunoEol(123456, "Aluno Teste", "", "", DateTime.Now);

            mediator.Setup(m => m.Send(It.IsAny<ObterParametrosCargaIncialPorAnoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ParametrosCargaInicialDto(new List<int> { 1 }, new List<long> { 1 }, new List<long> { 1 }, DateTime.Today.Year));

            mediator.Setup(m => m.Send(It.IsAny<ObterAlunosNovosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PaginacaoResultadoDto<AlunoEol>
                {
                    Items = new List<AlunoEol> { alunoEol },
                    TotalRegistros = 1,
                    TotalPaginas = 1
                });

            mediator.Setup(m => m.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AlunoGoogle>());

            mediator.Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await trataSyncGoogleAlunoUseCase.Executar(mensagem);

            // Assert
            Assert.True(resultado);
            mediator.Verify(m => m.Send(It.IsAny<ObterAlunosPorCodigosQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c => c.NomeFila == RotasRabbit.FilaAlunoIncluir), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

