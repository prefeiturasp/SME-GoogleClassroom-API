﻿using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Alunos
    /// </summary>
    [ApiController]
    [Route("api/v1/alunos")]
    public class AlunoController : Controller
    {
        /// <summary>
        /// Retorna os alunos do EOL que serão incluídos no Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Para retornar todos os registros sem aplicar paginação informe o valor 0 (zero) nos campos *PaginaNumero* e *RegistrosQuantidade*:
        ///
        ///     GET
        ///     {
        ///        "CodigoEol": "0",
        ///        "DataReferencia": "2021-02-20",
        ///        "PaginaNumero" :" 0",
        ///        "RegistrosQuantidade" : "0"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("novos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AlunoEol>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAlunosCadastrar([FromServices] IObterAlunosParaCadastrarUseCase obterAlunosParaCadastrarUseCase, [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] DateTime dataReferencia, [FromQuery] long codigoEol)
        {
            var retorno = await obterAlunosParaCadastrarUseCase.Executar(registrosQuantidade, paginaNumero, dataReferencia, codigoEol);
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os alunos já incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AlunoGoogle>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterTodosAlunos([FromServices] IObterAlunosCadastradosUseCase obterAlunosCadastradosUseCase, [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] long? codigoEol, [FromQuery] string email)
        {
            var retorno = await obterAlunosCadastradosUseCase.Executar(registrosQuantidade, paginaNumero, codigoEol, email);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização de alunos do EOL para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, a sincronização dos cursos acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("sincronizacao/iniciar")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGooglAlunoUseCase iniciarSyncGoogleAlunoUseCase)
        {
            var retorno = await iniciarSyncGoogleAlunoUseCase.Executar();
            return Ok(retorno);
        }
    }
}