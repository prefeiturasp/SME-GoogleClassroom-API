using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterAlunoCursoRemovidoErro
{
    public class ObterAlunoCursoRemovidoErroQuery : IRequest<IEnumerable<CursoUsuarioRemovidoGsaErro>>
    {
        
    }
}