using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Notas
{
    public class ObterNotasAtividadesAvaliativasQueryHandlerTeste
    {
        [Fact(DisplayName = "Deve obter notas das atividades avaliativas com sucesso")]
        public async Task Deve_Obter_Notas_Atividades_Avaliativas_Com_Sucesso()
        {
            // Arrange
            var repositorioNotaMock = new Mock<IRepositorioNota>();
            var paginacao = new Paginacao(1, 10);
            var dataReferencia = new DateTime(2026, 10, 26);
            long? atividadeId = 123456;
            var query = new ObterNotasAtividadesAvaliativasQuery(paginacao, atividadeId, dataReferencia);

            var retornoEsperado = new PaginacaoResultadoDto<NotasAtividadesDto>
            {
                TotalRegistros = 1,
                TotalPaginas = 1,
                Items = new List<NotasAtividadesDto>
                {
                    new NotasAtividadesDto
                    {
                        Id = "submission-1",
                        AtividadeId = 123456,
                        UsuarioId = "google-user-123",
                        CodigoAluno = "9876543",
                        CursoNome = "Matemática",
                        CursoSecao = "Turma A",
                        Nota = 8.5,
                        Status = StatusGSA.RETURNED,
                        DataImportacao = dataReferencia,
                        DataInclusao = dataReferencia
                    }
                }
            };

            repositorioNotaMock
                .Setup(r => r.ObterNotasAtividadesPorData(query.Paginacao, query.DataReferencia, query.AtividadeId))
                .ReturnsAsync(retornoEsperado);

            var handler = new ObterNotasAtividadesAvaliativasQueryHandler(repositorioNotaMock.Object);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.TotalRegistros);
            var item = resultado.Items.First();
            Assert.Equal("submission-1", item.Id);
            Assert.Equal(123456, item.AtividadeId);
            Assert.Equal("google-user-123", item.UsuarioId);
            Assert.Equal("9876543", item.CodigoAluno);
            Assert.Equal("Matemática", item.CursoNome);
            Assert.Equal("Turma A", item.CursoSecao);
            Assert.Equal(8.5, item.Nota);

            repositorioNotaMock.Verify(r => r.ObterNotasAtividadesPorData(query.Paginacao, query.DataReferencia, query.AtividadeId), Times.Once);
        }

        [Fact(DisplayName = "Deve falhar na validação quando data de importação/referência for padrão/vazia")]
        public void Deve_Falhar_Validacao_DataReferencia_Vazia()
        {
            // Arrange
            var paginacao = new Paginacao(1, 10);
            var query = new ObterNotasAtividadesAvaliativasQuery(paginacao, null, default);
            var validator = new ObterNotasAtividadesAvaliativasQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Errors, e => e.PropertyName == nameof(query.DataReferencia));
        }

        [Fact(DisplayName = "Deve passar na validação quando data de importação/referência for informada")]
        public void Deve_Passar_Validacao_DataReferencia_Informada()
        {
            // Arrange
            var paginacao = new Paginacao(1, 10);
            var query = new ObterNotasAtividadesAvaliativasQuery(paginacao, 1234, new DateTime(2026, 10, 26));
            var validator = new ObterNotasAtividadesAvaliativasQueryValidator();

            // Act
            var resultado = validator.Validate(query);

            // Assert
            Assert.True(resultado.IsValid);
            Assert.Empty(resultado.Errors);
        }
    }
}
