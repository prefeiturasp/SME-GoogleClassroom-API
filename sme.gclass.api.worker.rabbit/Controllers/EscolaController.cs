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
using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries.SME.Pedagogico.Service.Queries;

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
        public async Task<IActionResult> ObterEscolas([FromServices] IObterEscolasUseCase obterEscolasUseCase)
        {
            var retorno = await obterEscolasUseCase.Executar();
            return Ok(retorno);
        }

    }
}