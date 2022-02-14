using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Carga de criação de turmas - formação
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/sincronizacao/gsa/formacao/cidade")]
    public class SincronizacaoGsaFormacaoCidadeController : Controller
    {
        /// <summary>
        /// Inicia a sincronização para cadastrar turmas formaçaõ cidade.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("turmas")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarSincronizacaoGsaFormacaoCidadeTurmas([FromQuery] string codigoDre, [FromQuery] int? componenteCurricularId,
                                                                                     [FromServices] IIniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase useCase)
        {
            var retorno = await useCase.Executar(codigoDre, componenteCurricularId);
            return Ok(retorno);
        }
    }
}