using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Frequencias
{
    public class LancarFrequenciaCommandHandlerTeste
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly LancarFrequenciaCommandHandler handler;

        public LancarFrequenciaCommandHandlerTeste()
        {
            mediatorMock = new Mock<IMediator>();
            handler = new LancarFrequenciaCommandHandler(mediatorMock.Object);
        }

        [Fact(DisplayName = "Quando DTO de frequência for nulo, deve lançar NegocioException")]
        public async Task Handle_FrequenciaSalvarAulaAlunosNulo_DeveLancarNegocioException()
        {
            var command = new LancarFrequenciaCommand(null);

            await Assert.ThrowsAsync<NegocioException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact(DisplayName = "Quando publicação no RabbitMQ falhar, deve lançar NegocioException")]
        public async Task Handle_FalhaAoPublicarRabbit_DeveLancarNegocioException()
        {
            var dto = new FrequenciaSalvarAulaAlunosDto
            {
                AulaId = 123,
                UsuarioLogado = "1234567",
                PerfilUsuario = Guid.NewGuid().ToString(),
                Alunos = new List<FrequenciaSalvarAlunoDto>
                {
                    new FrequenciaSalvarAlunoDto
                    {
                        CodigoAluno = "999",
                        Frequencias = new List<FrequenciaAulaDto>
                        {
                            new FrequenciaAulaDto
                            {
                                NumeroAula = 1,
                                TipoFrequencia = "C"
                            }
                        }
                    }
                }
            };
            var command = new LancarFrequenciaCommand(dto);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitSgpCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<NegocioException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact(DisplayName = "Quando publicação no RabbitMQ for realizada com sucesso, deve retornar true")]
        public async Task Handle_PublicacaoSucesso_DeveRetornarTrue()
        {
            var dto = new FrequenciaSalvarAulaAlunosDto
            {
                AulaId = 123,
                UsuarioLogado = "1234567",
                PerfilUsuario = Guid.NewGuid().ToString(),
                Alunos = new List<FrequenciaSalvarAlunoDto>
                {
                    new FrequenciaSalvarAlunoDto
                    {
                        CodigoAluno = "999",
                        Frequencias = new List<FrequenciaAulaDto>
                        {
                            new FrequenciaAulaDto
                            {
                                NumeroAula = 1,
                                TipoFrequencia = "C"
                            }
                        }
                    }
                }
            };
            var command = new LancarFrequenciaCommand(dto);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicaFilaRabbitSgpCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await handler.Handle(command, CancellationToken.None);

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.Is<PublicaFilaRabbitSgpCommand>(c =>
                c.NomeFila == RotasRabbitSgp.RotaFrequenciaLancamentoAulaSync &&
                c.UsuarioLogadoRF == dto.UsuarioLogado &&
                c.UsuarioLogadoPerfil == dto.PerfilUsuario), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
