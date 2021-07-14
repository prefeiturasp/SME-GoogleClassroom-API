using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosInativosPorAnoLetivoQueryHandler : IRequestHandler<ObterAlunosInativosPorAnoLetivoQuery, PaginacaoResultadoDto<long>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunosInativosPorAnoLetivoQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<PaginacaoResultadoDto<long>> Handle(ObterAlunosInativosPorAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterCodigosAlunosInativosPorAnoLetivo(request.Paginacao, request.AnoLetivo);
        }
    }
}
