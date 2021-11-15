using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterComponentesCurricularesIdAtividadePorAnoLetivoQueryHandler : IRequestHandler<ObterComponentesCurricularesIdAtividadePorAnoLetivoQuery, IEnumerable<long>>
    {
        private readonly IRepositorioAtividade repositorioAtividade;

        public ObterComponentesCurricularesIdAtividadePorAnoLetivoQueryHandler(IRepositorioAtividade repositorioAtividade)
        {
            this.repositorioAtividade = repositorioAtividade ?? throw new ArgumentNullException(nameof(repositorioAtividade));
        }
        public async Task<IEnumerable<long>> Handle(ObterComponentesCurricularesIdAtividadePorAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAtividade.ObterComponentesIdsAtividadesPorAnoLetivo(request.AnoLetivo);
        }
    }
}
