using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    [ApiController]
    [Route("api/v1/cursos")]
    public class CursoController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<Curso>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterTodosCursos([FromServices] IObterCursosCadastradosUseCase obterCursosCadastradosUseCase,
            [FromQuery] FiltroObterTodosCursosDto filtroObterTodosCursosDto)
        {
            var retorno = await obterCursosCadastradosUseCase.Executar(filtroObterTodosCursosDto);
            return Ok(retorno);
        }
        [HttpGet("novos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<Curso>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterTodosCursosParaIncluir([FromServices] IObterCursosParaIncluirGoogleUseCase obterCursosParaIncluirGoogleUseCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] DateTime ultimaExecucao)
        {
            var retorno = await obterCursosParaIncluirGoogleUseCase.Executar(registrosQuantidade, paginaNumero, ultimaExecucao);
            return Ok(retorno);
        }
    }
}
