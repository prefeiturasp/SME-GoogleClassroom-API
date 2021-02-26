using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    [ApiController]
    [Route("api/v1/alunos")]
    public class AlunoController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<Usuario>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterTodosCursos([FromServices] IObterAlunosCadastradosUseCase obterAlunosCadastradosUseCase, [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero)
        {
            var retorno = await obterAlunosCadastradosUseCase.Executar(registrosQuantidade, paginaNumero);
            return Ok(retorno);
        }
    }
}
