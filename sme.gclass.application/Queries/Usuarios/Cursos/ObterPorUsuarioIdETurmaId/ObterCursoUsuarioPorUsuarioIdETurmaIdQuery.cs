using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoUsuarioPorUsuarioIdETurmaIdQuery : IRequest<IEnumerable<CursoUsuarioRemoverDto>>
    {
        public ObterCursoUsuarioPorUsuarioIdETurmaIdQuery(long usuarioId, long turmaId)
        {
            UsuarioId = usuarioId;
            TurmaId = turmaId;
        }

        public long UsuarioId { get; set; }
        public long TurmaId { get; set; }
    }
}
