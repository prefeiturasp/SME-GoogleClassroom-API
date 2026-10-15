using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Atividades;
using SME.GoogleClassroom.Infra.Dtos.Gsa.Atividades;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

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
        /// Reprocessa os erros de importação de atividades GSA: lê a fila de erro e republica
        /// as mensagens na fila de processamento, onde o worker grava na base GCA e envia ao SGP.
        /// </summary>
        /// <response code="200">As mensagens de erro foram reenviadas para processamento.</response>
        /// <response code="500">Falha ao acessar o RabbitMQ.</response>
        [HttpPost("erros/tratamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessarErros([FromServices] IIncluirAtividadesGsaProcessarErroUseCase useCase)
        {
            await useCase.Executar();

            return Ok();
        }



        /// <summary>
        /// Inicia a carga de atividades do Google Sala de Aula (GSA).
        /// </summary>
        /// <remarks>
        /// Este endpoint apenas publica uma mensagem na fila do RabbitMQ
        /// <c>googleclass.gsa.atividades.carregar</c> (<c>RotasRabbit.FilaGsaAtividadesCarregar</c>)
        /// e retorna em seguida. Ele não aguarda o processamento.
        ///
        /// A busca das atividades no GSA, a gravação na base GCA e o envio ao SGP
        /// são feitos depois, em segundo plano, pelo worker que consome essa fila.
        ///
        /// Envie <c>{}</c> no corpo para carregar as atividades de todos os cursos.
        /// </remarks>
        /// <param name="dto">Filtros opcionais da carga: curso, página inicial e total de páginas.</param>
        /// <response code="200">Mensagem publicada na fila. A carga será processada em segundo plano.</response>
        /// <response code="400">Corpo da requisição ausente ou inválido.</response>
        /// <response code="500">Erro ao publicar a mensagem na fila.</response>
        [HttpPost("sincronizacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarSincronizacao([FromBody] IniciarSyncAtividadesDto dto, [FromServices] IIniciarSyncGoogleAtividadesUseCase useCase)
        {
            await useCase.Executar(dto.CursoId, dto.Pagina, dto.TotalPaginas);
            return Ok();
        }
    }
}