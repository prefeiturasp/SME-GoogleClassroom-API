using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioProfessorEol : RepositorioEol, IRepositorioProfessorEol
    {
        public RepositorioProfessorEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<ProfessorEol>> ObterProfessoresParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string rf)
        {
            using var conn = ObterConexao();

            var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
            var query = MontaQueryProfessorParaInclusao(aplicarPaginacao, rf);
            var parametros = new
            {
                anoLetivo = dataReferencia.Year,
                dataReferencia = dataReferencia.Date,
                paginacao.QuantidadeRegistros,
                paginacao.QuantidadeRegistrosIgnorados,
                rf
            };
            using var multi = await conn.QueryMultipleAsync(query, parametros);

            var retorno = new PaginacaoResultadoDto<ProfessorEol>();

            retorno.Items = multi.Read<ProfessorEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

        public async Task<IEnumerable<ProfessorCursoEol>> ObterCursosDoProfessorParaInclusaoAsync(long rf, int anoLetivo)
        {
            using var conn = ObterConexao();

            const string query = @"-- 1. Busca os cursos regulares do Professor
								IF OBJECT_ID('tempdb..#tempTurmasComponentesRegularesDoProfessor') IS NOT NULL 
									DROP TABLE #tempTurmasComponentesRegularesDoProfessor
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									te.cd_turma_escola TurmaId,
									CASE
										WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
									ELSE
										cc.cd_componente_curricular
									END ComponenteCurricularId
								INTO #tempTurmasComponentesRegularesDoProfessor
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
									AND	  serv.cd_registro_funcional = @rf;

								-- 2. Busca os cursos de programa do Professor
								IF OBJECT_ID('tempdb..#tempTurmasComponentesProgramaDoProfessor') IS NOT NULL 
									DROP TABLE #tempTurmasComponentesProgramaDoProfessor
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId
								INTO #tempTurmasComponentesProgramaDoProfessor
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
									AND	  serv.cd_registro_funcional = @rf;

								SELECT
									*
								FROM
									(SELECT * FROM #tempTurmasComponentesRegularesDoProfessor) AS Regulares
								UNION
									(SELECT * FROM #tempTurmasComponentesProgramaDoProfessor);";
			return await conn.QueryAsync<ProfessorCursoEol>(query, new { rf, anoLetivo });
		}

		public async Task<PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>> ObterAtribuicoesDeCursosDoProfessorAsync(DateTime dataReferencia, Paginacao paginacao, string rf, 
			long? turmaId, long? componenteCurricularId)
		{
			using var conn = ObterConexao();
			var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
			var query = MontaQueryAtribuicoesDeCursosDosProfessores(aplicarPaginacao, rf, turmaId, componenteCurricularId);

			var parametros = new
			{
				anoLetivo = dataReferencia.Year,
				dataReferencia = dataReferencia.Date,
				rf,
				turmaId,
				componenteCurricularId,
				paginacao.QuantidadeRegistros,
				paginacao.QuantidadeRegistrosIgnorados
			};

			using var multi = await conn.QueryMultipleAsync(query, parametros);
			var retorno = new PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>();

			retorno.Items = multi.Read<AtribuicaoProfessorCursoEol>();
			retorno.TotalRegistros = multi.ReadFirst<int>();
			retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

			return retorno;
		}

		private static string MontaQueryProfessorParaInclusao(bool aplicarPaginacao, string rf)
        {
            var queryBase = @$"IF OBJECT_ID('tempdb..#tempCargosProfessores') IS NOT NULL
	                                        DROP TABLE #tempCargosProfessores;
                                        SELECT
	                                        DISTINCT 
	                                        atr.cd_cargo_base_servidor
                                        INTO #tempCargosProfessores
                                        FROM
	                                        atribuicao_aula atr
                                        WHERE 
                                            an_atribuicao = @anoLetivo
                                            AND dt_atribuicao_aula > @dataReferencia
	                                        AND dt_cancelamento is null AND (dt_disponibilizacao_aulas is null OR dt_disponibilizacao_aulas > GETDATE());

                                        IF OBJECT_ID('tempdb..#tempProfessoresAtivos') IS NOT NULL
	                                        DROP TABLE #tempProfessoresAtivos;
                                        SELECT
	                                        DISTINCT
	                                        serv.cd_registro_funcional AS Rf,
	                                        serv.nm_pessoa AS NomePessoa,
                                            serv.nm_social AS NomeSocial,
	                                        'True' AS Ativo,
	                                        '/Professores' AS OrganizationPath
                                        INTO #tempProfessoresAtivos
                                        FROM
	                                        v_servidor_cotic serv (NOLOCK)
                                        INNER JOIN
	                                        v_cargo_base_cotic cbc (NOLOCK)
	                                        ON serv.cd_servidor = cbc.cd_servidor
                                        INNER JOIN
	                                        #tempCargosProfessores temp
	                                        ON cbc.cd_cargo_base_servidor = temp.cd_cargo_base_servidor
                                        {(!string.IsNullOrEmpty(rf) ? $"WHERE serv.cd_registro_funcional = @rf; " : "; ")}

                                           -- Resultado
                                        SELECT
	                                        *
                                        FROM
	                                        #tempProfessoresAtivos
                                        ORDER BY
	                                        Rf";

            var query = new StringBuilder(queryBase);
            if (aplicarPaginacao)
                query.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.Append(";");

            query.Append(@"SELECT COUNT(*)
                             FROM #tempProfessoresAtivos;");

            return query.ToString();
        }

		private static string MontaQueryAtribuicoesDeCursosDosProfessores(bool aplicarPaginacao, string rf, long? turmaId, long? componenteCurricularId)
        {
			const string queryBaseRegulares = @"-- 1. Busca atribuições dos cursos regulares
								IF OBJECT_ID('tempdb..#tempTurmasComponentesRegularesProfessores') IS NOT NULL 
									DROP TABLE #tempTurmasComponentesRegularesProfessores
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									te.cd_turma_escola TurmaId,
									CASE
										WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
									ELSE
										cc.cd_componente_curricular
									END ComponenteCurricularId
								INTO #tempTurmasComponentesRegularesProfessores
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
									AND	  atb_ser.dt_atribuicao_aula > @dataReferencia";

			const string queryBaseProgramas = @"-- 2. Busca os cursos de programa do Professor
								IF OBJECT_ID('tempdb..#tempTurmasComponentesProgramasProfessores') IS NOT NULL 
									DROP TABLE #tempTurmasComponentesProgramasProfessores
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId
								INTO #tempTurmasComponentesProgramasProfessores
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
									AND	  atb_pro.dt_atribuicao_aula > @dataReferencia";

			var queryRegulares = new StringBuilder(queryBaseRegulares);
			var queryProgramas = new StringBuilder(queryBaseProgramas);
			if (!string.IsNullOrWhiteSpace(rf))
			{
				queryRegulares.AppendLine("AND serv.cd_registro_funcional = @rf ");
				queryProgramas.AppendLine("AND serv.cd_registro_funcional = @rf ");
			}

			if(turmaId.HasValue)
            {
				queryRegulares.AppendLine("AND te.cd_turma_escola = @turmaId ");
				queryProgramas.AppendLine("AND te.cd_turma_escola = @turmaId ");
			}

			if (componenteCurricularId.HasValue)
            {
				queryRegulares.AppendLine("AND cc.cd_componente_curricular = @componenteCurricularId ");
				queryProgramas.AppendLine("AND cc.cd_componente_curricular = @componenteCurricularId ");
			}

			queryRegulares.Append(";");
			queryProgramas.Append(";");

			var query = $@"{queryRegulares} 
						   {queryProgramas}
                           SELECT
								*
							INTO #tempAtribuicoesProfessores
							FROM
								(SELECT * FROM #tempTurmasComponentesRegularesProfessores) AS Regulares
							UNION
								(SELECT * FROM #tempTurmasComponentesProgramasProfessores);

							SELECT
								*		
							FROM
								#tempAtribuicoesProfessores
							{(aplicarPaginacao ? " ORDER BY 1 OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY;" : ";")}

							SELECT
								COUNT(*)
							FROM
								#tempAtribuicoesProfessores;";

			return query;
		}
    }
}
