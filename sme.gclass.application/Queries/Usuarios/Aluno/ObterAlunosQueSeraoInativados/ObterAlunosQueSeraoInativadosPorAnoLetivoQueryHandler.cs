using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosQueSeraoInativadosPorAnoLetivoQueryHandler : IRequestHandler<ObterAlunosQueSeraoInativadosPorAnoLetivoQuery, PaginacaoResultadoDto<AlunoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunosQueSeraoInativadosPorAnoLetivoQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Handle(ObterAlunosQueSeraoInativadosPorAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterAlunosQueSeraoInativosPorAnoLetivo(request.Paginacao, request.AnoLetivo);
        }
    }
}
