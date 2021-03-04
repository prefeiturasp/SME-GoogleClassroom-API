using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComErroComEmailQuery : IRequest<IEnumerable<CursoErro>>
    {
    }
}
