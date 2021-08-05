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
    /// Funcionários
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/funcionarios")]
    public class FuncionarioController : Controller
    {
        /// <summary>
        /// Retorna os funcionários do EOL que serão incluídos no Google Classroom.
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
        [ProducesResponseType(typeof(PaginacaoResultadoDto<FuncionarioEol>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosParaIncluirGoogle([FromServices] IObterFuncionariosParaIncluirGoogleUseCase obterFuncionariosParaIncluirGoogleUseCase,
            [FromQuery] FiltroObterFuncionariosIncluirGoogleDto filtro)
        {
            var retorno = await obterFuncionariosParaIncluirGoogleUseCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os funcionários já incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<FuncionarioGoogle>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosGoogle([FromServices] IObterFuncionariosGoogleUseCase useCase,
            [FromQuery] FiltroObterFuncionariosCadastradosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização de funcionários do EOL para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, a sincronização dos funcionários acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("sincronizacao")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleFuncionarioUseCase iniciarSyncGoogleFuncionarioUseCase)
        {
            var retorno = await iniciarSyncGoogleFuncionarioUseCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização de um funcionário do EOL para o Google Classroom com base no RF.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, a sincronização dos funcionários acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("sincronizacao/individual")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleFuncionarioUseCase iniciarSyncGoogleFuncionarioUseCase,
            [FromQuery][Required] long rf)
        {
            var retorno = await iniciarSyncGoogleFuncionarioUseCase.Executar(rf);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de funcionários do EOL para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("erros/tratamento")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> IniciarSincronizacao([FromServices] IIniciarSyncGoogleFuncionarioErrosUseCase iniciarSyncGoogleFuncionarioErrosUseCase)
        {
            var retorno = await iniciarSyncGoogleFuncionarioErrosUseCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os cursos do funcionário do EOL que serão incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("cursos/novos")]
        [ProducesResponseType(typeof(IEnumerable<FuncionarioCursoEol>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAlunosCursosGoogle([FromServices] IObterFuncionariosCursosParaIncluirGoogleUseCase useCase,
            [FromQuery][Required] long rf)
        {
            var retorno = await useCase.Executar(rf);
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os funcionário com os cursos já incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("cursos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosCursosGoogle([FromServices] IObterFuncionariosCursosGoogleUseCase useCase,
            [FromQuery] FiltroObterFuncionariosCursosCadastradosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Envia uma requisição para atribuir um funcionário a um curso no Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a consistência das informações é importante garantir que o relacionamento entre funcionário e curso consta na base de dados do EOL.
        /// </remarks>
        /// <response code="200">Foi realizada a requisição para atribuíção do funcionário ao curso.</response>
        [HttpPost("cursos")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnviarRequisicaoAtribuirFuncionarioCurso([FromBody] AtribuirFuncionarioCursoDto atribuirFuncionarioCursoDto, [FromServices] IEnviarRequisicaoAtribuirFuncionarioCursoUseCase atribuirFuncionarioCursoUseCase)
        {
            var retorno = await atribuirFuncionarioCursoUseCase.Executar(atribuirFuncionarioCursoDto);
            return Ok(retorno);
        }

        /// <summary>
        /// Envia uma requisição para atribuir um funcionário sem rf a um curso no Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a consistência das informações é importante garantir que o relacionamento entre funcionário e curso consta na base de dados do EOL e o funcionário já estaja incluido do Google.
        /// </remarks>
        /// <response code="200">Foi realizada a requisição para atribuíção do funcionário ao curso.</response>
        [HttpPost("cursos/email")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnviarRequisicaoAtribuirFuncionarioCursoSemRf([FromBody] AtribuirFuncionarioSemRfCursoDto atribuirFuncionarioSemRfCurso, [FromServices] IEnviarRequisicaoAtribuirFuncionarioSemRfCursoUseCase atribuirFuncionarioSemRfCursoUseCase)
        {
            var retorno = await atribuirFuncionarioSemRfCursoUseCase.Executar(atribuirFuncionarioSemRfCurso);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de funcionarios que perderam atribuição em turmas Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("cursos/atribuicoes/remover/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErros([FromServices] IIniciarSyncGoogleFuncionariosRemovidosCursoComErrosUseCase useCase)
        {
            await useCase.Executar();
            return Ok();
        }

        /// Retorna os funcionarios que perderam a atribuição em turmas para remover o vinculo no GSA
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("cursos/atribuicoes/remover")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterTodosAlunosQueSeraoRemovidos([FromServices] IObterFuncionariosQueSeraoRemovidosUseCase useCase,
            [FromQuery] FiltroObterUsuariosQueSeraoRemovidosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os funcionários inativos
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("inativados")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<UsuarioInativo>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosInativos([FromServices] IObterFuncionariosInativosUseCase useCase, [FromQuery] FiltroObterFuncionariosInativosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de funcionarios que foram inativados.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("inativados/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErros([FromServices] IIniciarSyncProfessoresInativadosComErrosUseCase useCase)
        {
            await useCase.Executar();
            return Ok();
        }        

        /// <summary>
        /// Retorna os funcionários e professores que serão inativados no GSA - EOL
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("funcionarios-inativos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<FuncionarioEol>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterFuncionariosQueSeraoInativados([FromServices] IObterFuncionariosQueSeraoInativadosUseCase useCase,
            [FromQuery] FiltroObterFuncionariosQueSeraoInativadosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }
    }
}