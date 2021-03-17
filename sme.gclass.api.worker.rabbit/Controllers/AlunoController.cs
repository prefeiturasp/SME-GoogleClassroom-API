using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Alunos
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
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
        public async Task<IActionResult> ObterAlunosCadastrar([FromServices] IObterAlunosParaCadastrarUseCase obterAlunosParaCadastrarUseCase,
            [FromQuery] FiltroObterAlunosIncluirGoogleDto filtro)
        {
            var retorno = await obterAlunosParaCadastrarUseCase.Executar(filtro);
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
        public async Task<IActionResult> ObterTodosAlunos([FromServices] IObterAlunosCadastradosUseCase obterAlunosCadastradosUseCase,
            [FromQuery] FiltroObterAlunosCadastradosDto filtro)
        {
            var retorno = await obterAlunosCadastradosUseCase.Executar(filtro);
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
        [HttpPost("sincronizacao")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGooglAlunoUseCase iniciarSyncGoogleAlunoUseCase)
        {
            var retorno = await iniciarSyncGoogleAlunoUseCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os cursos do aluno do EOL que serão incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("cursos/novos")]
        [ProducesResponseType(typeof(IEnumerable<AlunoCursoEol>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAlunosCursosGoogle([FromServices] IObterAlunosCursosParaCadastrarGoogleUseCase useCase,
            [FromQuery][Required] long codigoAluno)
        {
            var retorno = await useCase.Executar(codigoAluno);
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os alunos com os cursos já incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("cursos/cadastrados")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AlunoCursosCadastradosDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAlunosCursosGoogle([FromServices] IObterAlunosCursosGoogleUseCase useCase,
            [FromQuery] FiltroObterAlunosCursosCadastradosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Envia uma requisição para atribuir um aluno a um curso no Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a consistência das informações é importante garantir que o relacionamento entre aluno e curso consta na base de dados do EOL.
        /// </remarks>
        /// <response code="200">Foi realizada a requisição para atribuíção do aluno ao curso.</response>
        [HttpPost("cursos")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnviarRequisicaoAtribuirAlunoCurso([FromBody] AtribuirAlunoCursoDto atribuirAlunoCurso, [FromServices] IEnviarRequisicaoAtribuirAlunoCursoUseCase atribuirAlunoCursoUseCase)
        {
            var retorno = await atribuirAlunoCursoUseCase.Executar(atribuirAlunoCurso);
            return Ok(retorno);
        }
    }
}