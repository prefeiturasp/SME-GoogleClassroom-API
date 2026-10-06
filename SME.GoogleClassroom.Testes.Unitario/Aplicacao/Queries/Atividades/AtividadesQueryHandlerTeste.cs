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

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Atividades
{
    public class AtividadesQueryHandlerTeste
    {
        private readonly Mock<IRepositorioAtividade> repositorioAtividadeMock;
        private readonly AtividadesQueryHandler handler;

        public AtividadesQueryHandlerTeste()
        {
            repositorioAtividadeMock = new Mock<IRepositorioAtividade>();
            handler = new AtividadesQueryHandler(repositorioAtividadeMock.Object);
        }

        [Fact(DisplayName = "Handler deve mapear entidade AtividadeGsa para AtividadeDto preservando campos do contrato")]
        public async Task Handle_DeveMapearEntidadeParaAtividadeDtoPreservandoCampos()
        {
            // Arrange
            var dataReferencia = new DateTime(2021, 5, 10);
            var dataInclusao = new DateTime(2021, 5, 10, 8, 30, 0);
            var dataAlteracao = new DateTime(2021, 5, 11, 10, 0, 0);
            var dataEntrega = new DateTime(2021, 5, 20);
            var paginacao = new Paginacao(1, 10);

            var atividadeGsa = new AtividadeGsa(
                id: 1001,
                titulo: "Lição 1",
                descricao: "Descrição da atividade",
                usuarioId: "prof-gsa-1",
                cursoId: 5001,
                dataInclusao: dataInclusao,
                dataAlteracao: dataAlteracao,
                dataEntrega: dataEntrega,
                notaMaxima: 10.0
            );

            var resultadoRepositorio = new PaginacaoResultadoDto<AtividadeGsa>
            {
                TotalPaginas = 1,
                TotalRegistros = 1,
                Items = new List<AtividadeGsa> { atividadeGsa }
            };

            repositorioAtividadeMock
                .Setup(r => r.ObterAtividadesPorDataCurso(paginacao, dataReferencia, 5001))
                .ReturnsAsync(resultadoRepositorio);

            var query = new AtividadesQuery(paginacao, dataReferencia, 5001);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.TotalRegistros);
            Assert.Equal(1, resultado.TotalPaginas);

            var itemDto = resultado.Items.First();
            Assert.IsType<AtividadeDto>(itemDto);
            Assert.Equal(1001, itemDto.Id);
            Assert.Equal("Lição 1", itemDto.Titulo);
            Assert.Equal("Descrição da atividade", itemDto.Descricao);
            Assert.Equal("prof-gsa-1", itemDto.UsuarioGsaId);
            Assert.Equal(5001, itemDto.CursoGsaId);
            Assert.Equal(dataInclusao, itemDto.DataInclusao);
            Assert.Equal(dataAlteracao, itemDto.DataAlteracao);
            Assert.Equal(dataEntrega, itemDto.DataEntrega);
            Assert.Equal(10.0, itemDto.NotaMaxima);
        }
    }
}
