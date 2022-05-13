using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirAtividadesPorIdsCommand : IRequest<bool>
    {
        public ExcluirAtividadesPorIdsCommand(IEnumerable<long> ids)
        {
            Ids = ids;
        }

        public IEnumerable<long> Ids { get; set; }
    }
}
