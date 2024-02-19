using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Formações
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/formacao")]
    public class FormacaoController : Controller
    {
        /// <summary>
        /// Retorna as informações das inscrições dos cursistas por código da turma.
        /// </summary>
        /// <remarks>
        ///
        ///     GET
        ///     {
        ///        "codigoDaTurma": 123456
        ///     }
        ///
        /// </remarks>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("turma/{codigoDaTurma}/inscricoes")]
        [ProducesResponseType(typeof(IEnumerable<InscricaoRetornoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ListagemInscricoesConfirmadasPorTurma(
            [FromRoute] long codigoDaTurma,
            [FromServices] IListagemInscricoesConfirmadasUseCase listagemInscricoesConfirmadasUseCase)
        {
            return Ok(await listagemInscricoesConfirmadasUseCase.Executar(codigoDaTurma));
        }
        
        /// <summary>
        /// Retorna as informações das formações por ano.
        /// </summary>
        /// <remarks>
        ///
        ///     GET
        ///     {
        ///        "ano": 2023
        ///     }
        ///
        /// </remarks>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("detalhes/ano/{ano}")]
        [ProducesResponseType(typeof(IEnumerable<FormacaoDetalhaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ListagemDetalhamentoFormacaoPorAno(
            [FromRoute] int ano,
            [FromServices] IListagemDetalhamentoFormacaoUseCase listagemDetalhamentoFormacaoUseCase)
        {
            return Ok(await listagemDetalhamentoFormacaoUseCase.Executar(ano));
        }
    }
}
