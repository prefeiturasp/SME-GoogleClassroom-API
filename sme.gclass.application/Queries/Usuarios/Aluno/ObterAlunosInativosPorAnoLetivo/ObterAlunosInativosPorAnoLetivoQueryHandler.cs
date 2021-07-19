using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosInativosPorAnoLetivoQueryHandler : IRequestHandler<ObterAlunosInativosPorAnoLetivoQuery, IEnumerable<long>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunosInativosPorAnoLetivoQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<IEnumerable<long>> Handle(ObterAlunosInativosPorAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterCodigosAlunosInativosPorAnoLetivo(request.AnoLetivo, request.DataReferencia, request.AlunoId);
        }
    }
}
