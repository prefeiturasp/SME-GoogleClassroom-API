using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaQueryHandler : IRequestHandler<ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery, IEnumerable<long>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunosCodigosInativosPorAnoLetivoETurmaQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<IEnumerable<long>> Handle(ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterAlunosCodigosInativosPorAnoLetivoETurma(request.AnoLetivo, request.TurmaId, request.DataInicio, request.DataFim, request.ParametrosCargaInicialDto);
        }
    }
}
