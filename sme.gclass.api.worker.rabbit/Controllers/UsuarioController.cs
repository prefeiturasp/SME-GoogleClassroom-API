using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Worker.Rabbit.Filters;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Controllers
{
    /// <summary>
    /// Alunos
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
        /// **Importante:** Esta funcionalidade é destinada para uso pelas equipes de desnvolvimento e infraestrutura responsáveis pela manutenção da aplicação.
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
        /// Valida se os usuários adicionados na base existem no google classroom
        /// </summary>
        /// <response code="200">O início da validação ocorreu com sucesso</response>
        [HttpGet("valida")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidaUsuariosExistentes([FromServices] IIniciarValidarUsuariosExistentesUsuariosComparativosUseCase useCase)
        {
            var retorno = await useCase.Executar();
            return Ok(retorno);
        }
    }
}