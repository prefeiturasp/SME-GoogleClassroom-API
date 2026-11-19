using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.ConectaFormacao
{
    public class ListagemDetalhamentoFormacaoQueryHandlerTeste
    {
        private readonly Mock<IRepositorioConectaFormacao> repositorioConectaFormacaoMock;
        private readonly Mock<IRepositorioProfessorEol> repositorioProfessorEolMock;
        private readonly Mock<IRepositorioUsuario> repositorioUsuarioMock;
        private readonly Mock<IMediator> mediatorMock;
        private readonly ListagemDetalhamentoFormacaoQueryHandler handler;

        public ListagemDetalhamentoFormacaoQueryHandlerTeste()
        {
            repositorioConectaFormacaoMock = new Mock<IRepositorioConectaFormacao>();
            repositorioProfessorEolMock = new Mock<IRepositorioProfessorEol>();
            repositorioUsuarioMock = new Mock<IRepositorioUsuario>();
            mediatorMock = new Mock<IMediator>();

            handler = new ListagemDetalhamentoFormacaoQueryHandler(
                repositorioConectaFormacaoMock.Object,
                repositorioProfessorEolMock.Object,
                repositorioUsuarioMock.Object,
                mediatorMock.Object);
        }

        [Fact(DisplayName = "Quando codigoIE for informado, não deve sobrescrever com EMFORPEF")]
        public async Task Handle_ComCodigoIEInformado_NaoDeveSobrescreverParaEmforpef()
        {
            // Arrange
            int ano = 2026;
            long codigoIE = 11;

            var formacoes = new List<FormacaoDTO>
            {
                new FormacaoDTO
                {
                    Codigo = 5001,
                    Nome = "FORMAÇÃO TESTE ",
                    CodigoAreaPromotora = 11,
                    NomeAreaPromotora = "Área Promotora Teste ",
                    Ano = 2026
                }
            };

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemFormacoesPorAno(ano, codigoIE))
                .ReturnsAsync(formacoes);

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemTurmasPorCodigosFormacoes(It.IsAny<long[]>()))
                .ReturnsAsync(Enumerable.Empty<FormacaoTurmaDTO>());

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemProfessoresRegentesPorCodigosFormacoes(It.IsAny<long[]>()))
                .ReturnsAsync(Enumerable.Empty<FormacaoTurmaProfessoresDTO>());

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemProfessoresTutoresPorCodigosFormacoes(It.IsAny<long[]>()))
                .ReturnsAsync(Enumerable.Empty<FormacaoTurmaProfessoresDTO>());

            var query = new ListagemDetalhamentoFormacaoQuery(ano, codigoIE);

            // Act
            var resultado = (await handler.Handle(query, CancellationToken.None))?.ToList();

            // Assert
            Assert.NotNull(resultado);
            Assert.Single(resultado);

            var formacao = resultado[0];
            Assert.Equal("11", formacao.CodigoIE);
            Assert.Equal("Área Promotora Teste", formacao.NomeIE);
            Assert.NotEqual("41", formacao.CodigoIE);
            Assert.NotEqual("EMFORPEF", formacao.NomeIE);
        }

        [Fact(DisplayName = "Quando professor não possuir RF, o campo RF não deve ser preenchido com o CPF")]
        public async Task Handle_ProfessorSemRf_NaoDevePreencherRfComCpf()
        {
            // Arrange
            int ano = 2026;

            var formacoes = new List<FormacaoDTO>
            {
                new FormacaoDTO
                {
                    Codigo = 5001,
                    Nome = "FORMAÇÃO 1",
                    CodigoAreaPromotora = 1,
                    NomeAreaPromotora = "COPED",
                    Ano = 2026
                }
            };

            var turmas = new List<FormacaoTurmaDTO>
            {
                new FormacaoTurmaDTO
                {
                    Codigo = 9001,
                    CodigoFormacao = 5001,
                    Nome = "TURMA 1 "
                }
            };

            var tutores = new List<FormacaoTurmaProfessoresDTO>
            {
                new FormacaoTurmaProfessoresDTO
                {
                    CodigoTurma = 9001,
                    Rf = null,
                    Cpf = "41567043780",
                    Nome = "PETER PARKER JÚNIOR ",
                    Tutor = true
                }
            };

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemFormacoesPorAno(ano, null))
                .ReturnsAsync(formacoes);

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemTurmasPorCodigosFormacoes(It.IsAny<long[]>()))
                .ReturnsAsync(turmas);

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemProfessoresRegentesPorCodigosFormacoes(It.IsAny<long[]>()))
                .ReturnsAsync(Enumerable.Empty<FormacaoTurmaProfessoresDTO>());

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemProfessoresTutoresPorCodigosFormacoes(It.IsAny<long[]>()))
                .ReturnsAsync(tutores);

            repositorioUsuarioMock
                .Setup(r => r.ObterUsuariosGooglePorCpfs(It.IsAny<string[]>(), It.IsAny<int[]>()))
                .ReturnsAsync(new[]
                {
                    new UsuarioGoogleDto { Cpf = "41567043780", Email = "peter.parker@edu.sme.sp.gov.br " }
                });

            var query = new ListagemDetalhamentoFormacaoQuery(ano, null);

            // Act
            var resultado = (await handler.Handle(query, CancellationToken.None))?.ToList();

            // Assert
            Assert.NotNull(resultado);
            var professor = resultado[0].Turmas.First().Professores.First();

            Assert.Null(professor.Rf);
            Assert.Equal("41567043780", professor.Cpf);
            Assert.Equal("PETER PARKER JÚNIOR", professor.Nome);
            Assert.Equal("peter.parker@edu.sme.sp.gov.br", professor.Email);
            Assert.True(professor.Tutor);
        }

        [Fact(DisplayName = "Quando não houver formações deve retornar default/null")]
        public async Task Handle_SemFormacoes_DeveRetornarDefault()
        {
            // Arrange
            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemFormacoesPorAno(2024, null))
                .ReturnsAsync(Enumerable.Empty<FormacaoDTO>());

            var query = new ListagemDetalhamentoFormacaoQuery(2024, null);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(resultado);
        }
    }
}
