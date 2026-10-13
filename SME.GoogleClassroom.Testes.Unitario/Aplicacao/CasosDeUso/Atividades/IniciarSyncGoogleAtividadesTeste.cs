using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Atividades
{
    public class IniciarSyncGoogleAtividadesTeste
    {
        private readonly Mock<IMediator> mediatorMock;

        public IniciarSyncGoogleAtividadesTeste()
        {
            mediatorMock = new Mock<IMediator>();
        }

        [Fact(DisplayName = "IniciarSyncGoogleAtividadesDto - Construtor padrão deve inicializar campos como nulos")]
        public void IniciarSyncGoogleAtividadesDto_ConstrutorPadrao_CamposDevemSerNulos()
        {
            // Act
            var dto = new IniciarSyncGoogleAtividadesDto();

            // Assert
            Assert.Null(dto.CursoId);
            Assert.Null(dto.Pagina);
            Assert.Null(dto.TotalPaginas);
        }

        [Fact(DisplayName = "IniciarSyncGoogleAtividadesDto - Serialização e desserialização JSON deve preservar dados")]
        public void IniciarSyncGoogleAtividadesDto_SerializacaoEDesserializacao_DevePreservarDados()
        {
            // Arrange
            var json = "{\"cursoId\": 12345, \"pagina\": 2, \"totalPaginas\": 10}";

            // Act
            var dto = JsonConvert.DeserializeObject<IniciarSyncGoogleAtividadesDto>(json);

            // Assert
            Assert.NotNull(dto);
            Assert.Equal(12345L, dto.CursoId);
            Assert.Equal(2, dto.Pagina);
            Assert.Equal(10, dto.TotalPaginas);

            var serialized = JsonConvert.SerializeObject(dto);
            Assert.Contains("\"CursoId\":12345", serialized);
        }

        [Fact(DisplayName = "IniciarSyncAtividadesDto - Nomenclatura aderente deve herdar e comportar-se de forma equivalente")]
        public void IniciarSyncAtividadesDto_DeveManterEquivalenciaComContrato()
        {
            // Act
            var dto = new IniciarSyncAtividadesDto(999L, 1, 3);

            // Assert
            Assert.Equal(999L, dto.CursoId);
            Assert.Equal(1, dto.Pagina);
            Assert.Equal(3, dto.TotalPaginas);
            Assert.IsAssignableFrom<IniciarSyncGoogleAtividadesDto>(dto);
        }

        [Fact(DisplayName = "IniciarSyncGoogleAtividadesUseCase - DTO preenchido deve publicar na fila FilaGsaAtividadesCarregar com dados mapeados")]
        public async Task IniciarSyncGoogleAtividadesUseCase_DtoPreenchido_DevePublicarNaFilaComMesmosDados()
        {
            // Arrange
            var useCase = new IniciarSyncGoogleAtividadesUseCase(mediatorMock.Object);
            var dto = new IniciarSyncGoogleAtividadesDto(555L, 3, 8);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            await useCase.Executar(dto);

            // Assert
            mediatorMock.Verify(m => m.Send(
                It.Is<PublicaFilaRabbitCommand>(c =>
                    c.NomeFila == RotasRabbit.FilaGsaAtividadesCarregar &&
                    c.Mensagem is FiltroCargaAtividadesCursoDto &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).CursoId == 555L &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).Pagina == 3 &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).TotalPaginas == 8),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "IniciarSyncGoogleAtividadesUseCase - DTO nulo deve publicar na fila sem lançar NullReferenceException")]
        public async Task IniciarSyncGoogleAtividadesUseCase_DtoNulo_DevePublicarSemLancarExcecao()
        {
            // Arrange
            var useCase = new IniciarSyncGoogleAtividadesUseCase(mediatorMock.Object);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            await useCase.Executar(filtro: null);

            // Assert
            mediatorMock.Verify(m => m.Send(
                It.Is<PublicaFilaRabbitCommand>(c =>
                    c.NomeFila == RotasRabbit.FilaGsaAtividadesCarregar &&
                    c.Mensagem is FiltroCargaAtividadesCursoDto &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).CursoId == null &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).Pagina == null &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).TotalPaginas == null),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "IniciarSyncGoogleAtividadesUseCase - Sobrecarga com parâmetros opcionais deve mapear e publicar")]
        public async Task IniciarSyncGoogleAtividadesUseCase_SobrecargaParametrosOpcionais_DeveMapearEPublicar()
        {
            // Arrange
            var useCase = new IniciarSyncGoogleAtividadesUseCase(mediatorMock.Object);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            await useCase.Executar(cursoId: 777L);

            // Assert
            mediatorMock.Verify(m => m.Send(
                It.Is<PublicaFilaRabbitCommand>(c =>
                    c.NomeFila == RotasRabbit.FilaGsaAtividadesCarregar &&
                    c.Mensagem is FiltroCargaAtividadesCursoDto &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).CursoId == 777L &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).Pagina == null &&
                    ((FiltroCargaAtividadesCursoDto)c.Mensagem).TotalPaginas == null),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
