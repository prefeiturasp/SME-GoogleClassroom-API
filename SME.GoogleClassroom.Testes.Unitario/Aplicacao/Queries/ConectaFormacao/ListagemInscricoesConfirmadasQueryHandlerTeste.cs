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
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using SME.GoogleClassroom.Infra.Dtos.Gsa.FormacaoCidade;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.ConectaFormacao
{
    public class ListagemInscricoesConfirmadasQueryHandlerTeste
    {
        private readonly Mock<IRepositorioConectaFormacao> repositorioConectaFormacaoMock;
        private readonly Mock<IRepositorioDreEol> repositorioDreEolMock;
        private readonly Mock<IRepositorioEscolaEol> repositorioEscolaEolMock;
        private readonly Mock<IRepositorioUsuario> repositorioUsuarioMock;
        private readonly Mock<IRepositorioUnidade> repositorioUnidadeMock;
        private readonly Mock<IMediator> mediatorMock;
        private readonly ListagemInscricoesConfirmadasQueryHandler handler;

        public ListagemInscricoesConfirmadasQueryHandlerTeste()
        {
            repositorioConectaFormacaoMock = new Mock<IRepositorioConectaFormacao>();
            repositorioDreEolMock = new Mock<IRepositorioDreEol>();
            repositorioEscolaEolMock = new Mock<IRepositorioEscolaEol>();
            repositorioUsuarioMock = new Mock<IRepositorioUsuario>();
            repositorioUnidadeMock = new Mock<IRepositorioUnidade>();
            mediatorMock = new Mock<IMediator>();

            handler = new ListagemInscricoesConfirmadasQueryHandler(
                repositorioConectaFormacaoMock.Object,
                repositorioDreEolMock.Object,
                repositorioEscolaEolMock.Object,
                repositorioUsuarioMock.Object,
                repositorioUnidadeMock.Object,
                mediatorMock.Object);
        }

        [Fact(DisplayName = "Quando não houver inscrições na turma deve retornar default/null")]
        public async Task Handle_SemInscricoes_DeveRetornarDefault()
        {
            // Arrange
            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemInscricoesConfirmadas(99999))
                .ReturnsAsync(Enumerable.Empty<InscricaoConfirmadaDTO>());

            var query = new ListagemInscricoesConfirmadasQuery(99999);

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(resultado);
        }

        [Fact(DisplayName = "Quando UE e DRE forem unidades administrativas deve consultar unidades e preencher nomes corretamente")]
        public async Task Handle_UnidadesAdministrativas_DevePreencherUeNomeEDreNomeCorretamente()
        {
            // Arrange
            long codigoTurma = 1541;
            var inscricoes = new List<InscricaoConfirmadaDTO>
            {
                new InscricaoConfirmadaDTO
                {
                    CodigoRf = "7821263",
                    Cpf = "12345678900",
                    Nome = "SERVIDOR TESTE ",
                    Email = "teste@dominio.com ",
                    DreCodigo = "125121",
                    UeCodigo = "125032",
                    CodigoCargo = "41",
                    DescricaoCargo = "SERV. TEC. ADMINISTRATIVOS ",
                    TipoVinculo = 1
                }
            };

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemInscricoesConfirmadas(codigoTurma))
                .ReturnsAsync(inscricoes);

            repositorioDreEolMock
                .Setup(r => r.ObterDresPorCodigos(It.IsAny<string[]>()))
                .ReturnsAsync(Enumerable.Empty<DreDto>());

            repositorioEscolaEolMock
                .Setup(r => r.ObterUesPorCodigos(It.IsAny<string[]>()))
                .ReturnsAsync(Enumerable.Empty<EscolaResumidaDTO>());

            var unidades = new List<UnidadeDto>
            {
                new UnidadeDto { Codigo = "125121", Nome = "DIVISAO DE GESTAO DE CARREIRAS - COGEP-DICAR" },
                new UnidadeDto { Codigo = "125032", Nome = "DIVISAO DE GESTAO DE TEMPO DE SERVICO - COGEP-DITEM" }
            };

            repositorioUnidadeMock
                .Setup(r => r.ObterUnidadesPorCodigos(It.Is<string[]>(c => c.Contains("125121") && c.Contains("125032"))))
                .ReturnsAsync(unidades);

            var query = new ListagemInscricoesConfirmadasQuery(codigoTurma);

            // Act
            var resultado = (await handler.Handle(query, CancellationToken.None))?.ToList();

            // Assert
            Assert.NotNull(resultado);
            Assert.Single(resultado);

            var item = resultado[0];
            Assert.Equal("125032", item.UeCodigo);
            Assert.Equal("DIVISAO DE GESTAO DE TEMPO DE SERVICO - COGEP-DITEM", item.UeNome);
            Assert.Equal("125121", item.DreCodigo);
            Assert.Equal("DIVISAO DE GESTAO DE CARREIRAS - COGEP-DICAR", item.DreNome);
            Assert.Equal("teste@dominio.com", item.Email);
            Assert.Equal("SERVIDOR TESTE", item.Nome);
        }

        [Fact(DisplayName = "Quando UE for escola deve utilizar dados da escola resumida")]
        public async Task Handle_UeEscola_DeveUtilizarDadosEscolaResumida()
        {
            // Arrange
            long codigoTurma = 1000;
            var inscricoes = new List<InscricaoConfirmadaDTO>
            {
                new InscricaoConfirmadaDTO
                {
                    CodigoRf = "1111111",
                    Cpf = "99988877766",
                    Nome = "PROFESSOR ESCOLA",
                    Email = "prof@edu.sme.sp.gov.br",
                    DreCodigo = "108100",
                    UeCodigo = "019715",
                    CodigoCargo = "3360",
                    DescricaoCargo = "PROF. ENS. FUND. II E MEDIO",
                    TipoVinculo = 1
                }
            };

            repositorioConectaFormacaoMock
                .Setup(r => r.ListagemInscricoesConfirmadas(codigoTurma))
                .ReturnsAsync(inscricoes);

            var escolas = new List<EscolaResumidaDTO>
            {
                new EscolaResumidaDTO
                {
                    Codigo = "019715",
                    Nome = "ADALGIZA SEGURADO DA SILVEIRA, PROFA.",
                    DreCodigo = "108100",
                    DreSigla = "DRE - BT"
                }
            };

            repositorioEscolaEolMock
                .Setup(r => r.ObterUesPorCodigos(It.Is<string[]>(c => c.Contains("019715"))))
                .ReturnsAsync(escolas);

            repositorioDreEolMock
                .Setup(r => r.ObterDresPorCodigos(It.IsAny<string[]>()))
                .ReturnsAsync(Enumerable.Empty<DreDto>());

            repositorioUnidadeMock
                .Setup(r => r.ObterUnidadesPorCodigos(It.IsAny<string[]>()))
                .ReturnsAsync(Enumerable.Empty<UnidadeDto>());

            var query = new ListagemInscricoesConfirmadasQuery(codigoTurma);

            // Act
            var resultado = (await handler.Handle(query, CancellationToken.None))?.ToList();

            // Assert
            Assert.NotNull(resultado);
            Assert.Single(resultado);

            var item = resultado[0];
            Assert.Equal("019715", item.UeCodigo);
            Assert.Equal("ADALGIZA SEGURADO DA SILVEIRA, PROFA.", item.UeNome);
            Assert.Equal("108100", item.DreCodigo);
            Assert.Equal("DRE - BT", item.DreNome);
        }
    }
}
