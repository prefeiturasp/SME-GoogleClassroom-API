using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Alunos
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/escolas")]
    public class EscolaController : Controller
    {
        /// <summary>
        /// Retorna as escolas existentes.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<EscolaDTO>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        //[LimparLixo]
        public async Task<IActionResult> ObterEscolas(
                                            [FromServices] IObterEscolasUseCase obterEscolasUseCase,
                                            [FromQuery] FiltroObterEscolasDto filtro)
        {
            var retorno = await obterEscolasUseCase.Executar(filtro);

            if (retorno.Any())
                return Ok(retorno);

            return StatusCode(204);
        }
    }
}