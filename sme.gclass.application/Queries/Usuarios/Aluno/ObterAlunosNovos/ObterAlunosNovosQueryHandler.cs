using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces.Cache;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosNovosQueryHandler
        : IRequestHandler<ObterAlunosNovosQuery, PaginacaoResultadoDto<AlunoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;
        private readonly IRepositorioCache repositorioCache;

        public ObterAlunosNovosQueryHandler(
            IRepositorioAlunoEol repositorioAlunoEol,
            IRepositorioCache repositorioCache)
        {
            this.repositorioAlunoEol = repositorioAlunoEol
                ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));

            this.repositorioCache = repositorioCache
                ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Handle(
            ObterAlunosNovosQuery request,
            CancellationToken cancellationToken)
        {
            var anoLetivo = request.DataReferencia?.Year ?? DateTime.Now.Year;

            var parametrosDaChave = JsonSerializer.Serialize(new
            {
                request.Paginacao,
                DataReferencia = request.DataReferencia?.ToString("yyyy-MM-dd"),
                request.CodigoEol,
                request.ParametrosCargaInicialDto
            });

            var chaveCache =
                $"alunos-novos:v1:ano={anoLetivo}:{parametrosDaChave}";

            return await repositorioCache.ObterRedisAsync(
                chaveCache,
                () => repositorioAlunoEol.ObterAlunosParaInclusaoAsync(
                    request.Paginacao,
                    anoLetivo,
                    request.DataReferencia,
                    request.CodigoEol,
                    request.ParametrosCargaInicialDto));
        }
    }
}