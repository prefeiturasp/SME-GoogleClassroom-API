using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Avisos;
using SME.GoogleClassroom.Infra.Dtos.Aviso;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/avisos")]
    public class AvisoController : ControllerBase
    {
        [HttpGet]        
        public async Task<IActionResult> ObterAvisos([FromServices] IObterAvisoUseCase obterAvisoUseCase,
            [FromQuery] FiltroObterAvisoDto filtro)
        {
            var retorno = await obterAvisoUseCase.Executar(filtro);
            return Ok(retorno);
        }
    }
}
