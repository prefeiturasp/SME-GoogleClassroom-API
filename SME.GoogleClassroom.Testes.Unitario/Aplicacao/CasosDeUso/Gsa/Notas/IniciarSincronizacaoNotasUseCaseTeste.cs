using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Gsa.Notas
{
    public class IniciarSincronizacaoNotasUseCaseTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly IniciarSincronizacaoNotasUseCase useCase;

        public IniciarSincronizacaoNotasUseCaseTeste()
        {
            mediatorMock = new Mock<IMediator>();
            useCase = new IniciarSincronizacaoNotasUseCase(mediatorMock.Object);
        }

        [Fact(DisplayName = "Quando parâmetro TotalDiasImportacaoNotas não existir para o ano corrente, deve lançar NegocioException")]
        public async Task Executar_ParametroNaoExiste_DeveLancarNegocioException()
        {
            var filtro = new FiltroNotasAtividadesSincronizacaoDto { CursoId = 12345 };

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterParametroSistemaPorTipoEAnoQuery>(q =>
                    q.Tipo == TipoParametroSistema.TotalDiasImportacaoNotas &&
                    q.Ano == DateTime.Today.Year), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ParametrosSistema)null);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(filtro));
            Assert.Contains("Total de dias para importação de Notas não localizado", ex.Message);
        }

        [Fact(DisplayName = "Quando publicação no RabbitMQ falhar, deve lançar NegocioException")]
        public async Task Executar_FalhaAoPublicarRabbit_DeveLancarNegocioException()
        {
            var filtro = new FiltroNotasAtividadesSincronizacaoDto { CursoId = 12345 };
            var parametro = new ParametrosSistema(1, "TotalDiasImportacaoNotas", TipoParametroSistema.TotalDiasImportacaoNotas, "Dias importação", "15", DateTime.Today.Year, true);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterParametroSistemaPorTipoEAnoQuery>(q =>
                    q.Tipo == TipoParametroSistema.TotalDiasImportacaoNotas &&
                    q.Ano == DateTime.Today.Year), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametro);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(filtro));
        }

        [Fact(DisplayName = "Quando parâmetro existir e publicação no RabbitMQ tiver sucesso, deve concluir sem erro")]
        public async Task Executar_Sucesso_DevePublicarFilaRabbit()
        {
            var filtro = new FiltroNotasAtividadesSincronizacaoDto { CursoId = 12345, Pagina = 1, TotalPaginas = 10 };
            var parametro = new ParametrosSistema(1, "TotalDiasImportacaoNotas", TipoParametroSistema.TotalDiasImportacaoNotas, "Dias importação", "15", DateTime.Today.Year, true);

            mediatorMock
                .Setup(m => m.Send(It.Is<ObterParametroSistemaPorTipoEAnoQuery>(q =>
                    q.Tipo == TipoParametroSistema.TotalDiasImportacaoNotas &&
                    q.Ano == DateTime.Today.Year), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametro);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            await useCase.Executar(filtro);

            mediatorMock.Verify(m => m.Send(It.Is<PublicaFilaRabbitCommand>(c =>
                c.NomeFila == RotasRabbit.FilaGsaNotasAtividadesCarregar &&
                c.Mensagem == filtro), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
