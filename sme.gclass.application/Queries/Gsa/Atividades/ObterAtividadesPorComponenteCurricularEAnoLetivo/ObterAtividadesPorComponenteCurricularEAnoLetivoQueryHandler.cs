using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Gsa.Atividades.ObterAtividadesPorComponenteCurricularEAnoLetivo
{
    public class ObterAtividadesPorComponenteCurricularEAnoLetivoQueryHandler : IRequestHandler<ObterAtividadesPorComponenteCurricularEAnoLetivoQuery, PaginacaoResultadoDto<AtividadeGsa>>
    {
        private readonly IRepositorioAtividade repositorioAtividade;

        public ObterAtividadesPorComponenteCurricularEAnoLetivoQueryHandler(IRepositorioAtividade repositorioAtividade)
        {
            this.repositorioAtividade = repositorioAtividade ?? throw new System.ArgumentNullException(nameof(repositorioAtividade));
        }

        public async Task<PaginacaoResultadoDto<AtividadeGsa>> Handle(ObterAtividadesPorComponenteCurricularEAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAtividade.ObterAtividadesPorDataReferencia(request.Paginacao, request.ComponenteCurricularId, request.AnoLetivo);
        }
    }
}
