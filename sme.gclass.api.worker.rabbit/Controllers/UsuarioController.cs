using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao.Interfaces;
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
    }
}