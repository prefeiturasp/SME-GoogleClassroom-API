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
    /// Comparativo de dados
    /// </summary>
    [ApiController]
    [ChaveIntegracaoGoogleClassroomApi]
    [Route("api/v1/sincronizacoes/gsa")]
    public class SincronizacaoGsaController : Controller
    {
        /// <summary>
        /// Retorna os cursos GSA sincronizados.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("cursos")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<CursoGsaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterCursosGsa([FromQuery] FiltroObterCursosGsaDto filtro, [FromServices] IObterCursosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização de cursos GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("cursos")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarCargaCursosGsa([FromServices] IIniciarCargaCursosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a validação de cursos GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("cursos/validar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarValidacaoCursosGsa([FromServices] IIniciarValidacaoCursosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os usuários GSA sincronizados.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("usuarios")]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<CursoGsaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterUsuariosGsa([FromQuery] FiltroObterUsuariosGsaDto filtro, [FromServices] IObterUsuariosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar(filtro);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização de usuários GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("usuarios")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarCargaUsuariosGsa([FromServices] IIniciarCargaUsuariosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a validação de usuários GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("usuarios/validar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarValidacaoUsuariosGsa([FromServices] IIniciarValidacaoUsuariosGsaUseCase useCase)
        {
            var retorno = await useCase.Executar();
            return Ok(retorno);
        }

        /// <summary>
        /// Retorna os cursos do usuário GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpGet("usuarios/cursos")]
        [ProducesResponseType(typeof(ConsultaCursosDoUsuarioGsa), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterCursosDoUsuarioGsa(string usuarioId, [FromServices] IObterCursosDoUsuarioGsaUseCase useCase)
        {
            var retorno = await useCase.Executar(usuarioId);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização de remoção alunos inativos turma GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("cursos/usuarios/remover")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarProcessoInativacaoUsuariosCursosGsa([FromServices] IIniciarProcessoCursosUsuariosRemoverGsaUseCase useCase, bool processarAlunos = true, bool processarProfessores = true, bool processarFuncionario = true)
        {
            var retorno = await useCase.Executar(null, processarAlunos, processarProfessores, processarFuncionario);
            return Ok(retorno);
        }


        /// <summary>
        /// Inicia a sincronização para remoção professores sem atribuição - GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("cursos/professores/remover")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarProcessoRemoverProfessoresCursosGsa([FromServices] IIniciarProcessoCursosUsuariosRemoverGsaUseCase useCase, long? turmaId = null, bool processarAlunos = true, bool processarProfessores = true)
        {
            var retorno = await useCase.Executar(turmaId, processarAlunos, processarProfessores);
            return Ok(retorno);
        }


        /// <summary>
        /// Inicia a sincronização de Inativação alunos inativos turma GSA.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("cursos/usuarios-inativos")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarProcessoInativacaoUsuariosCursosGsa([FromServices] IIniciarProcessoInativacaoUsuariosGsaUseCase useCase, long? alunoId = null)
        {
            var retorno = await useCase.Executar(alunoId);
            return Ok(retorno);
        }

        /// <summary>
        /// Inicia a sincronização para inativar professores, funcionários e funcionários indiretos.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado durante a consulta.</response>
        /// <response code="601">Houve uma falha de validação durante a consulta.</response>
        [HttpPost("funcionarios-professores-inativos")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> IniciarProcessoInativacaoProfessoresFuncionarios([FromServices] IIniciarInativacaoProfessoresEFuncionariosUseCase useCase, string codigoRf, string cpf)
        {
            var retorno = await useCase.Executar(codigoRf, cpf);
            return Ok(retorno);
        }

    }
}