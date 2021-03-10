﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Professores
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
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
            [FromQuery] FiltroObterProfessoresIncluirGoogleDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
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
            [FromQuery] FiltroObterProfessoresCadastradosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
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

        /// <summary>
        /// Retorna os professores com os cursos já incluídos no Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("cursos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<ProfessorCursosCadastradosDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterProfessoresCursosGoogle([FromServices] IObterProfessoresCursosGoogleUseCase useCase,
            [FromQuery] FiltroObterProfessoresCursosCadastradosDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Envia uma requisição para atribuir um professor a um curso no Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a consistência das informações é importante garantir que o relacionamento entre professor e curso consta na base de dados do EOL.
        /// </remarks>
        /// <response code="200">Foi realizada a requisição para atribuíção do professor ao curso.</response>
        [HttpPost("cursos")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnviarRequisicaoAtribuirProfessorCurso([FromBody]AtribuirProfessorCursoDto atribuirProfessorCursoDto, [FromServices]IEnviarRequisicaoAtribuirProfessorCursoUseCase atribuirProfessorCursoUseCase)
        {
            var retorno = await atribuirProfessorCursoUseCase.Executar(atribuirProfessorCursoDto);
            return Ok(retorno);
        }

        [HttpGet("novas-atribuicoes")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<AtribuicaoProfessorCursoEolDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterAtribuicoesDeCursosDosProfessores([FromServices] IObterAtribuicoesDeCursosDosProfessoresUseCase useCase,
            [FromQuery] FiltroObterAtribuicoesDeCursosDosProfessoresDto filtro)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }
    }
}