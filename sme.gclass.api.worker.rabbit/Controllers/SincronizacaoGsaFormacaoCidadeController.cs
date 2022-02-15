using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Carga de criação de turmas - formação
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/sincronizacao/gsa/formacao/cidade")]
    public class SincronizacaoGsaFormacaoCidadeController : Controller
    {
        /// <summary>
        /// Inicia a sincronização para cadastrar turmas formaçaõ cidade.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("turmas")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarSincronizacaoGsaFormacaoCidadeTurmas([FromQuery] string codigoDre, [FromQuery] int? componenteCurricularId,
                                                                                     [FromServices] IIniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase useCase)
        {
            var retorno = await useCase.Executar(codigoDre, componenteCurricularId);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de turmas/dre que insere turmas e atribui professores para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("turmas/dre/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasDre([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaDreErroUseCase usecase)
        {
            var retorno = await usecase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de turmas/componente que insere turmas e atribui professores para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("turmas/componente/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasComponente([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaComponenteErroUseCase usecase)
        {
            var retorno = await usecase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de turmas/curso que insere turmas e atribui professores para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("turmas/curso/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasCurso([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaCursoErroUseCase usecase)
        {
            var retorno = await usecase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de turmas/aluno que insere turmas e atribui professores para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("turmas/aluno/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasAluno([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaAlunoErroUseCase usecase)
        {
            var retorno = await usecase.Executar();
            return Ok(retorno);
        }
    }
}