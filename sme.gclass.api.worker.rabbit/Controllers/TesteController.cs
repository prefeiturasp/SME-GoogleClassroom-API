using MediatR;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
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
            await mediator.Send(new AtualizaExecucaoControleCommand(Dominio.Enumerados.ExecucaoTipo.CursoAdicionar, DateTime.Now));

            return Ok();
        }
    }
}
