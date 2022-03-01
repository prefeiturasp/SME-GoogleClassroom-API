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
        /// Inicia a sincronização para cadastrar turmas formação cidade.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("turmas")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarSincronizacaoGsaFormacaoCidadeTurmas([FromServices] IIniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase useCase, 
                                                                                     [FromQuery] string codigoDre, [FromQuery] int? componenteCurricularId = null, [FromQuery] int? anoLetivo = null)
        {
            var retorno = await useCase.Executar(codigoDre, componenteCurricularId, anoLetivo);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de turmas/sme/dre que insere turmas e atribui professores para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("turmas/sme/dre/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasSmeDre([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaSmeDreComErrosUseCase useCase)
        {
            await useCase.Executar();
            return Ok();
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
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasComponente([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaComponenteComErrosUseCase useCase)
        {
            await useCase.Executar();
            return Ok();
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
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasCurso([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaCursoComErrosUseCase useCase)
        {
            await useCase.Executar();
            return Ok();
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
        public async Task<IActionResult> ProcessarErrosDeSincronizacaoGsaFormacaoCidadeTurmasAluno([FromServices] ISincronizacaoGsaFormacaoCidadeTurmaAlunoComErrosUseCase useCase)
        {
            await useCase.Executar();
            return Ok();
        }

        /// <summary>
        /// Inicia a exclusão de turmas (cursos) no Google Classroom.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Exclusão realizada com sucesso.</response>
        [HttpPost("turmas/excluir")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ProcessarExclusaoCursosGoogle([FromQuery] string cursosIds, [FromServices] IIniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase useCase)
        {
            await useCase.Executar(cursosIds);
            return Ok();
        }
    }
}