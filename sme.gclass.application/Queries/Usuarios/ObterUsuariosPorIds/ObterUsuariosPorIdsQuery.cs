using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorIdsQuery : IRequest<IEnumerable<UsuarioGsaDto>>
    {
        public ObterUsuariosPorIdsQuery(long?[] ids)
        {
            Ids = ids;
        }

        public long?[] Ids { get; set; }
    }
}