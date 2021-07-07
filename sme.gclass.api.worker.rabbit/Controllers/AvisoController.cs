using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/avisos")]
    public class AvisoController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AvisoGsa>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAvisos([FromServices] IObterAvisoUseCase obterAvisoUseCase,
            [FromQuery] FiltroObterAvisoDto filtro)
        {
            var retorno = await obterAvisoUseCase.Executar(filtro);
            return Ok(retorno);
        }
    }
}
