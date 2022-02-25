using Dapper;
using SME.GoogleClassroom.Dados.Help;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioDreEol : RepositorioEol, IRepositorioDreEol
    {
        public RepositorioDreEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {}

        public async Task<IEnumerable<DreDto>> ObterDres(string codigoDre)
        {
			using var conn = ObterConexao();

			var query = $@" SELECT v_cadastro_unidade_educacao.cd_unidade_educacao Codigo, 
								v_cadastro_unidade_educacao.nm_unidade_educacao Nome,
								v_cadastro_unidade_educacao.nm_exibicao_unidade Sigla
						FROM v_cadastro_unidade_educacao (NOLOCK)
						JOIN unidade_administrativa (NOLOCK) ON v_cadastro_unidade_educacao.cd_unidade_educacao = unidade_administrativa.cd_unidade_administrativa
						WHERE tp_unidade_administrativa = 24 {IncluirCodigoDre(codigoDre)}
						ORDER BY nm_unidade_educacao";

			return await conn.QueryAsync<DreDto>(query, new { codigoDre }, commandTimeout: 180);
        }

        private string IncluirCodigoDre(string codigoDre)
        {
			return !string.IsNullOrEmpty(codigoDre) ? " and v_cadastro_unidade_educacao.cd_unidade_educacao = @codigoDre " : string.Empty;
        }

        public async Task<IEnumerable<long>> ObterAlunosCodigosInativosPorAnoLetivoETurma(int anoLetivo, long turmaId, DateTime dataInicio, DateTime dataFim, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var query = @"
				SELECT
					DISTINCT
					a.cd_aluno AS CodigoAluno
				FROM
					v_aluno_cotic aluno (NOLOCK)
				INNER JOIN 
					aluno a
					ON aluno.cd_aluno = a.cd_aluno
				INNER JOIN
					v_matricula_cotic matr (NOLOCK) 
					ON aluno.cd_aluno = matr.cd_aluno
				INNER JOIN 
					matricula_turma_escola mte (NOLOCK) 
					ON matr.cd_matricula = mte.cd_matricula
				INNER JOIN
					turma_escola te (NOLOCK)
					ON mte.cd_turma_escola = te.cd_turma_escola
				INNER JOIN
					escola esc (NOLOCK)
					ON te.cd_escola = esc.cd_escola
				WHERE
					mte.cd_situacao_aluno IN (2,3,4,7,8,11,12,14,15)
					AND matr.an_letivo = @anoLetivo
					AND te.an_letivo = @anoLetivo
					AND te.cd_turma_escola = @turmaId 
					AND mte.dt_situacao_aluno between @dataInicio and @dataFim 
					AND mte.dt_situacao_aluno = (select max(mte2.dt_situacao_aluno) from v_matricula_cotic matr2(NOLOCK)
													 inner join matricula_turma_escola mte2 (NOLOCK) on mte2.cd_matricula = matr2.cd_matricula
													 where matr2.cd_aluno = a.cd_aluno
													   and matr2.an_letivo = te.an_letivo
													   and mte2.cd_turma_escola = te.cd_turma_escola)";

			var sql = new StringBuilder(query);

			sql.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			sql.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			sql.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
			sql.Append(";");

			using var conn = ObterConexao();
            return await conn.QueryAsync<long>(sql.ToString(), new { 
				turmaId, 
				anoLetivo, 
				dataInicio, 
				dataFim,
				TiposUes = parametrosCargaInicialDto.TiposUes,
				parametrosCargaInicialDto.Ues,
				parametrosCargaInicialDto.Turmas,
			});
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosQueSeraoRemovidosPorAnoLetivoETurma(ParametrosCargaInicialDto parametrosCargaInicialDto, Paginacao paginacao, int anoLetivo, long turmaId, DateTime dataReferencia, bool ehDataReferenciaPrincipal)
        {
            using var conn = ObterConexao();

            var querySelectDados = @"
					SELECT
					DISTINCT a.cd_aluno AS Codigo,
					a.nm_aluno AS NomePessoa,
					a.nm_social_aluno AS NomeSocial,
					a.dt_nascimento_aluno AS DataNascimento,
				    te.cd_turma_escola AS TurmaId,
					mte.cd_situacao_aluno as SituacaoMatricula,
					mte.dt_situacao_aluno as DataSituacao ";

            var querySelectCount = "SELECT COUNT(DISTINCT a.cd_aluno) ";

            var queryFrom = new StringBuilder(@"
				FROM
					v_aluno_cotic aluno (NOLOCK)
				INNER JOIN 
					aluno a
					ON aluno.cd_aluno = a.cd_aluno
				INNER JOIN
					v_matricula_cotic matr (NOLOCK) 
					ON aluno.cd_aluno = matr.cd_aluno
				INNER JOIN 
					matricula_turma_escola mte (NOLOCK) 
					ON matr.cd_matricula = mte.cd_matricula
				INNER JOIN
					turma_escola te (NOLOCK)
					ON mte.cd_turma_escola = te.cd_turma_escola
				INNER JOIN
					escola esc (NOLOCK)
					ON te.cd_escola = esc.cd_escola
				WHERE
					mte.cd_situacao_aluno IN (2,3,4,7,8,11,12,14,15)
					AND matr.an_letivo = @anoLetivo
					AND te.an_letivo = @anoLetivo ");

            if (turmaId > 0)
                queryFrom.AppendLine("AND te.cd_turma_escola = @turmaId ");

            if (ehDataReferenciaPrincipal)
                queryFrom.AppendLine("AND mte.dt_situacao_aluno = @dataReferencia ");
            else
                queryFrom.AppendLine("AND mte.dt_situacao_aluno <= @dataReferencia ");

            queryFrom.AppendLine(@"and mte.dt_situacao_aluno = (select max(mte2.dt_situacao_aluno) from v_matricula_cotic matr2(NOLOCK)
													 inner join matricula_turma_escola mte2 (NOLOCK) on mte2.cd_matricula = matr2.cd_matricula
													 where matr2.cd_aluno = a.cd_aluno
													   and matr2.an_letivo = te.an_letivo
													   and mte2.cd_turma_escola = te.cd_turma_escola) ");

			queryFrom.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			queryFrom.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			queryFrom.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

			var queryPaginacao = @"order by mte.dt_situacao_aluno desc
								   offset @quantidadeRegistrosIgnorados rows fetch next @quantidadeRegistros rows only;";

            var query = new StringBuilder(querySelectDados);
            query.Append(queryFrom);
            query.Append(queryPaginacao);
            query.Append(querySelectCount);
            query.Append(queryFrom);

            using var multi = await conn.QueryMultipleAsync(query.ToString(),
                new
                {
                    quantidadeRegistros = paginacao.QuantidadeRegistros,
                    quantidadeRegistrosIgnorados = paginacao.QuantidadeRegistrosIgnorados,
                    anoLetivo,
                    dataReferencia,
                    turmaId
                }, commandTimeout: 6000);

            var retorno = new PaginacaoResultadoDto<AlunoEol>
            {
                Items = multi.Read<AlunoEol>(),
                TotalRegistros = multi.ReadFirst<int>()
            };

            retorno.TotalPaginas = paginacao.QuantidadeRegistros > 0 ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;
            return retorno;
        }

        private static string MontaQueryAlunosParaInclusao(Paginacao paginacao, DateTime? dataReferecia, long? codigoEol, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var queryBuscaMatriculasRegular = QueryBuscaMatriculaRegular(dataReferecia, codigoEol, parametrosCargaInicialDto);

            var queryBuscaRecenteAnoAluno = QueryBuscaRecenteAnoAluno(parametrosCargaInicialDto);

            var queryBuscaMatriculas = QueryBuscaMatriculasPrograma(dataReferecia, codigoEol, parametrosCargaInicialDto);

            var queryAgrupaBuscaRecenteAnoAluno = QueryAgrupaBuscaRecenteAnoAluno(parametrosCargaInicialDto);

            var queryUniaoTopMatricula = QueryUniaoTopMatricula(paginacao);

            return $@"
					{queryBuscaMatriculasRegular}
					{queryBuscaRecenteAnoAluno}
					{queryBuscaMatriculas}
					{queryAgrupaBuscaRecenteAnoAluno}
					{queryUniaoTopMatricula}
				";
        }

        private static string QueryUniaoTopMatricula(Paginacao paginacao)
        {
            return $@"
					-- 3. União dos dois tipos de matrículas
					IF OBJECT_ID('tempdb..#tempAlunosMatriculasAtivasFinal') IS NOT NULL
						DROP TABLE #tempAlunosMatriculasAtivasFinal;
					SELECT
						DISTINCT
						 cd_aluno_classroom,
						 cd_aluno_eol,
						 in_ativo,
						 nm_organizacao,
						 email_alterado,
						 AlunoRegular,
						 AlunoPrograma
					INTO #tempAlunosMatriculasAtivasFinal
					FROM
						(SELECT DISTINCT
						 cd_aluno_classroom,
						 cd_aluno_eol,
						 in_ativo,
						 nm_organizacao,
						 email_alterado,
						 AlunoRegular,
						 AlunoPrograma FROM #tempAlunosAtivos) AS Regulares
					UNION
						(SELECT DISTINCT
						 cd_aluno_classroom,
						 cd_aluno_eol,
						 in_ativo,
						 nm_organizacao,
						 email_alterado,
						 AlunoRegular,
						 AlunoPrograma
						FROM #tempAlunosProgramaAtivos WHERE NOT cd_aluno_eol IN (SELECT DISTINCT cd_aluno_eol FROM #tempAlunosAtivos));

					SELECT
						cd_aluno_eol Codigo,
						aluno.nm_aluno NomePessoa,
						aluno.nm_social_aluno NomeSocial,
						nm_organizacao OrganizationPath,
						aluno.dt_nascimento_aluno DataNascimento
					FROM
						#tempAlunosMatriculasAtivasFinal temp
					INNER JOIN
						v_aluno_cotic aluno (NOLOCK)
						ON temp.cd_aluno_eol = aluno.cd_aluno
					ORDER BY
						cd_aluno_eol
					{(paginacao?.QuantidadeRegistros > 0 ? @"OFFSET @quantidadeRegistrosIgnorados ROWS
					FETCH NEXT @quantidadeRegistros ROWS ONLY;" : ";")}

					-- Totalizacao
					SELECT
						COUNT(*)
					FROM
						#tempAlunosMatriculasAtivasFinal temp;";
        }

        private static StringBuilder QueryAgrupaBuscaRecenteAnoAluno(ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            string query = $@" 
					--- 2.1 Agrupa para buscar a mais recente em caso de mais de uma no ano por aluno
					IF OBJECT_ID('tempdb..#tempAlunosMatriculasProgramaAtivasDatasMaisRecentes') IS NOT NULL
						DROP TABLE #tempAlunosMatriculasProgramaAtivasDatasMaisRecentes;
					SELECT
						cd_aluno,
						MAX(dt_status_matricula) AS dt_status_matricula
					INTO #tempAlunosMatriculasProgramaAtivasDatasMaisRecentes
					FROM #tempAlunosMatriculasProgramaAtivas
					GROUP BY cd_aluno;

					--- 2.2 Mantém apenas a matrícula mais recente de cada aluno
					IF OBJECT_ID('tempdb..#tempAlunosMatriculasProgramaAtivasRemovendoDuplicadas') IS NOT NULL
						DROP TABLE #tempAlunosMatriculasProgramaAtivasRemovendoDuplicadas;
					SELECT
						t1.*
					INTO #tempAlunosMatriculasProgramaAtivasRemovendoDuplicadas
					FROM
						#tempAlunosMatriculasProgramaAtivas t1
					INNER JOIN
						#tempAlunosMatriculasProgramaAtivasDatasMaisRecentes t2
						ON t1.cd_aluno = t2.cd_aluno AND t1.dt_status_matricula = t2.dt_status_matricula;

					--- 2.3 Montagem da tabela de inserção
					IF OBJECT_ID('tempdb..#tempAlunosProgramaAtivos') IS NOT NULL
						DROP TABLE #tempAlunosProgramaAtivos;
					SELECT
						DISTINCT
						NULL AS cd_aluno_classroom,
						aluno.cd_aluno AS cd_aluno_eol,
						'True' AS in_ativo,
						CASE WHEN esc.tp_escola = 23 THEN '/Alunos/PROFISSIONAL' ELSE '/Alunos/PROGRAMA' END AS nm_organizacao,
						0 AS email_alterado,
						0 AS AlunoRegular,
						1 AS AlunoPrograma
					INTO #tempAlunosProgramaAtivos
					FROM
						#tempAlunosMatriculasProgramaAtivasRemovendoDuplicadas temp
					INNER JOIN
						v_aluno_cotic aluno (NOLOCK)
						ON aluno.cd_aluno = temp.cd_aluno
					INNER JOIN
						v_matricula_cotic matr (NOLOCK)
						ON aluno.cd_aluno = matr.cd_aluno AND matr.cd_matricula = temp.cd_matricula
					INNER JOIN
						matricula_turma_escola mte (NOLOCK)
						ON matr.cd_matricula = mte.cd_matricula
					INNER JOIN
						turma_escola te (NOLOCK)
						ON mte.cd_turma_escola = te.cd_turma_escola
					INNER JOIN
						escola esc (NOLOCK)
						ON te.cd_escola = esc.cd_escola
					WHERE
						matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
						and mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
						and matr.an_letivo = @anoLetivo";

            var queryBuilder = new StringBuilder(query);

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuilder.Append(";");

			return queryBuilder;
        }

        private static StringBuilder QueryBuscaMatriculasPrograma(DateTime? dataReferecia, long? codigoEol, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            string query = $@"
					-- 2. Busca matrículas de programa
					IF OBJECT_ID('tempdb..#tempAlunosMatriculasProgramaAtivas') IS NOT NULL
						DROP TABLE #tempAlunosMatriculasProgramaAtivas;
					SELECT
						aluno.cd_aluno,
						matr.cd_matricula,
						matr.dt_status_matricula
					INTO #tempAlunosMatriculasProgramaAtivas
					FROM
						v_aluno_cotic aluno (NOLOCK)
					INNER JOIN
						aluno a
						ON aluno.cd_aluno = a.cd_aluno
					INNER JOIN
						v_matricula_cotic matr (NOLOCK)
						ON aluno.cd_aluno = matr.cd_aluno
					INNER JOIN
						matricula_turma_escola mte (NOLOCK)
						ON matr.cd_matricula = mte.cd_matricula
					INNER JOIN
						turma_escola te (NOLOCK)
						ON mte.cd_turma_escola = te.cd_turma_escola
					INNER JOIN
						escola esc (NOLOCK)
						ON te.cd_escola = esc.cd_escola
					WHERE
						matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
						AND mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
						AND matr.an_letivo = @anoLetivo
						{(dataReferecia.HasValue ? "AND matr.dt_status_matricula >= @dataReferencia " : "")}
						AND te.st_turma_escola in ('O', 'A', 'C')
						AND te.an_letivo = @anoLetivo
						AND NOT matr.cd_tipo_programa IS NULL

						{(codigoEol.HasValue ? @"AND aluno.cd_aluno = @codigoEol " : " ")} ";

            var queryBuilder = new StringBuilder(query);

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuilder.Append(";");

			return queryBuilder; 
		}

        private static StringBuilder QueryBuscaRecenteAnoAluno(ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var query = $@"-- - 1.1 Agrupa para buscar a mais recente em caso de mais de uma no ano por aluno
					IF OBJECT_ID('tempdb..#tempAlunosMatriculasAtivasDatasMaisRecentes') IS NOT NULL
						DROP TABLE #tempAlunosMatriculasAtivasDatasMaisRecentes;
					SELECT
						cd_aluno,
						MAX(dt_status_matricula) AS dt_status_matricula
					INTO #tempAlunosMatriculasAtivasDatasMaisRecentes
					FROM #tempAlunosMatriculasAtivas
					GROUP BY cd_aluno;

					--- 1.2 Mantém apenas a matrícula mais recente de cada aluno
					IF OBJECT_ID('tempdb..#tempAlunosMatriculasAtivasRemovendoDuplicadas') IS NOT NULL
						DROP TABLE #tempAlunosMatriculasAtivasRemovendoDuplicadas;
					SELECT
						DISTINCT
						t1.*
					INTO #tempAlunosMatriculasAtivasRemovendoDuplicadas
					FROM
						#tempAlunosMatriculasAtivas t1
					INNER JOIN
						#tempAlunosMatriculasAtivasDatasMaisRecentes t2
						ON t1.cd_aluno = t2.cd_aluno AND t1.dt_status_matricula = t2.dt_status_matricula;

					--- 1.3 Montagem da tabela de inserção
					IF OBJECT_ID('tempdb..#tempAlunosAtivos') IS NOT NULL
						DROP TABLE #tempAlunosAtivos;
					SELECT
						DISTINCT
						NULL AS cd_aluno_classroom,
						aluno.cd_aluno AS cd_aluno_eol,
						'True' AS in_ativo,
						[dbo].[proc_gerar_unidade_organizacional_aluno](se.cd_modalidade_ensino, se.cd_etapa_ensino, ce.cd_ciclo_ensino,esc.tp_escola) AS nm_organizacao,
						0 AS email_alterado,
						1 AS AlunoRegular,
						0 AS AlunoPrograma
					INTO #tempAlunosAtivos
					FROM
						#tempAlunosMatriculasAtivasRemovendoDuplicadas temp
					INNER JOIN
						v_aluno_cotic aluno (NOLOCK)
						ON aluno.cd_aluno = temp.cd_aluno
					INNER JOIN
						v_matricula_cotic matr (NOLOCK)
						ON aluno.cd_aluno = matr.cd_aluno AND matr.cd_matricula = temp.cd_matricula
					INNER JOIN
						matricula_turma_escola mte (NOLOCK)
						ON matr.cd_matricula = mte.cd_matricula
					INNER JOIN
						turma_escola te (NOLOCK)
						ON mte.cd_turma_escola = te.cd_turma_escola
					INNER JOIN
						escola esc (NOLOCK)
						ON te.cd_escola = esc.cd_escola
					INNER JOIN
						serie_turma_grade stg (NOLOCK)
						ON stg.cd_turma_escola = te.cd_turma_escola
					INNER JOIN
						serie_ensino se (NOLOCK)
						ON se.cd_serie_ensino = stg.cd_serie_ensino
					INNER JOIN
						etapa_ensino ee (NOLOCK)
						ON se.cd_etapa_ensino = ee.cd_etapa_ensino and ee.cd_modalidade_ensino = se.cd_modalidade_ensino
					INNER JOIN
						ciclo_ensino ce (NOLOCK)
						on ce.cd_etapa_ensino = ee.cd_etapa_ensino and ce.cd_modalidade_ensino = ee.cd_modalidade_ensino and ce.cd_ciclo_ensino = se.cd_ciclo_ensino
					WHERE
						matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
						and mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
						and matr.an_letivo = @anoLetivo";

            var queryBuilder = new StringBuilder(query);

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuilder.Append(";");

			return queryBuilder;
		}
        
		private static StringBuilder QueryBuscaMatriculaRegular(DateTime? dataReferecia, long? codigoEol, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            string query =
                $@"DECLARE @situacaoAtivo AS CHAR = 1;
					DECLARE @situacaoPendenteRematricula AS CHAR = 6;
					DECLARE @situacaoRematriculado AS CHAR = 10;
					DECLARE @situacaoSemContinuidade AS CHAR = 13;

					DECLARE @situacaoAtivoInt AS INT = 1;
					DECLARE @situacaoPendenteRematriculaInt AS INT = 6;
					DECLARE @situacaoRematriculadoInt AS INT = 10;
					DECLARE @situacaoSemContinuidadeInt AS INT = 13;

					-- 1. Busca matrículas regulares
					IF OBJECT_ID('tempdb..#tempAlunosMatriculasAtivas') IS NOT NULL
						DROP TABLE #tempAlunosMatriculasAtivas;
					SELECT
						aluno.cd_aluno,
						matr.cd_matricula,
						matr.dt_status_matricula
					INTO #tempAlunosMatriculasAtivas
					FROM
						v_aluno_cotic aluno (NOLOCK)
					INNER JOIN
						aluno a
						ON aluno.cd_aluno = a.cd_aluno
					INNER JOIN
						v_matricula_cotic matr (NOLOCK)
						ON aluno.cd_aluno = matr.cd_aluno
					INNER JOIN
						matricula_turma_escola mte (NOLOCK)
						ON matr.cd_matricula = mte.cd_matricula
					INNER JOIN
						turma_escola te (NOLOCK)
						ON mte.cd_turma_escola = te.cd_turma_escola
					INNER JOIN
						escola esc (NOLOCK)
						ON te.cd_escola = esc.cd_escola
					WHERE
						matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
						AND mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
						AND matr.an_letivo = @anoLetivo
						{(dataReferecia.HasValue ? "AND matr.dt_status_matricula >= @dataReferencia " : "")}
						AND te.st_turma_escola in ('O', 'A', 'C')											
						AND te.an_letivo = @anoLetivo
						AND NOT cd_serie_ensino IS NULL

						{(codigoEol.HasValue ? @"AND aluno.cd_aluno = @codigoEol " : " ")}";

            var queryBuilder = new StringBuilder(query);

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuilder.Append(";");

            return queryBuilder;
        }

        public async Task<IEnumerable<long>> ObterCodigosAlunosInativosPorAnoLetivo(ParametrosCargaInicialDto parametrosCargaInicialDto, int anoLetivo, DateTime dataReferencia, long? alunoId)
        {
            try
            {
                var query = new StringBuilder(@"
							   SELECT DISTINCT a.cd_aluno AS CodigoAluno 
							   FROM
									v_aluno_cotic aluno (NOLOCK)
								INNER JOIN
									aluno a
									ON aluno.cd_aluno = a.cd_aluno
								INNER JOIN
									v_matricula_cotic matr (NOLOCK)
									ON aluno.cd_aluno = matr.cd_aluno
								INNER JOIN
									matricula_turma_escola mte (NOLOCK)
									ON matr.cd_matricula = mte.cd_matricula
								INNER JOIN
									turma_escola te (NOLOCK)
									ON mte.cd_turma_escola = te.cd_turma_escola
								INNER JOIN
									escola esc (NOLOCK)
									ON te.cd_escola = esc.cd_escola
								WHERE
									mte.cd_situacao_aluno IN (2,3,4,5,7,8,11,12,14,15)
									AND matr.an_letivo = @anoLetivo
									AND te.an_letivo = @anoLetivo
									AND matr.dt_status_matricula >= @dataReferencia
									AND NOT EXISTS (select 1 from v_matricula_cotic where an_letivo >= matr.an_letivo and st_matricula IN(1,6,10,13) and cd_aluno = a.cd_aluno) ");

                if (alunoId != null && alunoId > 0)
                    query.AppendLine("AND a.cd_aluno = @alunoId ");
				
				query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
				query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
				query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
				query.Append(";");

				using var conn = ObterConexao();
                return await conn.QueryAsync<long>(query.ToString(), new { 
					anoLetivo, 
					dataReferencia, 
					alunoId,
					TiposUes = parametrosCargaInicialDto.TiposUes,
					parametrosCargaInicialDto.Ues,
					parametrosCargaInicialDto.Turmas,
				});

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosQueSeraoInativosPorAnoLetivo(Paginacao paginacao, int anoLetivo, DateTime dataReferencia)
        {
            var querySelectDados = @" SELECT 					
										DISTINCT a.cd_aluno AS Codigo,
										a.nm_aluno AS NomePessoa,
										a.nm_social_aluno AS NomeSocial,
										a.dt_nascimento_aluno AS DataNascimento,
										te.cd_turma_escola AS TurmaId,
										mte.cd_situacao_aluno as SituacaoMatricula,
										mte.dt_situacao_aluno as DataSituacao";

            var querySelectCount = "SELECT COUNT(DISTINCT a.cd_aluno) ";

            var queryFrom = new StringBuilder(@" FROM
											v_aluno_cotic aluno (NOLOCK)
										INNER JOIN
											aluno a
											ON aluno.cd_aluno = a.cd_aluno
										INNER JOIN
											v_matricula_cotic matr (NOLOCK)
											ON aluno.cd_aluno = matr.cd_aluno
										INNER JOIN
											matricula_turma_escola mte (NOLOCK)
											ON matr.cd_matricula = mte.cd_matricula
										INNER JOIN
											turma_escola te (NOLOCK)
											ON mte.cd_turma_escola = te.cd_turma_escola
										INNER JOIN
											escola esc (NOLOCK)
											ON te.cd_escola = esc.cd_escola
										WHERE
												mte.cd_situacao_aluno IN (2,3,4,5,7,8,11,12,14,15)
											AND matr.an_letivo = @anoLetivo
											AND te.an_letivo = @anoLetivo
											AND matr.dt_status_matricula >= @dataReferencia
											AND NOT EXISTS (select 1 
												from v_matricula_cotic v2
											   inner join matricula_turma_escola m2 ON 
													v2.cd_matricula = m2.cd_matricula
											   where v2.an_letivo >= matr.an_letivo 
											     and v2.cd_aluno = a.cd_aluno
											     and m2.cd_situacao_aluno IN(1,6,10,13) )
										");

            var queryPaginacao = @"order by a.cd_aluno
								   offset @quantidadeRegistrosIgnorados rows fetch next @quantidadeRegistros rows only;";

            var query = new StringBuilder(querySelectDados);
            query.Append(queryFrom);
            query.Append(queryPaginacao);
            query.Append(querySelectCount);
            query.Append(queryFrom);

            using var conn = ObterConexao();
            using var multi = await conn.QueryMultipleAsync(query.ToString(),
                new
                {
                    quantidadeRegistros = paginacao.QuantidadeRegistros,
                    quantidadeRegistrosIgnorados = paginacao.QuantidadeRegistrosIgnorados,
                    anoLetivo,
                    dataReferencia
                }, commandTimeout: 6000);

            var retorno = new PaginacaoResultadoDto<AlunoEol>
            {
                Items = multi.Read<AlunoEol>(),
                TotalRegistros = multi.ReadFirst<int>()
            };

            retorno.TotalPaginas = paginacao.QuantidadeRegistros > 0 ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;
            return retorno;
        }
    }
}
