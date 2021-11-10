using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorClassroomIdsQuery : IRequest<IEnumerable<UsuarioGoogleDto>>
    {
        public ObterUsuariosPorClassroomIdsQuery(IEnumerable<string> googleClassroomId)
        {
            GoogleClassroomId = googleClassroomId;
        }

        public IEnumerable<string> GoogleClassroomId { get; }
    }
}
