using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Aulas
    /// </summary>
    [ApiController]
    //[ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/aulas")]
    public class AulaController : Controller
    {
        /// <summary>
        /// Retorna as aulas conforme a data, turma e componente curricular.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="204">Aula não encontrada.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("turma/{turmaCodigo}/componente-curricular/{componenteCurricular}/data/{data}")]
        [ProducesResponseType(typeof(IEnumerable<AulaQuantidadeTipoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAulasPorTurmaComponenteData(string turmaCodigo, long componenteCurricular, DateTime data,[FromServices] IObterAulasPorTurmaComponenteCurricularDataUseCase obterAulasPorTurmaComponenteCurricularDataUseCase)
        {

            var retorno = await obterAulasPorTurmaComponenteCurricularDataUseCase.Executar(new FiltroAulasPorTurmaComponenteDataDto() { ComponenteCurricular = componenteCurricular, DataAula = data, TurmaCodigo = turmaCodigo });
            
            if (retorno.Any())
                return Ok(retorno);

            return StatusCode(204);
        }
    }
}