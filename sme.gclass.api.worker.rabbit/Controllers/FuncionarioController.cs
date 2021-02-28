using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    [ApiController]
    [Route("api/v1/funcionarios")]
    public class FuncionarioController : Controller
    {
        [HttpGet("novos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<FuncionarioParaIncluirGoogleDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterTodosCursosParaIncluir([FromServices] IObterFuncionariosParaIncluirGoogleUseCase obterFuncionariosParaIncluirGoogleUseCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] DateTime ultimaExecucao)
        {
            var retorno = await obterFuncionariosParaIncluirGoogleUseCase.Executar(registrosQuantidade, paginaNumero, ultimaExecucao);
            return Ok(retorno);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosGoogle([FromServices] IObterFuncionariosGoogleUseCase useCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero)
        {
            var retorno = await useCase.Executar(registrosQuantidade, paginaNumero);
            return Ok(retorno);
        }
    }
}