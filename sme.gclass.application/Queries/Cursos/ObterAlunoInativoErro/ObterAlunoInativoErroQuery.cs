using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunoInativoErroQuery : IRequest<IEnumerable<UsuarioInativoErro>>
    {
    }
}