using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtividadesQueryHandler : IRequestHandler<AtividadesQuery, PaginacaoResultadoDto<AtividadeDto>>
    {
        private readonly IRepositorioAtividade _repositorioAtividade;

        public AtividadesQueryHandler(IRepositorioAtividade repositorio)
        {
            _repositorioAtividade = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<AtividadeDto>> Handle(AtividadesQuery request,
            CancellationToken cancellationToken)
        {
            var retorno = await _repositorioAtividade.ObterAtividadesPorDataCurso(
                request.Paginacao,
                request.DataReferencia,
                request.CursoId);

            return new PaginacaoResultadoDto<AtividadeDto>
            {
                TotalPaginas = retorno.TotalPaginas,
                TotalRegistros = retorno.TotalRegistros,
                Items = retorno.Items?.Select(item => new AtividadeDto(item))
            };
        }
    }
}