using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    [ApiController]
    [Route("api/v1/cursos")]
    public class CursoController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Curso>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> Testar([FromServices] IObterCursosCadastradosUseCase obterCursosCadastradosUseCase)
        {
            var retorno = await obterCursosCadastradosUseCase.Executar();
            return Ok(retorno);
        }
    }
}
