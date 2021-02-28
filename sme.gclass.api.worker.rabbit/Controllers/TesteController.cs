using MediatR;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    [ApiController]
    [Route("api/v1/testes")]
    public class TesteController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> Testar([FromServices] IMediator mediator)
        {
            //var cursoParaIncluir = new CursoParaInclusaoDto()
            //{
            //    ComponenteCurricularId = 1,
            //    Email = "williansantos.amcom@edu.sme.prefeitura.sp.gov.br",
            //    Nome = "Teste",
            //    Secao = "P - XX - 000001 - 99999 - TESTE DE INTEGRAÇÃO",
            //    TurmaId = 12345,
            //    UeCodigo = "54321"
            //};

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoSync, RotasRabbit.FilaCursoSync, true));

            //await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.CursoAdicionar, DateTime.Now));

            return Ok();
        }
    }
}
