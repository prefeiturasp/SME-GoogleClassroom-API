using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
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
        [ProducesResponseType(typeof(PaginacaoResultadoDto<FuncionarioEol>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosParaIncluirGoogle([FromServices] IObterFuncionariosParaIncluirGoogleUseCase obterFuncionariosParaIncluirGoogleUseCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] DateTime ultimaExecucao, [FromQuery] string rf)
        {
            var retorno = await obterFuncionariosParaIncluirGoogleUseCase.Executar(registrosQuantidade, paginaNumero, ultimaExecucao, rf);
            return Ok(retorno);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<FuncionarioGoogle>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosGoogle([FromServices] IObterFuncionariosGoogleUseCase useCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] long? rf, [FromQuery] string email)
        {
            var retorno = await useCase.Executar(registrosQuantidade, paginaNumero, rf, email);
            return Ok(retorno);
        }

        [HttpPost("sincronizacao/iniciar")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleFuncionarioUseCase iniciarSyncGoogleFuncionarioUseCase)
        {
            var retorno = await iniciarSyncGoogleFuncionarioUseCase.Executar();
            return Ok(retorno);
        }
    }
}