using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterComponentesCurricularesIdAtividadePorAnoLetivoQuery : IRequest<IEnumerable<long>>
    {
        public ObterComponentesCurricularesIdAtividadePorAnoLetivoQuery(int anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }

        public int AnoLetivo { get; set; }
    }
}
