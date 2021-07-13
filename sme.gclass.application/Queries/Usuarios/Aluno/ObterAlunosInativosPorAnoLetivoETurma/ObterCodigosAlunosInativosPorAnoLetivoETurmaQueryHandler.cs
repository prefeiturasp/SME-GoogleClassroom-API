using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterCodigosAlunosInativosPorAnoLetivoETurmaQueryHandler : IRequestHandler<ObterCodigosAlunosInativosPorAnoLetivoETurmaQuery, IEnumerable<long>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterCodigosAlunosInativosPorAnoLetivoETurmaQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<IEnumerable<long>> Handle(ObterCodigosAlunosInativosPorAnoLetivoETurmaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterCodigosAlunosInativosPorAnoLetivoETurma(request.AnoLetivo, request.TurmaId, request.DataReferencia);
        }
    }
}
