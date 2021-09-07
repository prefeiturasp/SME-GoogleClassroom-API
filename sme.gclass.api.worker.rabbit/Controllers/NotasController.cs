using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Atividades
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/notas")]
    public class NotasController : Controller
    {
        /// <summary>
        /// Executa manualmente a integração das notas do GSA.
        /// Insere o registro na base GCA e envia para o SGP para criar ou vincular a nota.
        /// </summary>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("sincronizacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSincronizacaoNotasUseCase useCase)
        {
            await useCase.Executar();

            return Ok();
        }
    }
}
