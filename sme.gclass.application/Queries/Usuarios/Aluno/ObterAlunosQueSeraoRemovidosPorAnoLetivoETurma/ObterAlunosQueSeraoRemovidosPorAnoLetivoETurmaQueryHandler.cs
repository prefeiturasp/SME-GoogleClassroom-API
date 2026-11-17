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
    public class ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQueryHandler
        : IRequestHandler<
            ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQuery,
            PaginacaoResultadoDto<AlunoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;
        private readonly IRepositorioCache repositorioCache;

        public ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQueryHandler(
            IRepositorioAlunoEol repositorioAlunoEol,
            IRepositorioCache repositorioCache)
        {
            this.repositorioAlunoEol = repositorioAlunoEol
                ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));

            this.repositorioCache = repositorioCache
                ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Handle(
            ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQuery request,
            CancellationToken cancellationToken)
        {
            var parametrosDaChave = JsonSerializer.Serialize(new
            {
                request.ParametrosCargaInicialDto,
                request.Paginacao,
                request.AnoLetivo,
                request.TurmaId,
                request.DataReferencia,
                request.EhDataReferenciaPrincipal
            });

            var chaveCache =
                $"alunos-remocao:v1:{parametrosDaChave}";

            return await repositorioCache.ObterRedisAsync(
                chaveCache,
                () => repositorioAlunoEol
                    .ObterAlunosQueSeraoRemovidosPorAnoLetivoETurma(
                        request.ParametrosCargaInicialDto,
                        request.Paginacao,
                        request.AnoLetivo,
                        request.TurmaId,
                        request.DataReferencia,
                        request.EhDataReferenciaPrincipal));
        }
    }
}