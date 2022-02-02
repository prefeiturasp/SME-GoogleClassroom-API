using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorIdsParaIntegracaoQuery : IRequest<IEnumerable<CursoGoogleDtoParaIntegracao>>
    {
        public ObterCursosPorIdsParaIntegracaoQuery(IEnumerable<long> cursosId)
        {
            CursosId = cursosId;
        }

        public IEnumerable<long> CursosId { get; set; }
    }
}
