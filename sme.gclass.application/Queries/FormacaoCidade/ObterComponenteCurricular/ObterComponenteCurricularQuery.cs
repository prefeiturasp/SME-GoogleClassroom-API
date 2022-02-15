using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterComponenteCurricularQuery : IRequest<IEnumerable<SalaComponenteModalidadeDto>>
    {
    }
}