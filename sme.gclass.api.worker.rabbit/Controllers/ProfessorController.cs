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
    [Route("api/v1/professores")]
    public class ProfessorController : Controller
    {
        [HttpGet("novos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<ProfessorEol>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterProfessoresParaIncluirGoogle([FromServices] IObterProfessoresParaIncluirGoogleUseCase useCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] DateTime ultimaExecucao, [FromQuery] string rf)
        {
            var retorno = await useCase.Executar(registrosQuantidade, paginaNumero, ultimaExecucao, rf);
            return Ok(retorno);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<ProfessorGoogle>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterProfessoresGoogle([FromServices] IObterProfessoresGoogleUseCase useCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] long? rf, [FromQuery] string email)
        {
            var retorno = await useCase.Executar(registrosQuantidade, paginaNumero, rf, email);
            return Ok(retorno);
        }

        [HttpPost("sincronizacao/iniciar")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleProfessorUseCase iniciarSyncGoogleProfessorUseCase)
        {
            var retorno = await iniciarSyncGoogleProfessorUseCase.Executar();
            return Ok(retorno);
        }
    }
}
