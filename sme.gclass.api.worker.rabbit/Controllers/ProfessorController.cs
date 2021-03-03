using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Professores
    /// </summary>
    [ApiController]
    [Route("api/v1/professores")]
    public class ProfessorController : Controller
    {
        /// <summary>
        /// Retorna os professores do EOL que serão incluídos no Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Para retornar todos os registros sem aplicar paginação informe o valor 0 (zero) nos campos *PaginaNumero* e *RegistrosQuantidade*:
        ///
        ///     GET
        ///     {
        ///        "UltimaExecucao": "2021-02-20",
        ///        "PaginaNumero" : "0",
        ///        "RegistrosQuantidade" : "0"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("novos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<ProfessorEol>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterProfessoresParaIncluirGoogle([FromServices] IObterProfessoresParaIncluirGoogleUseCase useCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] DateTime ultimaExecucao, [FromQuery] string rf)
        {
            var retorno = await useCase.Executar(registrosQuantidade, paginaNumero, ultimaExecucao, rf);
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os professores já incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<ProfessorGoogle>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterProfessoresGoogle([FromServices] IObterProfessoresGoogleUseCase useCase,
            [FromQuery] int registrosQuantidade, [FromQuery] int paginaNumero, [FromQuery] long? rf, [FromQuery] string email)
        {
            var retorno = await useCase.Executar(registrosQuantidade, paginaNumero, rf, email);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização de professores do EOL para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, a sincronização dos professores acontece de forma assíncrona e descentralizada, 
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("sincronizacao/iniciar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleProfessorUseCase iniciarSyncGoogleProfessorUseCase)
        {
            var retorno = await iniciarSyncGoogleProfessorUseCase.Executar();
            return Ok(retorno);
        }
    }
}
