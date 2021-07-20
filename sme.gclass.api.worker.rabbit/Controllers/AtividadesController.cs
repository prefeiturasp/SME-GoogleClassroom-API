using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Atividades
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/atividades")]
    public class AtividadesController : Controller
    {
        /// <summary>
        /// Retorna as atividades que estão incluídas no Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Para retornar todos os registros sem aplicar paginação informe o valor 0 (zero) nos campos *PaginaNumero* e *RegistrosQuantidade*:
        ///
        ///     GET
        ///     {
        ///        "CursoId": "0",
        ///        "DataReferencia": "2021-02-20",
        ///        "PaginaNumero" :" 0",
        ///        "RegistrosQuantidade" : "0"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AtividadeGsa>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAtividades([FromServices] IObterAtividadesUseCase obterAtividadesUseCase,
            [FromQuery] FiltroAtividadesDto filtro)
        {
            var retorno = await obterAtividadesUseCase.Executar(filtro);
            return Ok(retorno);
        }
        
        /// <summary>
        /// Executa o tratamento dos erros de importação de atividades GSA.
        /// Insere o registro na base GCA e envia para o SGP a vincular com o curso.
        /// </summary>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("erros/tratamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessarErros([FromServices] IIncluirAtividadesGsaProcessarErroUseCase useCase)
        {
            await useCase.Executar();

            return Ok();
        }
        


        /// <summary>
        /// Executa manualmente a integração de atividades do GSA.
        /// Insere o registro na base GCA e envia para o SGP a vincular com a aula.
        /// </summary>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("sincronizacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleAtividadesUseCase useCase, long? cursoId = null)
        {
            await useCase.Executar(cursoId);

            return Ok();
        }
    }
}