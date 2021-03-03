using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
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
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AlunoGoogle>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterTodosAlunos([FromServices] IObterAlunosCadastradosUseCase obterAlunosCadastradosUseCase, [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] long? codigoEol, [FromQuery] string email)
        {
            var retorno = await obterAlunosCadastradosUseCase.Executar(registrosQuantidade, paginaNumero, codigoEol, email);
            return Ok(retorno);
        }

        [HttpGet("novos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AlunoEol>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAlunosCadastrar([FromServices] IObterAlunosParaCadastrarUseCase obterAlunosParaCadastrarUseCase, [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] DateTime dataReferencia, [FromQuery] long codigoEol)
        {
            var retorno = await obterAlunosParaCadastrarUseCase.Executar(registrosQuantidade, paginaNumero, dataReferencia, codigoEol);
            return Ok(retorno);
        }

        [HttpPost("sincronizacao/iniciar")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGooglAlunoUseCase iniciarSyncGoogleAlunoUseCase)
        {
            var retorno = await iniciarSyncGoogleAlunoUseCase.Executar();
            return Ok(retorno);
        }
    }
}
