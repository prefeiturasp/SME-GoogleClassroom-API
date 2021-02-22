using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    [ApiController]
    [Route("api/v1/usuarios")]
    public class UsuarioController : Controller
    {
        [HttpGet("{login}")]
        [ProducesResponseType(typeof(UsuarioDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> ObterDados(string login, [FromServices] IObterDadosUsuarioPorLoginUseCase useCase)
        {
            return Ok(await useCase.Executar(login));
        }
    }
}
