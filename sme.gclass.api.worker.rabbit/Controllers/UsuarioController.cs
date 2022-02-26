using Microsoft.AspNetCore.Http;
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
    /// Usuários
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/usuarios")]
    public class UsuarioController : Controller
    {
        /// <summary>
        /// Inicia a atualização dos usuários sem o identificador do Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Esta funcionalidade é destinada para uso apenas pelas equipes de desenvolvimento e infraestrutura responsáveis pela manutenção da aplicação.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("atualizacoes/google-id")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> IniciarAtualizacaoUsuarioGoogleClassroomId(int registrosPorPagina, [FromServices] IIniciaAtualizacaoUsuarioGoogleClassroomIdUseCase iniciaAtualizacaoUsuarioGoogleClassroomIdUseCase)
        {
            var retorno = await iniciaAtualizacaoUsuarioGoogleClassroomIdUseCase.Executar(registrosPorPagina);
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os comparativos de usuários que foram criados pelo Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("comparativo")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<UsuarioGsa>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterComparativoDeUsuarios([FromQuery] FiltroObterUsuariosGsaDto filtro, [FromServices] IObterUsuariosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }


        /// <summary>
        /// Inicia o processo de carga de usuários pelo Google Classroom.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("carga")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ProcessarCargaComparativoUsuarios([FromServices] IIniciarCargaUsuariosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar();
            return Ok(retorno);
        }
        
        
        /// <summary>
        /// Inicia o tratamento de erros de usuarios do EOL para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErros([FromServices] IIniciarSyncGoogleUsuariosErrosUseCase useCase)
        {
            var retorno = await useCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de alunos/professores removidos do EOL para o Google Classroom.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("removidos/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErrosDeRemocaoUsuarios([FromServices] IIniciarSyncGoogleUsuariosRemovidosErrosUseCase usecase)
        {
            var retorno = await usecase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia o tratamento de erros de usuarios_gsa.
        /// </summary>
        /// <remarks>
        /// **Importante:** Visando a melhoria de performance, o tratamento de erros acontece de forma assíncrona e descentralizada,
        /// não sendo possível assim acompanhar em tempo real sua evolução.
        /// </remarks>
        /// <response code="200">O início da sincronização ocorreu com sucesso.</response>
        [HttpPost("gsa/erros/tratamentos")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ProcessarErrosDeProcessarUsuarioGsa([FromServices] IProcessarUsuarioGsaComErrosUseCase useCase)
        {
            await useCase.Executar();
            return Ok();
        }
    }
}