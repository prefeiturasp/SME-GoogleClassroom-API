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
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AtividadeDto>), 200)]
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
        /// Inicia a carga para sincronização manual de atividades do Google Classroom (GSA).
        /// </summary>
        /// <remarks>
        /// **Atenção:** Este endpoint apenas **inicia a carga** publicando a solicitação na fila assíncrona <c>googleclass.gsa.atividades.carregar</c>,
        /// não executando a sincronização integral de atividades dentro da requisição HTTP.
        ///
        /// Todos os parâmetros no corpo da requisição são opcionais:
        /// - **cursoId**: Identificador do curso no Google Classroom (opcional; se omitido, inicia para todos os cursos).
        /// - **pagina**: Página de paginação para início da busca (opcional).
        /// - **totalPaginas**: Total de páginas a processar (opcional).
        /// </remarks>
        /// <param name="useCase">Caso de uso responsável por publicar a carga na fila.</param>
        /// <param name="filtro">Contrato de entrada com parâmetros opcionais para início da carga de atividades.</param>
        /// <response code="200">A solicitação de carga para sincronização foi enfileirada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado ao enfileirar a solicitação.</response>
        [HttpPost("sincronizacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleAtividadesUseCase useCase, [FromBody] IniciarSyncGoogleAtividadesDto filtro)
        {
            await useCase.Executar(filtro);
            return Ok();
        }
    }
}