using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObtemUsuariosErrosPorTipoQuery : IRequest<IEnumerable<UsuarioErro>>
    {
        public UsuarioTipo UsuarioTipo { get; set; }

        public ObtemUsuariosErrosPorTipoQuery(UsuarioTipo usuarioTipo)
        {
            UsuarioTipo = usuarioTipo;
        }
    }
}