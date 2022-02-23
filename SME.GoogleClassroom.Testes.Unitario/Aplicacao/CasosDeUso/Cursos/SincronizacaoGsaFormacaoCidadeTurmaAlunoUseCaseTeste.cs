using MediatR;
using Moq;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.CasosDeUso.Cursos
{
    public class SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCaseTeste : TesteIntegracaoGoogleClassroom
    {
        private readonly Mock<IMediator> mediator;
        private readonly ISincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase incluirCursoUseCase;

        public SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            //incluirCursoUseCase = new SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase(mediator.Object, GerarVariaveisGlobais());
        }

        //[Fact(DisplayName = "Valida o envio de JSON vazio para incluir um novo curso no Google Classroom.")]
        //private async Task Valida_Mensagem_Vazia_E_Deve_Disparar_NegocioException()
        //{
        //    // Arrange
        //    var mensagem = new MensagemRabbit(null);

        //    // Assert
        //    await Assert.ThrowsAsync<NegocioException>(() => incluirCursoUseCase.Executar(mensagem));
        //}

        //[Fact(DisplayName = "Valida o tratamento para cursos já inclusos.")]
        //private async Task Valida_Tratamento_De_Curso_Ja_Incluso_Deve_Retornar_True()
        //{
        //    // Arrange
        //    var curso = new CursoEol("Curso teste", "Secao", 10, 10, "01010", "teste@edu.sme.prefeitura.sp.gov.br");

        //    mediator.Setup(a => a.Send(It.IsAny<ExisteCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(true);

        //    var cursoJson = JsonConvert.SerializeObject(curso);
        //    var mensagem = new MensagemRabbit(cursoJson);

        //    // Act
        //    var retorno = await incluirCursoUseCase.Executar(mensagem);

        //    // Assert
        //    Assert.True(retorno);
        //}

        //[Fact(DisplayName = "Valida o tratamento de exceções em geral ao se comunicar com o Google Classroom.")]
        //private async Task Valida_Tratamento_De_Excecoes_Ao_Comunicar_Com_Google_Deve_Devolver_A_Excecao_Disparada()
        //{
        //    // Arrange
        //    var curso = new CursoEol("Curso teste", "Secao", 10, 10, "01010", "teste@edu.sme.prefeitura.sp.gov.br");

        //    mediator.Setup(a => a.Send(It.IsAny<ExisteCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(false);

        //    var excecao = new NullReferenceException("Erro ao se comunicar Google Classroom.");

        //    mediator.Setup(a => a.Send(It.IsAny<InserirCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
        //        .Throws(excecao);

        //    var cursoJson = JsonConvert.SerializeObject(curso);
        //    var mensagem = new MensagemRabbit(cursoJson);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(() => incluirCursoUseCase.Executar(mensagem));
        //}

        //[Fact(DisplayName = "Valida a inclusão de um curso válido.")]
        //private async Task Valida_Inclusao_De_Curso_Valido_Deve_Retornar_True()
        //{
        //    // Arrange
        //    var curso = new CursoEol("Curso teste", "Secao", 10, 10, "01010", "teste@edu.sme.prefeitura.sp.gov.br");

        //    mediator.Setup(a => a.Send(It.IsAny<ExisteCursoPorTurmaComponenteCurricularQuery>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(false);

        //    mediator.Setup(a => a.Send(It.IsAny<InserirCursoGoogleCommand>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(true);

        //    mediator.Setup(a => a.Send(It.IsAny<InserirCursoCommand>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(10);

        //    mediator.Setup(a => a.Send(It.IsAny<PublicaFilaRabbitCommand>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(true);

        //    var cursoJson = JsonConvert.SerializeObject(curso);
        //    var mensagem = new MensagemRabbit(cursoJson);

        //    // Act
        //    var retorno = await incluirCursoUseCase.Executar(mensagem);

        //    // Assert
        //    Assert.True(retorno);
        //}
    }
}