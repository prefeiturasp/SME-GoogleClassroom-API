using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAlunoEol : RepositorioEol, IRepositorioAlunoEol
	{
        public RepositorioAlunoEol(ConnectionStrings connectionStrings)
			:base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosParaInclusao(DateTime dataReferencia, Paginacao paginacao, long codigoEol)
        {
            dataReferencia = dataReferencia.Add(new TimeSpan(0, 0, 0));

            var query = MontaQueryAlunosParaInclusao(paginacao, codigoEol);

            using var conn = ObterConexao();

            using var multi = await conn.QueryMultipleAsync(query, 
				new 
				{ 
					anoLetivo = dataReferencia.Year,
					dataReferencia, paginacao.QuantidadeRegistros, 
					paginacao.QuantidadeRegistrosIgnorados, 
					codigoEol 
				}, commandTimeout: 6000);

            var retorno = new PaginacaoResultadoDto<AlunoEol>
            {
                Items = multi.Read<AlunoEol>(),
                TotalRegistros = multi.ReadFirst<int>()
            };

            retorno.TotalPaginas = paginacao.QuantidadeRegistros > 0 ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

		public async Task<IEnumerable<AlunoCursoEol>> ObterCursosDoAlunoParaIncluirAsync(long codigoAluno, int anoLetivo)
		{
			using var conn = ObterConexao();

			const string query = @"
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
									AND te.cd_tipo_turma in (1,2,3,5,6,7)
									AND esc.tp_escola in (1,2,3,4,10,11,12,13,16,17,18,19,23,28,31)
									AND te.an_letivo = @anoLetivo
									AND NOT cd_serie_ensino IS NULL;

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
									te.cd_turma_escola TurmaId
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
									(serie_turma_grade.dt_fim IS NULL OR serie_turma_grade.dt_fim >= GETDATE())

								-- 2. Busca matrículas de programa
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
									AND te.cd_tipo_turma in (1,2,3,5,6,7)
									AND esc.tp_escola in (1,2,3,4,10,11,12,13,16,17,18,19,23,28,31)
									AND te.an_letivo = @anoLetivo
									AND NOT matr.cd_tipo_programa IS NULL;

								-- 2.1 Busca os cursos das turmas
								IF OBJECT_ID('tempdb..#tempTurmasComponentesPrograma') IS NOT NULL 
									DROP TABLE #tempTurmasComponentesPrograma
								SELECT
									DISTINCT
									temp.cd_aluno AS CodigoAluno,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId
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
			return await conn.QueryAsync<AlunoCursoEol>(query, new { codigoAluno, anoLetivo });
		}

		public async Task<PaginacaoResultadoDto<GradeAlunoCursoEol>> ObterGradesDeCursosDosAlunosAsync(DateTime dataReferencia, Paginacao paginacao, long? codigoAluno, long? turmaId, long? componenteCurricularId)
		{
			using var conn = ObterConexao();

			var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
			var query = MontaQueryGradesAlunoCursoParaInclusao(aplicarPaginacao, codigoAluno, turmaId, componenteCurricularId);
			var parametros = new
			{
				anoLetivo = dataReferencia.Year,
				dataReferencia = dataReferencia.Date,
				paginacao.QuantidadeRegistros,
				paginacao.QuantidadeRegistrosIgnorados,
				codigoAluno,
				turmaId,
				componenteCurricularId
			};
			using var multi = await conn.QueryMultipleAsync(query, parametros);

			var retorno = new PaginacaoResultadoDto<GradeAlunoCursoEol>();

			retorno.Items = multi.Read<GradeAlunoCursoEol>();
			retorno.TotalRegistros = multi.ReadFirst<int>();
			retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

			return retorno;
		}

		private static string MontaQueryAlunosParaInclusao(Paginacao paginacao, long codigoEol)
        {

            return $@"DECLARE @situacaoAtivo AS CHAR = 1;
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
						matr.dt_status_matricula > @dataReferencia
						AND matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
						AND mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
						AND matr.an_letivo = @anoLetivo
						AND te.st_turma_escola in ('O', 'A', 'C')
						AND te.cd_tipo_turma in (1,2,3,5,6,7)
						AND esc.tp_escola in (1,2,3,4,10,11,12,13,16,17,18,19,23,28,31)
						AND te.an_letivo = @anoLetivo
						AND NOT cd_serie_ensino IS NULL
						
						{(codigoEol > 0 ? @"AND aluno.cd_aluno = @codigoEol;" : ";")}

					--- 1.1 Agrupa para buscar a mais recente em caso de mais de uma no ano por aluno
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
						and matr.an_letivo = @anoLetivo;

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
						matr.dt_status_matricula > @dataReferencia
						AND matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
						AND mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
						AND matr.an_letivo = @anoLetivo
						AND te.st_turma_escola in ('O', 'A', 'C')
						AND te.cd_tipo_turma in (1,2,3,5,6,7)
						AND esc.tp_escola in (1,2,3,4,10,11,12,13,16,17,18,19,23,28,31)
						AND te.an_letivo = @anoLetivo
						AND NOT matr.cd_tipo_programa IS NULL

						{(codigoEol > 0 ? @"AND aluno.cd_aluno = @codigoEol;" : ";")}

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
						and matr.an_letivo = @anoLetivo;

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
						aluno.nm_aluno NomeAluno,  
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
					{(paginacao.QuantidadeRegistros > 0 ? @"OFFSET @quantidadeRegistrosIgnorados ROWS
					FETCH NEXT @quantidadeRegistros ROWS ONLY;" : ";")}
					

					-- Totalizacao
					SELECT 
						COUNT(*)
					FROM 
						#tempAlunosMatriculasAtivasFinal temp;";

        }

		private static string MontaQueryGradesAlunoCursoParaInclusao(bool aplicarPaginacao, long? codigoAluno, long? turmaId, long? componenteCurricularId)
        {
			const string queryRegularesBase = @"
				IF OBJECT_ID('tempdb..#tempTurmasComponentesRegulares') IS NOT NULL 
					DROP TABLE #tempTurmasComponentesRegulares
				SELECT
					DISTINCT
					CASE
						WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
					ELSE
						cc.cd_componente_curricular
					END ComponenteCurricularId,
					te.cd_turma_escola TurmaId
				INTO #tempTurmasComponentesRegulares
				FROM
					turma_escola te (NOLOCK)
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
					serie_turma_grade (NOLOCK) 
					ON serie_turma_grade.cd_turma_escola = te.cd_turma_escola
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
					te.an_letivo = @anoLetivo
					AND	  te.st_turma_escola in ('O', 'A', 'C')
					AND   te.cd_tipo_turma in (1,2,3,5,6,7)
					AND   esc.tp_escola in (1,2,3,4,10,13,16,17,18,19,23,25,28,31)	
					AND   serie_turma_grade.dt_inicio > @dataReferencia
					AND   (serie_turma_grade.dt_fim IS NULL OR serie_turma_grade.dt_fim >= GETDATE())";

			const string queryProgramaBase = @"
				IF OBJECT_ID('tempdb..#tempTurmasComponentesPrograma') IS NOT NULL 
					DROP TABLE #tempTurmasComponentesPrograma
				SELECT
					DISTINCT
					pcc.cd_componente_curricular AS ComponenteCurricularId,
					te.cd_turma_escola TurmaId
				INTO #tempTurmasComponentesPrograma
				FROM
					turma_escola te (NOLOCK)
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
					te.an_letivo = @anoLetivo
					AND   te.st_turma_escola in ('O', 'A', 'C')
					AND   te.cd_tipo_turma in (1,2,3,5,6,7)
					AND   esc.tp_escola in (1,2,3,4,10,13,16,17,18,19,23,25,28,31)	
					AND   tegp.dt_inicio > @dataReferencia
					AND   (tegp.dt_fim IS NULL OR tegp.dt_fim >= GETDATE())";

			var queryRegulares = new StringBuilder(queryRegularesBase);
			var queryPrograma = new StringBuilder(queryProgramaBase);

			if(turmaId.HasValue)
            {
				queryRegulares.AppendLine("AND te.cd_turma_escola = @turmaId");
				queryPrograma.AppendLine("AND te.cd_turma_escola = @turmaId");
			}

			if(componenteCurricularId.HasValue)
            {
				queryRegulares.AppendLine("AND gcc.cd_componente_curricular = @componenteCurricularId");
				queryPrograma.AppendLine("AND pcc.cd_componente_curricular = @componenteCurricularId");
			}

			queryRegulares.AppendLine(";");
			queryPrograma.AppendLine(";");

			var query = new StringBuilder($@"{queryRegulares} {queryPrograma}");
			query.AppendLine(@"
				IF OBJECT_ID('tempdb..#tempTurmasComponentes') IS NOT NULL 
					DROP TABLE #tempTurmasComponentes
				SELECT
					*
				INTO #tempTurmasComponentes
				FROM
					(SELECT * FROM #tempTurmasComponentesRegulares) AS Regulares
				UNION
					(SELECT * FROM #tempTurmasComponentesPrograma);

				IF OBJECT_ID('tempdb..#tempTurmas') IS NOT NULL 
					DROP TABLE #tempTurmas
				SELECT
					DISTINCT
					TurmaId
				INTO #tempTurmas
				FROM
					#tempTurmasComponentes;");

			query.AppendLine(@"
				DECLARE @situacaoAtivo AS CHAR = 1;
				DECLARE @situacaoPendenteRematricula AS CHAR = 6;
				DECLARE @situacaoRematriculado AS CHAR = 10;
				DECLARE @situacaoSemContinuidade AS CHAR = 13;

				DECLARE @situacaoAtivoInt AS INT = 1;
				DECLARE @situacaoPendenteRematriculaInt AS INT = 6;
				DECLARE @situacaoRematriculadoInt AS INT = 10;
				DECLARE @situacaoSemContinuidadeInt AS INT = 13;

				IF OBJECT_ID('tempdb..#tempAlunosTurmas') IS NOT NULL 
					DROP TABLE #tempAlunosTurmas
				SELECT
					DISTINCT
					aluno.cd_aluno AS CodigoAluno,
					te.cd_turma_escola AS TurmaId,
					te.cd_escola AS CdUe
				INTO #tempAlunosTurmas
				FROM
					#tempTurmas temp
				INNER JOIN
					turma_escola te (NOLOCK)
					ON temp.TurmaId = te.cd_turma_escola
				INNER JOIN
					escola esc (NOLOCK)
					ON te.cd_escola = esc.cd_escola
				INNER JOIN 
					matricula_turma_escola mte (NOLOCK) 
					ON mte.cd_turma_escola = te.cd_turma_escola
				INNER JOIN
					v_matricula_cotic matr (NOLOCK) 
					ON mte.cd_matricula = matr.cd_matricula
				INNER JOIn
					v_aluno_cotic aluno (NOLOCK)
					ON aluno.cd_aluno = matr.cd_aluno
				WHERE
					matr.st_matricula IN (@situacaoAtivo, @situacaoPendenteRematricula, @situacaoRematriculado, @situacaoSemContinuidade)
					AND mte.cd_situacao_aluno IN (@situacaoAtivoInt, @situacaoPendenteRematriculaInt, @situacaoRematriculadoInt, @situacaoSemContinuidadeInt)
					AND matr.an_letivo = @anoLetivo
					AND te.an_letivo = @anoLetivo");

			query.AppendLine(codigoAluno.HasValue ? "AND aluno.cd_aluno = @codigoAluno": ";");

			query.AppendLine(@"
				IF OBJECT_ID('tempdb..#tempGradesAlunosCursos') IS NOT NULL 
					DROP TABLE #tempGradesAlunosCursos
				SELECT
					alunos.CodigoAluno,
					cursos.TurmaId,
					cursos.ComponenteCurricularId,
					alunos.CdUe
				INTO #tempGradesAlunosCursos
				FROM
					#tempAlunosTurmas alunos
				INNER JOIN
					#tempTurmasComponentes cursos
					ON alunos.TurmaId =  cursos.TurmaId");

			query.AppendLine(aplicarPaginacao ? "OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY;" : ";");

			query.AppendLine(@"
				SELECT
					*
				FROM
					#tempGradesAlunosCursos

				SELECT
					COUNT(*)
				FROM
					#tempGradesAlunosCursos;");

			return query.ToString();
        }
    }
}
