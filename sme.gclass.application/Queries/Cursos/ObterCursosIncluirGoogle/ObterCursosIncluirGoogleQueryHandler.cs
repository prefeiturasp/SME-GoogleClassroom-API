using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dados.Interfaces.Cache;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosIncluirGoogleQueryHandler
        : IRequestHandler<ObterCursosIncluirGoogleQuery, PaginacaoResultadoDto<CursoEol>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;
        private readonly IRepositorioCache repositorioCache;

        public ObterCursosIncluirGoogleQueryHandler(
            IRepositorioCursoEol repositorioCursoEol,
            IRepositorioCache repositorioCache)
        {
            this.repositorioCursoEol = repositorioCursoEol
                ?? throw new ArgumentNullException(nameof(repositorioCursoEol));

            this.repositorioCache = repositorioCache
                ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<PaginacaoResultadoDto<CursoEol>> Handle(
            ObterCursosIncluirGoogleQuery request,
            CancellationToken cancellationToken)
        {
            var anoLetivo = request.UltimaExecucao?.Year ?? DateTime.Now.Year;
            var ultimaExecucao = request.UltimaExecucao
                ?? new DateTime(anoLetivo, 1, 1);

            var parametrosDaChave = JsonSerializer.Serialize(new
            {
                request.Paginacao,
                UltimaExecucao = ultimaExecucao.ToString("yyyy-MM-dd"),
                request.ComponenteCurricularId,
                request.TurmaId,
                request.ParametrosCargaInicialDto
            });

            var chaveCache =
                $"cursos-novos:v1:ano={anoLetivo}:{parametrosDaChave}";

            return await repositorioCache.ObterRedisAsync(
                chaveCache,
                () => repositorioCursoEol.ObterCursosParaInclusao(
                    request.ParametrosCargaInicialDto,
                    ultimaExecucao,
                    anoLetivo,
                    request.Paginacao,
                    request.ComponenteCurricularId,
                    request.TurmaId));
        }
    }
}