using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoEol : RepositorioEol, IRepositorioCursoEol
    {
        public RepositorioCursoEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoEol>> ObterCursosParaInclusao(DateTime dataReferencia, Paginacao paginacao, long? componenteCurricularId, long? turmaId)
        {
            dataReferencia = dataReferencia.Add(new TimeSpan(0, 0, 0));

            var paginar = paginacao.QuantidadeRegistros > 0;
            var query = MontaQueryCursosParaInclusao(paginar, componenteCurricularId, turmaId);

            using var conn = ObterConexao();

            var parametros = new { anoLetivo = dataReferencia.Year, dataReferencia, paginacao.QuantidadeRegistros, paginacao.QuantidadeRegistrosIgnorados, componenteCurricularId, turmaId };

            using var multi = await conn.QueryMultipleAsync(query, parametros, commandTimeout: 300);

            var retorno = new PaginacaoResultadoDto<CursoEol>();

            retorno.Items = multi.Read<CursoEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = paginar ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

        public async Task<IEnumerable<ProfessorCursoEol>> ObterProfessoresDoCursoParaIncluirGoogleAsync(int anoLetivo, long turmaId, long componenteCurricularId)
        {
            using var conn = ObterConexao();

            const string query = @"-- 1. Busca os cursos regulares do Professor
								IF OBJECT_ID('tempdb..#tempProfessoresDeTurmasComponentesRegulares') IS NOT NULL
									DROP TABLE #tempProfessoresDeTurmasComponentesRegulares
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									te.cd_turma_escola TurmaId,
									CASE
										WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
									ELSE
										cc.cd_componente_curricular
									END ComponenteCurricularId
								INTO #tempProfessoresDeTurmasComponentesRegulares
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
								-- Atribuição de aula
								INNER JOIN
									atribuicao_aula atb_ser (NOLOCK)
									ON gcc.cd_grade = atb_ser.cd_grade
									AND gcc.cd_componente_curricular = atb_ser.cd_componente_curricular
									AND atb_ser.cd_serie_grade = serie_turma_grade.cd_serie_grade
									AND atb_ser.dt_cancelamento is null
									AND atb_ser.dt_disponibilizacao_aulas is null
									AND atb_ser.an_atribuicao = @anoLetivo
								-- Servidor
								INNER JOIN
									v_cargo_base_cotic vcbc (NOLOCK)
									ON atb_ser.cd_cargo_base_servidor = vcbc.cd_cargo_base_servidor
									AND vcbc.dt_cancelamento is null
									AND vcbc.dt_fim_nomeacao is null
								INNER JOIN
									v_servidor_cotic serv (NOLOCK)
									ON serv.cd_servidor = vcbc.cd_servidor
								WHERE
									te.st_turma_escola in ('O', 'A', 'C')
									AND   te.cd_tipo_turma in (1,2,3,5,6,7)
									AND   esc.tp_escola in (1,2,3,4,10,13,16,17,18,19,23,25,28,31)
									AND   te.an_letivo = @anoLetivo
									AND	  te.cd_turma_escola = @turmaId
									AND   gcc.cd_componente_curricular = @componenteCurricularId;

								-- 2. Busca os cursos de programa do Professor
								IF OBJECT_ID('tempdb..#tempProfessoresDeTurmasComponentesPrograma') IS NOT NULL
									DROP TABLE #tempProfessoresDeTurmasComponentesPrograma
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId
								INTO #tempProfessoresDeTurmasComponentesPrograma
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
									turma_escola_grade_programa tegp (NOLOCK)
									ON tegp.cd_turma_escola = te.cd_turma_escola AND tegp.dt_fim IS NULL
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
								-- Atribuicao turma programa
								INNER JOIN
									atribuicao_aula atb_pro (NOLOCK)
									ON pgcc.cd_grade = atb_pro.cd_grade
									AND pgcc.cd_componente_curricular = atb_pro.cd_componente_curricular
									AND atb_pro.cd_turma_escola_grade_programa = tegp.cd_turma_escola_grade_programa
									AND atb_pro.dt_cancelamento IS NULL
									AND atb_pro.dt_disponibilizacao_aulas IS NULL
									AND atb_pro.an_atribuicao = @anoLetivo
								-- Servidor
								INNER JOIN
									v_cargo_base_cotic vcbc (NOLOCK)
									ON atb_pro.cd_cargo_base_servidor = vcbc.cd_cargo_base_servidor AND vcbc.dt_cancelamento IS NULL AND vcbc.dt_fim_nomeacao IS NULL
								INNER JOIN
									v_servidor_cotic serv (NOLOCK)
									ON serv.cd_servidor = vcbc.cd_servidor
								WHERE
									te.st_turma_escola in ('O', 'A', 'C')
									AND   te.cd_tipo_turma in (1,2,3,5,6,7)
									AND   esc.tp_escola in (1,2,3,4,10,13,16,17,18,19,23,25,28,31)
									AND   te.an_letivo = @anoLetivo
									AND	  te.cd_turma_escola = @turmaId
									AND   pgcc.cd_componente_curricular = @componenteCurricularId;

								SELECT
									*
								FROM
									(SELECT * FROM #tempProfessoresDeTurmasComponentesRegulares) AS Regulares
								UNION
									(SELECT * FROM #tempProfessoresDeTurmasComponentesPrograma);";

            return await conn.QueryAsync<ProfessorCursoEol>(query, new { turmaId, componenteCurricularId, anoLetivo });
        }

		public async Task<IEnumerable<AlunoCursoEol>> ObterAlunosDoCursoParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId)
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

				SELECT
					DISTINCT
					a.cd_aluno AS CodigoAluno,
					te.cd_turma_escola AS TurmaId,
					@componenteCurricularId AS ComponenteCurricularId,
					te.cd_escola AS UeCodigo
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
					AND te.an_letivo = @anoLetivo
					AND te.cd_turma_escola = @turmaId";

			return await conn.QueryAsync<AlunoCursoEol>(query, new { turmaId, componenteCurricularId, anoLetivo });
		}

		public async Task<PaginacaoResultadoDto<GradeCursoEol>> ObterGradesDeCursosAsync(DateTime dataReferencia, Paginacao paginacao, long? turmaId, long? componenteCurricularId)
		{
			using var conn = ObterConexao();

			var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
			var query = MontaQueryGradesCursosParaInclusao(aplicarPaginacao, turmaId, componenteCurricularId);
			var parametros = new
			{
				anoLetivo = dataReferencia.Year,
				dataReferencia = dataReferencia.Date,
				paginacao.QuantidadeRegistros,
				paginacao.QuantidadeRegistrosIgnorados,
				turmaId,
				componenteCurricularId
			};

			using var multi = await conn.QueryMultipleAsync(query, parametros);

			var retorno = new PaginacaoResultadoDto<GradeCursoEol>();

			retorno.Items = multi.Read<GradeCursoEol>();
			retorno.TotalRegistros = multi.ReadFirst<int>();
			retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

			return retorno;
		}

		private static string MontaQueryCursosParaInclusao(bool ehParaPaginar, long? componenteCurricularId, long? turmaId)
		{
			var query = new StringBuilder();
			query.AppendLine(@"-- 2) Busca os cursos regulares
							IF OBJECT_ID('tempdb..#tempTurmasComponentesRegulares') IS NOT NULL 
								DROP TABLE #tempTurmasComponentesRegulares
							SELECT
								DISTINCT
								CASE
										WHEN etapa_ensino.cd_etapa_ensino IN( 1 )
									THEN 'REGÊNCIA DE CLASSE INFANTIL'
								ELSE
									iif(tgt.cd_serie_grade is not null, concat(LTRIM(RTRIM(ter.dc_territorio_saber)), ' - ',  LTRIM(RTRIM(tep.dc_experiencia_pedagogica))),
									LTRIM(RTRIM(cc.dc_componente_curricular)))
								END Nome,
								CONCAT(CASE
										WHEN etapa_ensino.cd_etapa_ensino IN( 2, 3, 7, 11 )
									THEN
									--eja
									'EJA'
										WHEN etapa_ensino.cd_etapa_ensino IN ( 4, 5, 12, 13 )
									THEN
									--fundamental
									'EF'
										WHEN etapa_ensino.cd_etapa_ensino IN
											( 6, 7, 8, 9, 17, 14 ) THEN
									--médio
									'EM'
									WHEN etapa_ensino.cd_etapa_ensino IN ( 1 )
										THEN
									--infantil
									'EI'
									ELSE 'P'
									END, ' - ',  te.dc_turma_escola, ' - ',
									te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ', LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao) Secao,
								CASE
									WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
								ELSE
									cc.cd_componente_curricular
								END ComponenteCurricularId,
								te.cd_turma_escola TurmaId,
								grade.cd_grade,
								serie_turma_grade.cd_serie_grade,
								ue.cd_unidade_educacao
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
							--- Território
							LEFT JOIN
								turma_grade_territorio_experiencia tgt (NOLOCK)
								ON tgt.cd_serie_grade = serie_turma_grade.cd_serie_grade AND tgt.cd_componente_curricular = cc.cd_componente_curricular
							LEFT JOIN
								territorio_saber ter (NOLOCK)
								ON ter.cd_territorio_saber = tgt.cd_territorio_saber
							LEFT JOIN
								tipo_experiencia_pedagogica tep (NOLOCK)
								ON tep.cd_experiencia_pedagogica = tgt.cd_experiencia_pedagogica
							--- Território
							WHERE
								te.an_letivo = @anoLetivo
								AND	  te.st_turma_escola in ('O', 'A', 'C')
								AND   te.cd_tipo_turma in (1,2,3,5,6,7)
								AND   esc.tp_escola in (1,2,3,4,10,13,16,17,18,19,23,25,28,31)
								AND   te.dt_inicio >= @dataReferencia
								AND   (serie_turma_grade.dt_fim IS NULL OR serie_turma_grade.dt_fim >= GETDATE())");

            if (componenteCurricularId.HasValue)
            {
                if (componenteCurricularId.Value == 512)
                {
                    query.AppendLine("AND etapa_ensino.cd_etapa_ensino = 1 ");
                }
                else query.AppendLine("AND cc.cd_componente_curricular = @componenteCurricularId ");
            }

            if (turmaId.HasValue)
            {
                query.AppendLine("AND te.cd_turma_escola = @turmaId");
            }

            query.AppendLine(@"--- 2.1) Busca as atribuições de aula para os professores de cada curso regular
							IF OBJECT_ID('tempdb..#tempTurmasComponentesRegularesProfessores') IS NOT NULL
								DROP TABLE #tempTurmasComponentesRegularesProfessores
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email
							INTO #tempTurmasComponentesRegularesProfessores
							FROM
								#tempTurmasComponentesRegulares temp
							INNER JOIN
								atribuicao_aula atr (NOLOCK)
								ON atr.cd_grade = temp.cd_grade AND atr.cd_serie_grade = temp.cd_serie_grade AND atr.cd_componente_curricular = temp.ComponenteCurricularId
							INNER JOIN
								v_cargo_base_cotic cbc (NOLOCK)
								ON cbc.cd_cargo_base_servidor = atr.cd_cargo_base_servidor
							INNER JOIN
								v_servidor_cotic serv (NOLOCK)
								ON cbc.cd_servidor = serv.cd_servidor
							WHERE
								atr.an_atribuicao = @anoLetivo
								AND atr.dt_cancelamento IS NULL
								AND atr.dt_disponibilizacao_aulas IS NULL;

							--- 2.2) Define a tabela final de cursos regulares com responsáveis
							IF OBJECT_ID('tempdb..#tempCursosRegulares') IS NOT NULL
								DROP TABLE #tempCursosRegulares
							SELECT
								t1.*,
								t2.Email
							INTO #tempCursosRegulares
							FROM
								#tempTurmasComponentesRegulares t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM #tempTurmasComponentesRegularesProfessores temp WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2;

							-- 3) Busca os cursos de Programa
							IF OBJECT_ID('tempdb..#tempTurmasComponentesPrograma') IS NOT NULL
								DROP TABLE #tempTurmasComponentesPrograma
							SELECT
								DISTINCT
								pcc.dc_componente_curricular Nome,
								CONCAT('P - ',  te.dc_turma_escola, ' - ',
									te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ', LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao) Secao,
								pcc.cd_componente_curricular AS ComponenteCurricularId,
								te.cd_turma_escola TurmaId,
								pg.cd_grade,
								tegp.cd_turma_escola_grade_programa,
								ue.cd_unidade_educacao
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
								AND   te.dt_inicio >= @dataReferencia
								AND   (tegp.dt_fim IS NULL OR tegp.dt_fim >= GETDATE())");

            if (componenteCurricularId.HasValue)
            {
                if (componenteCurricularId.Value != 512)
                {
                    query.AppendLine("AND pcc.cd_componente_curricular = @componenteCurricularId ");
                }
            }

            if (turmaId.HasValue)
            {
                query.AppendLine("AND te.cd_turma_escola = @turmaId");
            }

            query.AppendLine(@"--- 3.1) Busca as atribuições de aula para os professores de cada curso de programa
							IF OBJECT_ID('tempdb..#tempTurmasComponentesProgramaProfessores') IS NOT NULL
								DROP TABLE #tempTurmasComponentesProgramaProfessores
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email
							INTO #tempTurmasComponentesProgramaProfessores
							FROM
								#tempTurmasComponentesPrograma temp
							LEFT JOIN
								atribuicao_aula atr (NOLOCK)
								ON atr.cd_grade = temp.cd_grade AND atr.cd_turma_escola_grade_programa = temp.cd_turma_escola_grade_programa AND atr.cd_componente_curricular = temp.ComponenteCurricularId
							LEFT JOIN
								v_cargo_base_cotic cbc (NOLOCK)
								ON cbc.cd_cargo_base_servidor = atr.cd_cargo_base_servidor
							LEFT JOIN
								v_servidor_cotic serv (NOLOCK)
								ON cbc.cd_servidor = serv.cd_servidor
							WHERE
								atr.an_atribuicao = @anoLetivo
								AND atr.dt_cancelamento IS NULL
								AND atr.dt_disponibilizacao_aulas IS NULL;

							--- 3.2) Define a tabela final de cursos de programa com responsáveis
							IF OBJECT_ID('tempdb..#tempCursosPrograma') IS NOT NULL
								DROP TABLE #tempCursosPrograma
							SELECT
								t1.*,
								t2.Email
							INTO #tempCursosPrograma
							FROM
								#tempTurmasComponentesPrograma t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM #tempTurmasComponentesProgramaProfessores temp WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2;

							-- 4) Junta cursos regulares e turmas de programa
							IF OBJECT_ID('tempdb..#tempCursosDre') IS NOT NULL
								DROP TABLE #tempCursosDre
							SELECT
								*
							INTO #tempCursosDre
							FROM
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.Email  FROM #tempCursosRegulares temp) AS Regulares
							UNION
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.Email FROM #tempCursosPrograma temp);

								-- 4.1) Paginacao
								IF OBJECT_ID('tempdb..#tempCursosDrePaginado') IS NOT NULL
									DROP TABLE #tempCursosDrePaginado
								SELECT
									*
								INTO #tempCursosDrePaginado
									from #tempCursosDre
							order by 1 ");

            if (ehParaPaginar)
                query.AppendLine("OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY;");
            else query.AppendLine(";");

            query.AppendLine(@"-- 5) Busca os responsáveis das UEs sem atribuição de aula para definir um criador do curso
							IF OBJECT_ID('tempdb..#tempUEsSemAtribuicao') IS NOT NULL
								DROP TABLE #tempUEsSemAtribuicao
							SELECT
								DISTINCT
								temp.cd_unidade_educacao
							INTO #tempUEsSemAtribuicao
							FROM
								#tempCursosDrePaginado temp
							WHERE
								Email IS NULL;

							IF EXISTS (SELECT TOP 1 1 FROM #tempUEsSemAtribuicao)
							BEGIN
								IF OBJECT_ID('tempdb..#ResponsaveisUe') IS NOT NULL
									DROP TABLE #ResponsaveisUe;
								CREATE TABLE #responsaveisUe
								(
									CodigoUe varchar(10) NOT NULL,
									Email varchar(MAX) NULL
								);

								INSERT INTO #responsaveisUe
								SELECT DISTINCT temp.cd_unidade_educacao, [dbo].[proc_gerar_email_funcionario](servsub.NomeServidor, servsub.CodigoRf) AS Email
								FROM
									#tempUEsSemAtribuicao temp
								CROSS APPLY
									[dbo].[proc_obter_nivel](null, temp.cd_unidade_educacao) servsub;

								UPDATE t1
									SET t1.Email = t2.Email
								FROM
									#tempCursosDrePaginado t1
								INNER JOIN
									#responsaveisUe t2
									ON t1.cd_unidade_educacao = t2.CodigoUe
								WHERE
									t1.Email IS NULL;
							END;

							SELECT
								temp.Nome,
								temp.Secao,
								temp.ComponenteCurricularId,
								temp.TurmaId,
								temp.cd_unidade_educacao as UeCodigo,
								temp.Email
							FROM
								#tempCursosDrePaginado temp;

					-- Totalizacao
						SELECT
							COUNT(*)
						FROM
							#tempCursosDre temp;");

			return query.ToString();
		}

		private static string MontaQueryGradesCursosParaInclusao(bool aplicarPaginacao, long? turmaId, long? componenteCurricularId)
		{
			var query = new StringBuilder();
			query.AppendLine(@"-- 2) Busca os cursos regulares
							IF OBJECT_ID('tempdb..#tempTurmasComponentesRegulares') IS NOT NULL 
								DROP TABLE #tempTurmasComponentesRegulares
							SELECT
								DISTINCT
								CASE
										WHEN etapa_ensino.cd_etapa_ensino IN( 1 )
									THEN 'REGÊNCIA DE CLASSE INFANTIL'
								ELSE
									iif(tgt.cd_serie_grade is not null, concat(LTRIM(RTRIM(ter.dc_territorio_saber)), ' - ',  LTRIM(RTRIM(tep.dc_experiencia_pedagogica))), 
									LTRIM(RTRIM(cc.dc_componente_curricular)))
								END Nome,
								CONCAT(CASE
										WHEN etapa_ensino.cd_etapa_ensino IN( 2, 3, 7, 11 )
									THEN 
									--eja  
									'EJA'
										WHEN etapa_ensino.cd_etapa_ensino IN ( 4, 5, 12, 13 )
									THEN 
									--fundamental     
									'EF'
										WHEN etapa_ensino.cd_etapa_ensino IN
											( 6, 7, 8, 9, 17, 14 ) THEN 
									--médio  
									'EM' 
									WHEN etapa_ensino.cd_etapa_ensino IN ( 1 )
										THEN 
									--infantil
									'EI'
									ELSE 'P'
									END, ' - ',  te.dc_turma_escola, ' - ', 
									te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ', LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao) Secao,
								CASE
									WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
								ELSE
									cc.cd_componente_curricular
								END ComponenteCurricularId,
								te.cd_turma_escola TurmaId,
								grade.cd_grade,
								serie_turma_grade.cd_serie_grade,
								ue.cd_unidade_educacao,
								serie_turma_grade.dt_inicio AS DataInicioGrade
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
							--- Território
							LEFT JOIN
								turma_grade_territorio_experiencia tgt (NOLOCK) 
								ON tgt.cd_serie_grade = serie_turma_grade.cd_serie_grade AND tgt.cd_componente_curricular = cc.cd_componente_curricular
							LEFT JOIN
								territorio_saber ter (NOLOCK) 
								ON ter.cd_territorio_saber = tgt.cd_territorio_saber 
							LEFT JOIN
								tipo_experiencia_pedagogica tep (NOLOCK) 
								ON tep.cd_experiencia_pedagogica = tgt.cd_experiencia_pedagogica
							--- Território
							WHERE  
								te.an_letivo = @anoLetivo
								AND	  te.st_turma_escola in ('O', 'A', 'C')
								AND   te.cd_tipo_turma in (1,2,3,5,6,7)
								AND   esc.tp_escola in (1,2,3,4,10,13,16,17,18,19,23,25,28,31)	
								AND   serie_turma_grade.dt_inicio >= @dataReferencia
								AND   (serie_turma_grade.dt_fim IS NULL OR serie_turma_grade.dt_fim >= GETDATE())");

			if (componenteCurricularId.HasValue)
			{
				if (componenteCurricularId.Value == 512)
				{
					query.AppendLine("AND etapa_ensino.cd_etapa_ensino = 1 ");
				}
				else query.AppendLine("AND cc.cd_componente_curricular = @componenteCurricularId ");
			}

			if (turmaId.HasValue)
			{
				query.AppendLine("AND te.cd_turma_escola = @turmaId");
			}

			query.AppendLine(@"--- 2.1) Busca as atribuições de aula para os professores de cada curso regular
							IF OBJECT_ID('tempdb..#tempTurmasComponentesRegularesProfessores') IS NOT NULL 
								DROP TABLE #tempTurmasComponentesRegularesProfessores
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email
							INTO #tempTurmasComponentesRegularesProfessores
							FROM
								#tempTurmasComponentesRegulares temp
							INNER JOIN
								atribuicao_aula atr (NOLOCK)
								ON atr.cd_grade = temp.cd_grade AND atr.cd_serie_grade = temp.cd_serie_grade AND atr.cd_componente_curricular = temp.ComponenteCurricularId
							INNER JOIN
								v_cargo_base_cotic cbc (NOLOCK)
								ON cbc.cd_cargo_base_servidor = atr.cd_cargo_base_servidor
							INNER JOIN
								v_servidor_cotic serv (NOLOCK)
								ON cbc.cd_servidor = serv.cd_servidor
							WHERE	
								atr.an_atribuicao = @anoLetivo
								AND atr.dt_cancelamento IS NULL
								AND atr.dt_disponibilizacao_aulas IS NULL;

							--- 2.2) Define a tabela final de cursos regulares com responsáveis
							IF OBJECT_ID('tempdb..#tempCursosRegulares') IS NOT NULL 
								DROP TABLE #tempCursosRegulares
							SELECT
								t1.*,
								t2.Email
							INTO #tempCursosRegulares
							FROM
								#tempTurmasComponentesRegulares t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM #tempTurmasComponentesRegularesProfessores temp WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2;

							-- 3) Busca os cursos de Programa
							IF OBJECT_ID('tempdb..#tempTurmasComponentesPrograma') IS NOT NULL 
								DROP TABLE #tempTurmasComponentesPrograma
							SELECT
								DISTINCT
								pcc.dc_componente_curricular Nome,
								CONCAT('P - ',  te.dc_turma_escola, ' - ', 
									te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ', LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao) Secao,
								pcc.cd_componente_curricular AS ComponenteCurricularId,
								te.cd_turma_escola TurmaId,
								pg.cd_grade,
								tegp.cd_turma_escola_grade_programa,
								ue.cd_unidade_educacao,
								tegp.dt_inicio AS DataInicioGrade
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
								AND   tegp.dt_inicio >= @dataReferencia
								AND   (tegp.dt_fim IS NULL OR tegp.dt_fim >= GETDATE())");

			if (componenteCurricularId.HasValue)
			{
				if (componenteCurricularId.Value != 512)
				{
					query.AppendLine("AND pcc.cd_componente_curricular = @componenteCurricularId ");
				}
			}

			if (turmaId.HasValue)
			{
				query.AppendLine("AND te.cd_turma_escola = @turmaId");
			}

			query.AppendLine(@"--- 3.1) Busca as atribuições de aula para os professores de cada curso de programa
							IF OBJECT_ID('tempdb..#tempTurmasComponentesProgramaProfessores') IS NOT NULL 
								DROP TABLE #tempTurmasComponentesProgramaProfessores
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email
							INTO #tempTurmasComponentesProgramaProfessores
							FROM
								#tempTurmasComponentesPrograma temp
							LEFT JOIN
								atribuicao_aula atr (NOLOCK)
								ON atr.cd_grade = temp.cd_grade AND atr.cd_turma_escola_grade_programa = temp.cd_turma_escola_grade_programa AND atr.cd_componente_curricular = temp.ComponenteCurricularId
							LEFT JOIN
								v_cargo_base_cotic cbc (NOLOCK)
								ON cbc.cd_cargo_base_servidor = atr.cd_cargo_base_servidor
							LEFT JOIN
								v_servidor_cotic serv (NOLOCK)
								ON cbc.cd_servidor = serv.cd_servidor
							WHERE	
								atr.an_atribuicao = @anoLetivo
								AND atr.dt_cancelamento IS NULL
								AND atr.dt_disponibilizacao_aulas IS NULL;

							--- 3.2) Define a tabela final de cursos de programa com responsáveis
							IF OBJECT_ID('tempdb..#tempCursosPrograma') IS NOT NULL 
								DROP TABLE #tempCursosPrograma
							SELECT
								t1.*,
								t2.Email
							INTO #tempCursosPrograma
							FROM
								#tempTurmasComponentesPrograma t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM #tempTurmasComponentesProgramaProfessores temp WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2;


							-- 4) Junta cursos regulares e turmas de programa
							IF OBJECT_ID('tempdb..#tempCursosDre') IS NOT NULL 
								DROP TABLE #tempCursosDre
							SELECT
								*
							INTO #tempCursosDre
							FROM
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.DataInicioGrade, temp.Email FROM #tempCursosRegulares temp) AS Regulares
							UNION
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.DataInicioGrade, temp.Email FROM #tempCursosPrograma temp);

							-- 4.1) Paginacao
							IF OBJECT_ID('tempdb..#tempCursosDrePaginado') IS NOT NULL 
								DROP TABLE #tempCursosDrePaginado
							SELECT
								*
							INTO #tempCursosDrePaginado
									from #tempCursosDre
							ORDER by 1 ");

			if (aplicarPaginacao)
				query.AppendLine("OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY;");
			else query.AppendLine(";");

			query.AppendLine(@"-- 5) Busca os responsáveis das UEs sem atribuição de aula para definir um criador do curso
							IF OBJECT_ID('tempdb..#tempUEsSemAtribuicao') IS NOT NULL 
								DROP TABLE #tempUEsSemAtribuicao
							SELECT
								DISTINCT
								temp.cd_unidade_educacao
							INTO #tempUEsSemAtribuicao
							FROM
								#tempCursosDrePaginado temp
							WHERE
								Email IS NULL;

							IF EXISTS (SELECT TOP 1 1 FROM #tempUEsSemAtribuicao)
							BEGIN
								IF OBJECT_ID('tempdb..#ResponsaveisUe') IS NOT NULL 
									DROP TABLE #ResponsaveisUe;
								CREATE TABLE #responsaveisUe
								(
									CodigoUe varchar(10) NOT NULL,
									Email varchar(MAX) NULL
								);

								INSERT INTO #responsaveisUe
								SELECT DISTINCT temp.cd_unidade_educacao, [dbo].[proc_gerar_email_funcionario](servsub.NomeServidor, servsub.CodigoRf) AS Email
								FROM 
									#tempUEsSemAtribuicao temp
								CROSS APPLY 
									[dbo].[proc_obter_nivel](null, temp.cd_unidade_educacao) servsub;

								UPDATE t1
									SET t1.Email = t2.Email
								FROM
									#tempCursosDrePaginado t1
								INNER JOIN
									#responsaveisUe t2
									ON t1.cd_unidade_educacao = t2.CodigoUe
								WHERE
									t1.Email IS NULL;
							END; 

							SELECT
								temp.Nome,
								temp.Secao,
								temp.ComponenteCurricularId,
								temp.TurmaId,
								temp.cd_unidade_educacao as UeCodigo,
								temp.DataInicioGrade,
								temp.Email
							FROM
								#tempCursosDrePaginado temp;

					-- Totalizacao
						SELECT
							COUNT(*)
						FROM
							#tempCursosDre temp;");

			return query.ToString();
		}
	}
}
