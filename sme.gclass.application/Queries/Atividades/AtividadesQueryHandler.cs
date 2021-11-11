using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtividadesQueryHandler : IRequestHandler<AtividadesQuery, PaginacaoResultadoDto<AtividadeGsa>>
    {
        private readonly IRepositorioAtividade _repositorioAtividade;

        public AtividadesQueryHandler(IRepositorioAtividade repositorio)
        {
            _repositorioAtividade = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<AtividadeGsa>> Handle(AtividadesQuery request,
            CancellationToken cancellationToken)
            => await _repositorioAtividade.ObterAtividadesPorDataCurso(
                request.Paginacao,
                request.DataReferencia,
                request.CursoId);
    }
}