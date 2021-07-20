using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorIdETurmaIdQuery : IRequest<IEnumerable<CursoUsuarioInativarDto>>
    {
        public ObterUsuariosPorIdETurmaIdQuery(long usuarioId, long turmaId)
        {
            UsuarioId = usuarioId;
            TurmaId = turmaId;
        }

        public long UsuarioId { get; set; }
        public long TurmaId { get; set; }
    }
}
