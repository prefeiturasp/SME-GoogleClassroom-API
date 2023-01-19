using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Frequencias
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/frequencias")]
    public class FrequenciaController : Controller
    {
        /// <summary>
        /// Realiza o lançamento da frequência.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> LancamentoFrequencia([FromServices] ILancarFrequenciaUseCase lancarFrequenciaUseCase,[FromBody] IEnumerable<FrequenciaSalvarAulaAlunosDto> frequenciaSalvarAulaAlunosDtos)
        {
            return Ok(await lancarFrequenciaUseCase.Executar(frequenciaSalvarAulaAlunosDtos));
        }
    }
}