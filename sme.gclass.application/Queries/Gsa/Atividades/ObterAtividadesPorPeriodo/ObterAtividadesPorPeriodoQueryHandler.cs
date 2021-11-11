using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesPorPeriodoQueryHandler : IRequestHandler<ObterAtividadesPorPeriodoQuery, (int? totalPaginas, IEnumerable<DadosAvaliacaoDto>)>
    {
        private readonly IRepositorioAtividade repositorioAtividade;

        public ObterAtividadesPorPeriodoQueryHandler(IRepositorioAtividade repositorioAtividade)
        {
            this.repositorioAtividade = repositorioAtividade ?? throw new System.ArgumentNullException(nameof(repositorioAtividade));
        }

        public async Task<(int? totalPaginas, IEnumerable<DadosAvaliacaoDto>)> Handle(ObterAtividadesPorPeriodoQuery request, CancellationToken cancellationToken)
            => await repositorioAtividade.ObterAtividadesPorPeriodo(request.DataInicio, request.DataFim, request.CursoId, request.Pagina, request.QuantidadeRegistrosPagina);
    }
}
