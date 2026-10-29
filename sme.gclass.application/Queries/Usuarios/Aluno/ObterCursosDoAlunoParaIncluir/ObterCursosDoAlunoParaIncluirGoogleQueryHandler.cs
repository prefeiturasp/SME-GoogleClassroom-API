using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces.Cache;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Aluno.ObterCursosDoAlunoParaIncluir
{
    public class ObterCursosDoAlunoParaIncluirGoogleQueryHandler
        : IRequestHandler<ObterCursosDoAlunoParaIncluirGoogleQuery, IEnumerable<AlunoCursoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;
        private readonly IRepositorioCache repositorioCache;

        public ObterCursosDoAlunoParaIncluirGoogleQueryHandler(
            IRepositorioAlunoEol repositorioAlunoEol,
            IRepositorioCache repositorioCache)
        {
            this.repositorioAlunoEol = repositorioAlunoEol
                ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));

            this.repositorioCache = repositorioCache
                ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<IEnumerable<AlunoCursoEol>> Handle(
            ObterCursosDoAlunoParaIncluirGoogleQuery request,
            CancellationToken cancellationToken)
        {
            var parametrosDaChave = JsonSerializer.Serialize(new
            {
                request.CodigoAluno,
                request.AnoLetivo,
                request.ParametrosCargaInicialDto
            });

            var chaveCache = $"alunos-cursos-novos:v1:{parametrosDaChave}";

            return await repositorioCache.ObterRedisAsync(
                chaveCache,
                () => repositorioAlunoEol.ObterCursosDoAlunoParaIncluirAsync(
                    request.CodigoAluno,
                    request.AnoLetivo,
                    request.ParametrosCargaInicialDto));
        }
    }
}