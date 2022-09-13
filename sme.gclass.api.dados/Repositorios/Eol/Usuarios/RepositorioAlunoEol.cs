using Dapper;
using SME.GoogleClassroom.Dados.Help;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAlunoEol : RepositorioEol, IRepositorioAlunoEol
    {
        public RepositorioAlunoEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosParaInclusaoAsync(Paginacao paginacao, int anoLetivo, DateTime? dataReferencia, long? codigoEol, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            dataReferencia = dataReferencia?.Add(new TimeSpan(0, 0, 0));

            var query = MontaQueryAlunosParaInclusao(paginacao, dataReferencia, codigoEol, parametrosCargaInicialDto);

            using var conn = ObterConexao();

            using var multi = await conn.QueryMultipleAsync(query,
                new
                {
                    anoLetivo,
                    pagina = paginacao.Pagina,
					quantidadeRegistros = paginacao.QuantidadeRegistros,
                    codigoEol,
                    TiposUes = parametrosCargaInicialDto.TiposUes,
					parametrosCargaInicialDto.Ues,
					parametrosCargaInicialDto.Turmas,
				}, commandTimeout: 120);

            var retorno = new PaginacaoResultadoDto<AlunoEol>
            {
                Items = multi.Read<AlunoEol>(),
                TotalRegistros = multi.ReadFirst<int>()
            };

            retorno.TotalPaginas = paginacao.QuantidadeRegistros > 0 ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;
            return retorno;
        }

        public async Task<AlunoEol> ObterAlunoParaTratamentoDeErroAsync(long codigoEol, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var query = MontaQueryAlunosParaInclusao(null, null, codigoEol, parametrosCargaInicialDto);

            using var conn = ObterConexao();
            return await conn.QuerySingleOrDefaultAsync<AlunoEol>(query,
                new
                {
                    anoLetivo = anoLetivo,
                    codigoEol,
                    TiposUes = parametrosCargaInicialDto.TiposUes,
					parametrosCargaInicialDto.Ues,
					parametrosCargaInicialDto.Turmas,
				}, commandTimeout: 6000);
        }

        public async Task<IEnumerable<AlunoCursoEol>> ObterCursosDoAlunoParaIncluirAsync(long codigoAluno, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            using var conn = ObterConexao();

			const string queryBuscaMatriculas = @"
								DECLARE @situacaoAtivo AS CHAR = 1;
								DECLARE @situacaoPendenteRematricula AS CHAR = 6;
								DECLARE @situacaoRematriculado AS CHAR = 10;
								DECLARE @situacaoSemContinuidade AS CHAR = 13;

								DECLARE @situacaoAtivoInt AS INT = 1;
								DECLARE @situacaoPendenteRematriculaInt AS INT = 6;
								DECLARE @situacaoRematriculadoInt AS INT = 10;
								DECLARE @situacaoSemContinuidadeInt AS INT = 13;

								-- 1. Busca matrículas regulares
								IF OBJECT_ID('tempdb..#tempAlunosMatriculasRegularesAtivas') IS NOT NULL
									DROP TABLE #tempAlunosMatriculasRegularesAtivas;
								SELECT
									a.cd_aluno,
									te.cd_turma_escola
								INTO #tempAlunosMatriculasRegularesAtivas
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
									a.cd_aluno = @codigoAluno
									AND matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
									AND mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
									AND matr.an_letivo = @anoLetivo
									AND te.st_turma_escola in ('O', 'A', 'C')									
									AND te.an_letivo = @anoLetivo
									AND NOT cd_serie_ensino IS NULL; ";

			string queryBuscaCursosTurmas = $@"
								-- 1.1 Busca os cursos das turmas
								IF OBJECT_ID('tempdb..#tempTurmasComponentesRegulares') IS NOT NULL
									DROP TABLE #tempTurmasComponentesRegulares
								SELECT
									DISTINCT
									temp.cd_aluno AS CodigoAluno,
									CASE
										WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
									ELSE
										cc.cd_componente_curricular
									END ComponenteCurricularId,
									te.cd_turma_escola TurmaId,
									te.cd_escola AS UeCodigo
								INTO #tempTurmasComponentesRegulares
								FROM
									#tempAlunosMatriculasRegularesAtivas temp
								INNER JOIN
									turma_escola te (NOLOCK)
									ON temp.cd_turma_escola = te.cd_turma_escola
								INNER JOIN
									escola esc (NOLOCK)
									ON te.cd_escola = esc.cd_escola
								INNER JOIN
									v_cadastro_unidade_educacao ue (NOLOCK)
									ON ue.cd_unidade_educacao = esc.cd_escola
								INNER JOIN
									tipo_escola tpe (NOLOCK)
									ON esc.tp_escola = tpe.tp_escola
								INNER JOIN
									unidade_administrativa dre (NOLOCK)
									ON ue.cd_unidade_administrativa_referencia = dre.cd_unidade_administrativa
								INNER JOIN
									serie_turma_escola (NOLOCK)
									ON serie_turma_escola.cd_turma_escola = te.cd_turma_escola
								INNER JOIN
									serie_turma_grade (NOLOCK)
									ON serie_turma_grade.cd_turma_escola = serie_turma_escola.cd_turma_escola AND serie_turma_grade.dt_fim IS NULL
								INNER JOIN
									escola_grade (NOLOCK)
									ON serie_turma_grade.cd_escola_grade = escola_grade.cd_escola_grade
								INNER JOIN
									grade (NOLOCK)
									ON escola_grade.cd_grade = grade.cd_grade
								INNER JOIN
									grade_componente_curricular gcc (NOLOCK)
									ON gcc.cd_grade = grade.cd_grade
								INNER JOIN
									componente_curricular cc (NOLOCK)
									ON cc.cd_componente_curricular = gcc.cd_componente_curricular AND cc.dt_cancelamento IS NULL
								INNER JOIN
									serie_ensino (NOLOCK)
									ON grade.cd_serie_ensino = serie_ensino.cd_serie_ensino
								INNER JOIN
									etapa_ensino (NOLOCK)
									ON serie_ensino.cd_etapa_ensino = etapa_ensino.cd_etapa_ensino
								WHERE
									(serie_turma_grade.dt_fim IS NULL OR serie_turma_grade.dt_fim >= GETDATE())";

			string queryBuscaProgramas = $@"-- 2. Busca matrículas de programa
								IF OBJECT_ID('tempdb..#tempAlunosMatriculasProgramaAtivas') IS NOT NULL
									DROP TABLE #tempAlunosMatriculasProgramaAtivas;
								SELECT
									a.cd_aluno,
									te.cd_turma_escola
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
									a.cd_aluno = @codigoAluno
									AND matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
									AND mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
									AND matr.an_letivo = @anoLetivo
									AND te.st_turma_escola in ('O', 'A', 'C')									
									AND te.an_letivo = @anoLetivo
									AND NOT matr.cd_tipo_programa IS NULL;";

			var queryBuscaMatriculasBuilder = new StringBuilder(queryBuscaMatriculas);
			queryBuscaMatriculasBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			queryBuscaMatriculasBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			queryBuscaMatriculasBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
			queryBuscaMatriculasBuilder.Append(";");

			var queryBuscaCursosTurmasBuider = new StringBuilder(queryBuscaCursosTurmas);
			queryBuscaCursosTurmasBuider.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			queryBuscaCursosTurmasBuider.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			queryBuscaCursosTurmasBuider.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
			queryBuscaCursosTurmasBuider.Append(";");

			var queryBuscaProgramasBuilder = new StringBuilder(queryBuscaProgramas);
			queryBuscaProgramasBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			queryBuscaProgramasBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			queryBuscaProgramasBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
			queryBuscaProgramasBuilder.Append(";");

			string query = $@"	{queryBuscaMatriculas}
								{queryBuscaCursosTurmas}
								{queryBuscaProgramas}
								-- 2.1 Busca os cursos das turmas
								IF OBJECT_ID('tempdb..#tempTurmasComponentesPrograma') IS NOT NULL
									DROP TABLE #tempTurmasComponentesPrograma
								SELECT
									DISTINCT
									temp.cd_aluno AS CodigoAluno,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId,
									te.cd_escola AS UeCodigo
								INTO #tempTurmasComponentesPrograma
								FROM
									#tempAlunosMatriculasProgramaAtivas temp
								INNER JOIN
									turma_escola te (NOLOCK)
									ON te.cd_turma_escola = temp.cd_turma_escola
								INNER JOIN
									escola esc (NOLOCK)
									ON te.cd_escola = esc.cd_escola
								INNER JOIN
									v_cadastro_unidade_educacao ue (NOLOCK)
									ON ue.cd_unidade_educacao = esc.cd_escola
								INNER JOIN
									tipo_escola tpe (NOLOCK)
									ON esc.tp_escola = tpe.tp_escola
								INNER JOIN
									unidade_administrativa dre (NOLOCK)
									ON ue.cd_unidade_administrativa_referencia = dre.cd_unidade_administrativa
								LEFT JOIN
									tipo_programa tp (NOLOCK)
									ON te.cd_tipo_programa = tp.cd_tipo_programa
								INNER JOIN
									turma_escola_grade_programa tegp (NOLOCK)
									ON tegp.cd_turma_escola = te.cd_turma_escola
								INNER JOIN
									escola_grade teg (NOLOCK)
									ON teg.cd_escola_grade = tegp.cd_escola_grade
								INNER JOIN
									grade pg (NOLOCK) ON pg.cd_grade = teg.cd_grade
								INNER JOIN
									grade_componente_curricular pgcc (NOLOCK)
									ON pgcc.cd_grade = teg.cd_grade
								INNER JOIN
									componente_curricular pcc (NOLOCK)
									ON pgcc.cd_componente_curricular = pcc.cd_componente_curricular and pcc.dt_cancelamento is null
								WHERE
									(tegp.dt_fim IS NULL OR tegp.dt_fim >= GETDATE());

								SELECT
									*
								FROM
									(SELECT * FROM #tempTurmasComponentesRegulares) AS Regulares
								UNION
									(SELECT * FROM #tempTurmasComponentesPrograma);";

			return await conn.QueryAsync<AlunoCursoEol>(query, new { 
				codigoAluno, 
				anoLetivo,
				TiposUes = parametrosCargaInicialDto.TiposUes,
				parametrosCargaInicialDto.Ues,
				parametrosCargaInicialDto.Turmas,
			});
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
        
        public async Task<IEnumerable<long>> ObterAlunosCodigosInativosPorAnoLetivoETurmaCelp(int anoLetivo, long turmaId)
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
				    AND esc.tp_escola = 27
					AND mte.dt_situacao_aluno = (select max(mte2.dt_situacao_aluno) from v_matricula_cotic matr2(NOLOCK)
													 inner join matricula_turma_escola mte2 (NOLOCK) on mte2.cd_matricula = matr2.cd_matricula
													 where matr2.cd_aluno = a.cd_aluno
													   and matr2.an_letivo = te.an_letivo
													   and mte2.cd_turma_escola = te.cd_turma_escola)";

			using var conn = ObterConexao();
            return await conn.QueryAsync<long>(query, new { 
				turmaId, 
				anoLetivo
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
					quantidadeRegistrosIgnorados = paginacao.QuantidadeRegistrosIgnorados,
					quantidadeRegistros = paginacao.QuantidadeRegistros,
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
					{(paginacao.Pagina > 0 ? @"OFFSET (@pagina - 1) * @quantidadeRegistros ROWS
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
					-- 2.1 Montagem da tabela de inserção
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
						#tempAlunosMatriculasProgramaAtivas temp
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
						max(matr.cd_matricula) cd_matricula,
						max(matr.dt_status_matricula) dt_status_matricula
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
						AND te.st_turma_escola in ('O', 'A', 'C')
						AND te.an_letivo = @anoLetivo
						AND NOT matr.cd_tipo_programa IS NULL
						{(codigoEol.HasValue ? @"AND aluno.cd_aluno = @codigoEol " : " ")} ";

            var queryBuilder = new StringBuilder(query);

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuilder.AppendLine("GROUP BY aluno.cd_aluno;");

			return queryBuilder; 
		}

        private static StringBuilder QueryBuscaRecenteAnoAluno(ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var query = $@"
					--- 1.2 Montagem da tabela de inserção
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
						#tempAlunosMatriculasAtivas temp
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
						max(matr.cd_matricula) cd_matricula,
						max(matr.dt_status_matricula) dt_status_matricula
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
						AND te.st_turma_escola in ('O', 'A', 'C')
						AND te.an_letivo = @anoLetivo
						AND NOT cd_serie_ensino IS NULL
						{(codigoEol.HasValue ? @"AND aluno.cd_aluno = @codigoEol " : " ")}";

            var queryBuilder = new StringBuilder(query);

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuilder.AppendLine("GROUP BY aluno.cd_aluno;");

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
									AND matr.cd_matricula NOT IN (select cd_matricula from v_matricula_cotic where an_letivo >= matr.an_letivo and st_matricula IN(1,6,10,13) and cd_aluno = a.cd_aluno)");

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
        public async Task<IEnumerable<AlunoCelpDto>> ObterAlunosMatriculadosCelpPorComponenteEAnoLetivo(long componenteCurricularId, int anoLetivo, long turmaId)
        {
	        const string query = @"select distinct amn.CodigoAluno,
				te.cd_turma_escola as TurmaCodigo,
				gcc.cd_componente_curricular as ComponenteCodigo,
				amn.NomeAluno as Nome,amn.NomeSocialAluno as NomeSocial, amn.DataNascimento
				from alunos_matriculas_norm amn
				inner join turma_escola te on te.cd_turma_escola = amn.CodigoTurma
				inner join turma_escola_grade_programa tegp on tegp.cd_turma_escola = te.cd_turma_escola
				inner join escola_grade eg on eg.cd_escola_grade = tegp.cd_escola_grade
				inner join grade g on g.cd_grade = eg.cd_grade
				inner join grade_componente_curricular gcc on gcc.cd_grade = g.cd_grade
				inner join escola e on e.cd_escola = te.cd_escola
				where gcc.cd_componente_curricular = @componenteCurricularId
				and te.an_letivo = @anoLetivo
				and te.cd_turma_escola = @turmaId
				and e.tp_escola = 27
				and amn.CodigoSituacaoMatricula in (1, 2, 3, 6, 10, 13)";

	        using var conn = ObterConexao();
	        return await conn.QueryAsync<AlunoCelpDto>(query, new { componenteCurricularId, anoLetivo, turmaId });
        }
    }
}
