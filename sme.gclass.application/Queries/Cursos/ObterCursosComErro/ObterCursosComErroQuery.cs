using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComErroQuery : IRequest<IEnumerable<CursoErro>>
    {
    }
}
