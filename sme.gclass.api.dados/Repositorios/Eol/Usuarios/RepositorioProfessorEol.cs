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
    public class RepositorioProfessorEol : RepositorioEol, IRepositorioProfessorEol
    {
        public RepositorioProfessorEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<ProfessorEol>> ObterProfessoresParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string rf, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            using var conn = ObterConexao();

            var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
			var dataReferenciaAnoLetivo = parametrosCargaInicialDto.AnoLetivo.HasValue ? new DateTime(parametrosCargaInicialDto.AnoLetivo.Value, 1, 1) : dataReferencia;
            var query = MontaQueryProfessorParaInclusao(aplicarPaginacao, dataReferenciaAnoLetivo, rf, parametrosCargaInicialDto);
			var parametros = new
			{
				anoLetivo = dataReferencia.Year,
				dataReferencia = dataReferencia.Date,
				paginacao.QuantidadeRegistros,
				paginacao.QuantidadeRegistrosIgnorados,
				rf,
				TiposUes = parametrosCargaInicialDto.TiposUes,
				parametrosCargaInicialDto.Ues,
				parametrosCargaInicialDto.Turmas,
			};

            using var multi = await conn.QueryMultipleAsync(query, parametros);

            var retorno = new PaginacaoResultadoDto<ProfessorEol>();

            retorno.Items = multi.Read<ProfessorEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

		public async Task<ProfessorEol> ObterProfessorParaTratamentoDeErroAsync(long rf, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto)
		{
			var query = MontaQueryProfessorParaInclusao(false, null, rf.ToString(), parametrosCargaInicialDto);
			var parametros = new
			{
				anoLetivo = anoLetivo,
				rf
			};

			using var conn = ObterConexao();
			return await conn.QuerySingleOrDefaultAsync<ProfessorEol>(query, parametros);
		}

		public async Task<IEnumerable<ProfessorCursoEol>> ObterCursosDoProfessorParaInclusaoAsync(long rf, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            using var conn = ObterConexao();

			var query = new StringBuilder();

			query.AppendLine(@"-- 1. Busca os cursos regulares do Professor
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
									AND   te.an_letivo = @anoLetivo
									AND	  serv.cd_registro_funcional = @rf");

			query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
			query.Append(";");

			query.AppendLine(@"-- 2. Busca os cursos de programa do Professor
								IF OBJECT_ID('tempdb..#tempTurmasComponentesProgramaDoProfessor') IS NOT NULL
									DROP TABLE #tempTurmasComponentesProgramaDoProfessor
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId
								INTO #tempTurmasComponentesProgramaDoProfessor
								FROM
									turma_escola te(NOLOCK)
								INNER JOIN
									escola esc(NOLOCK)
									ON te.cd_escola = esc.cd_escola
								INNER JOIN
									v_cadastro_unidade_educacao ue(NOLOCK)
									ON ue.cd_unidade_educacao = esc.cd_escola
								INNER JOIN
									tipo_escola tpe(NOLOCK)
									ON esc.tp_escola = tpe.tp_escola
								INNER JOIN
									unidade_administrativa dre(NOLOCK)
									ON ue.cd_unidade_administrativa_referencia = dre.cd_unidade_administrativa
								INNER JOIN
									turma_escola_grade_programa tegp(NOLOCK)
									ON tegp.cd_turma_escola = te.cd_turma_escola AND tegp.dt_fim IS NULL
								INNER JOIN
									escola_grade teg(NOLOCK)
									ON teg.cd_escola_grade = tegp.cd_escola_grade
								INNER JOIN
									grade pg(NOLOCK) ON pg.cd_grade = teg.cd_grade
								INNER JOIN
									grade_componente_curricular pgcc(NOLOCK)
									ON pgcc.cd_grade = teg.cd_grade
								INNER JOIN
									componente_curricular pcc(NOLOCK)
									ON pgcc.cd_componente_curricular = pcc.cd_componente_curricular and pcc.dt_cancelamento is null
								-- Atribuicao turma programa
								INNER JOIN
									atribuicao_aula atb_pro(NOLOCK)
									ON pgcc.cd_grade = atb_pro.cd_grade
									AND pgcc.cd_componente_curricular = atb_pro.cd_componente_curricular
									AND atb_pro.cd_turma_escola_grade_programa = tegp.cd_turma_escola_grade_programa
									AND atb_pro.dt_cancelamento IS NULL
									AND atb_pro.dt_disponibilizacao_aulas IS NULL
									AND atb_pro.an_atribuicao = @anoLetivo
								-- Servidor
								INNER JOIN
									v_cargo_base_cotic vcbc(NOLOCK)
									ON atb_pro.cd_cargo_base_servidor = vcbc.cd_cargo_base_servidor AND vcbc.dt_cancelamento IS NULL AND vcbc.dt_fim_nomeacao IS NULL
								INNER JOIN
									v_servidor_cotic serv(NOLOCK)
									ON serv.cd_servidor = vcbc.cd_servidor
								WHERE
									te.st_turma_escola in ('O', 'A', 'C')
									AND   te.an_letivo = @anoLetivo
									AND   serv.cd_registro_funcional = @rf");

			query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
			query.Append(";");

			query.AppendLine(@"SELECT
									*
								FROM
									(SELECT * FROM #tempTurmasComponentesRegularesDoProfessor) AS Regulares
								UNION
									(SELECT * FROM #tempTurmasComponentesProgramaDoProfessor);");

            return await conn.QueryAsync<ProfessorCursoEol>(query.ToString(), new { 
				rf, 
				anoLetivo,
				TiposUes = parametrosCargaInicialDto.TiposUes,
				parametrosCargaInicialDto.Ues,
				parametrosCargaInicialDto.Turmas,
			});
        }

        public async Task<PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>> ObterAtribuicoesDeCursosDoProfessorAsync(DateTime dataReferencia, Paginacao paginacao, string rf,
            long? turmaId, long? componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            using var conn = ObterConexao();
            var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
            var query = MontaQueryAtribuicoesDeCursosDosProfessores(aplicarPaginacao, rf, turmaId, componenteCurricularId, parametrosCargaInicialDto);

            var parametros = new
            {
                anoLetivo = dataReferencia.Year,
                dataReferencia = dataReferencia.Date,
                rf,
                turmaId,
                componenteCurricularId,
                paginacao.QuantidadeRegistros,
                paginacao.QuantidadeRegistrosIgnorados,
                TiposUes = parametrosCargaInicialDto.TiposUes,
                parametrosCargaInicialDto.Ues,
                parametrosCargaInicialDto.Turmas,
            };

            using var multi = await conn.QueryMultipleAsync(query, parametros);
            var retorno = new PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>();

            retorno.Items = multi.Read<AtribuicaoProfessorCursoEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

        private static string MontaQueryProfessorParaInclusao(bool aplicarPaginacao, DateTime? dataReferencia, string rf, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
			var query = new StringBuilder();

			query.AppendLine(@$"IF OBJECT_ID('tempdb..#tempCargosProfessores') IS NOT NULL
	                                        DROP TABLE #tempCargosProfessores;
                                        SELECT
	                                        DISTINCT 
	                                        atr.cd_cargo_base_servidor
                                        INTO #tempCargosProfessores
                                        FROM
	                                        atribuicao_aula atr
                                        WHERE 
                                            an_atribuicao = @anoLetivo
											{(dataReferencia.HasValue && string.IsNullOrWhiteSpace(rf) ? "AND dt_atribuicao_aula >= @dataReferencia " : "")}
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
											lotacao_servidor ls (NOLOCK)
											ON ls.cd_cargo_base_servidor = cbc.cd_cargo_base_servidor
										INNER JOIN
											escola esc  (NOLOCK)
											ON ls.cd_unidade_educacao = esc.cd_escola
										INNER JOIN
											turma_escola te (NOLOCK)
											ON te.cd_escola = esc.cd_escola	
                                        INNER JOIN
	                                        #tempCargosProfessores temp
	                                        ON cbc.cd_cargo_base_servidor = temp.cd_cargo_base_servidor
										WHERE 1=1
											{(!string.IsNullOrEmpty(rf) ? $" AND serv.cd_registro_funcional = @rf " : " ")}");

			query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
			query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
			query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
			query.AppendLine(";");

			query.AppendLine(@"SELECT
	                            *
                            FROM
	                            #tempProfessoresAtivos
                            ORDER BY
	                            Rf; ");

			if (aplicarPaginacao)
                query.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY;");

            query.Append(@"SELECT COUNT(*)
                             FROM #tempProfessoresAtivos;");

            return query.ToString();
        }

        private static string MontaQueryAtribuicoesDeCursosDosProfessores(bool aplicarPaginacao, string rf, long? turmaId, long? componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
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
									END ComponenteCurricularId,
									te.cd_escola AS CdUe,
									atb_ser.dt_atribuicao_aula AS DataAtribuicao,
									etapa_ensino.cd_modalidade_ensino as Modalidade
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
									te.an_letivo = @anoLetivo
									AND	  atb_ser.dt_atribuicao_aula >= @dataReferencia ";

            const string queryBaseProgramas = @"-- 2. Busca os cursos de programa do Professor
								IF OBJECT_ID('tempdb..#tempTurmasComponentesProgramasProfessores') IS NOT NULL 
									DROP TABLE #tempTurmasComponentesProgramasProfessores
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId,
									te.cd_escola AS CdUe,
									atb_pro.dt_atribuicao_aula AS DataAtribuicao,
									0 as Modalidade
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
									te.an_letivo = @anoLetivo
									AND	  atb_pro.dt_atribuicao_aula >= @dataReferencia ";

            var queryRegulares = new StringBuilder(queryBaseRegulares);
            var queryProgramas = new StringBuilder(queryBaseProgramas);
            if (!string.IsNullOrWhiteSpace(rf))
            {
                queryRegulares.AppendLine("AND serv.cd_registro_funcional = @rf ");
                queryProgramas.AppendLine("AND serv.cd_registro_funcional = @rf ");
            }

            queryRegulares.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryRegulares.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryRegulares.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            
            queryProgramas.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryProgramas.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryProgramas.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

            
            if (turmaId.HasValue)
            {
                queryRegulares.AppendLine("AND te.cd_turma_escola = @turmaId ");
                queryProgramas.AppendLine("AND te.cd_turma_escola = @turmaId ");
            }

            if (componenteCurricularId.HasValue)
            {
                queryRegulares.AppendLine("AND atb_ser.cd_componente_curricular = @componenteCurricularId ");
                queryProgramas.AppendLine("AND pgcc.cd_componente_curricular = @componenteCurricularId ");
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

        public async Task<IEnumerable<RemoverAtribuicaoProfessorCursoEolDto>> ObterProfessoresParaRemoverCurso(string turmaId, DateTime dataInicio, DateTime dataFim)
        {
			var query = MontaQueryProfessorParaRemoverCurso(turmaId);

			using var conn = ObterConexao();
			  return await conn.QueryAsync<RemoverAtribuicaoProfessorCursoEolDto>(query, new { turmaId, dataInicio, dataFim });

		}

        private string MontaQueryProfessorParaRemoverCurso(string turmaId, bool contador = false, bool aplicarPaginacao = false)
        {
			var query = new StringBuilder();
			if (contador)
				query.AppendLine("select count(s.cd_registro_funcional)");
			else
				query.AppendLine(@"select te.cd_turma_escola as TurmaCodigo
							, aa.cd_componente_curricular as ComponenteCurricularCodigo
							, s.cd_registro_funcional as UsuarioRf
							, s.nm_pessoa as UsuarioNome
							, aa.dt_disponibilizacao_aulas as DataDisponibilizacao
							, aa.cd_motivo_disponibilizacao as MotivoDisponibilizacao ");

			query.AppendLine(@"from atribuicao_aula aa
						 inner join turma_escola te on 
								  aa.an_atribuicao = te.an_letivo 
							  AND aa.cd_unidade_educacao = te.cd_escola
						 inner join v_cargo_base_cotic cs on cs.cd_cargo_base_servidor = aa.cd_cargo_base_servidor 
						 inner join v_servidor_cotic s on s.cd_servidor = cs.cd_servidor
						  where aa.dt_disponibilizacao_aulas between @dataInicio and @dataFim
						  and aa.cd_motivo_disponibilizacao <> 34
						  and not exists(
  							select 1 
  							  from atribuicao_aula aa2 
  							 inner join turma_escola te2 on aa2.an_atribuicao = te2.an_letivo 
							 inner join v_cargo_base_cotic cs2 on cs2.cd_cargo_base_servidor = aa2.cd_cargo_base_servidor 
							 inner join v_servidor_cotic s2 on s2.cd_servidor = cs2.cd_servidor
							  AND aa2.cd_unidade_educacao = te2.cd_escola
  							 where s2.cd_registro_funcional = s.cd_registro_funcional 
  							   and te2.cd_turma_escola = te.cd_turma_escola 
  							   and aa2.cd_componente_curricular = aa.cd_componente_curricular 
  							   and aa2.dt_disponibilizacao_aulas is null
  							 )");

			if (!string.IsNullOrEmpty(turmaId))
				query.AppendLine(" and te.cd_turma_escola = @turmaId ");

			if (aplicarPaginacao)
				query.Append(" order by 1,2 OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

			query.AppendLine(";");
			return query.ToString();
		}

		public async Task<PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>> ObterProfessoresParaRemoverCursoPaginado(string turmaId, DateTime dataInicio, DateTime dataFim, Paginacao paginacao)
        {
            try
            {
				var query = new StringBuilder();
				query.AppendLine(MontaQueryProfessorParaRemoverCurso(turmaId, false, true));
				query.AppendLine(MontaQueryProfessorParaRemoverCurso(turmaId, true));

				var parametros = new
				{
					turmaId,
					dataInicio,
					dataFim,
					paginacao.QuantidadeRegistros,
					paginacao.QuantidadeRegistrosIgnorados
				};

				using var conn = ObterConexao();
				using var multi = await conn.QueryMultipleAsync(query.ToString(), parametros);
				var retorno = new PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>();

				retorno.Items = multi.Read<RemoverAtribuicaoProfessorCursoEolDto>();
				retorno.TotalRegistros = multi.ReadFirst<int>();
				retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

				return retorno;
			}
            catch (Exception ex)
            {
                throw ex;
            }

		}

        public async Task<IEnumerable<long>> ObterCodigosProfessoresInativosPorAnoLetivo(int anoLetivo, DateTime dataReferencia, string rf)
        {
			var query = new StringBuilder();
				query.AppendLine(@" SELECT distinct serv.cd_registro_funcional
									FROM v_servidor_cotic serv
									INNER JOIN v_cargo_base_cotic AS cba ON cba.CD_SERVIDOR = serv.cd_servidor
									INNER JOIN cargo AS car ON cba.cd_cargo = car.cd_cargo
									INNER JOIN lotacao_servidor AS ls
											   ON cba.cd_cargo_base_servidor = ls.cd_cargo_base_servidor
									WHERE cba.dt_fim_nomeacao <= CURRENT_TIMESTAMP-15
										AND serv.cd_registro_funcional NOT IN (SELECT 
											distinct serv.cd_registro_funcional
										 FROM v_servidor_cotic serv
											 INNER JOIN v_cargo_base_cotic AS cba ON cba.CD_SERVIDOR = serv.cd_servidor
											 INNER JOIN cargo AS car ON cba.cd_cargo = car.cd_cargo
											 INNER JOIN lotacao_servidor AS ls
														ON cba.cd_cargo_base_servidor = ls.cd_cargo_base_servidor
														WHERE cba.dt_fim_nomeacao IS NULL) ");

			if (!string.IsNullOrEmpty(rf))
				query.AppendLine(" and serv.cd_registro_funcional = @rf ");

			var parametros = new
			{
				anoLetivo = anoLetivo,
				rf
			};

			using var conn = ObterConexao();
			return await conn.QueryAsync<long>(query.ToString(), parametros);
		}

        public async Task<IEnumerable<string>> ObterProfessoresPorDreComponenteCurricularModalidade(string codigoDre, string componentesCurricularIds, string modalidadesIds, int[] tipoEscola, int anoLetivo, string anoTurma)
        {
			try
			{
				var query = new StringBuilder();
				query.AppendLine($@" SELECT DISTINCT servidor.cd_registro_funcional as ProfessorRf  
								FROM   turma_escola 
									   INNER JOIN escola esc 
											   ON turma_escola.cd_escola = esc.cd_escola 
									   INNER JOIN serie_turma_escola 
											   ON serie_turma_escola.cd_turma_escola = 
												  turma_escola.cd_turma_escola 
									   INNER JOIN serie_turma_grade 
											   ON serie_turma_grade.cd_turma_escola = 
												  serie_turma_escola.cd_turma_escola 
									   INNER JOIN escola_grade 
											   ON serie_turma_grade.cd_escola_grade = 
												  escola_grade.cd_escola_grade 
									   INNER JOIN grade 
											   ON escola_grade.cd_grade = grade.cd_grade 
									   INNER JOIN serie_ensino 
											   ON grade.cd_serie_ensino = serie_ensino.cd_serie_ensino 
									   INNER JOIN atribuicao_aula 
											   ON grade.cd_grade = atribuicao_aula.cd_grade 
												  AND an_atribuicao = turma_escola.an_letivo 
												  AND cd_unidade_educacao = turma_escola.cd_escola 
												  AND atribuicao_aula.cd_serie_grade = 
													  serie_turma_grade.cd_serie_grade 
												  AND atribuicao_aula.cd_grade = grade.cd_grade 
									   INNER JOIN componente_curricular 
											   ON atribuicao_aula.cd_componente_curricular = 
												  componente_curricular.cd_componente_curricular 
									   INNER JOIN v_cargo_base_cotic cargoServidor 
											   ON ( cargoServidor.cd_cargo_base_servidor = 
												  atribuicao_aula.cd_cargo_base_servidor ) 
									   INNER JOIN v_servidor_cotic servidor 
											   ON ( servidor.cd_servidor = cargoServidor.cd_servidor ) 
									   INNER JOIN cargo 
											   ON ( cargoServidor.cd_cargo = cargo.cd_cargo ) 
									   INNER JOIN v_cadastro_unidade_educacao escola 
											   ON escola.cd_unidade_educacao = turma_escola.cd_escola 
									   INNER JOIN v_cadastro_unidade_educacao dre 
											   ON dre.cd_unidade_educacao = 
												  escola.cd_unidade_administrativa_referencia 
									   INNER JOIN unidade_administrativa 
											   ON escola.cd_unidade_administrativa_referencia = 
															 unidade_administrativa.cd_unidade_administrativa 
												  AND tp_unidade_administrativa = 24 
									   INNER JOIN etapa_ensino 
											   ON serie_ensino.cd_etapa_ensino = etapa_ensino.cd_etapa_ensino 
									   INNER JOIN tipo_unidade_educacao tue ON dre.tp_unidade_educacao  = tue.tp_unidade_educacao
									   INNER JOIN tipo_escola ON esc.tp_escola = tipo_escola.tp_escola
							WHERE   atribuicao_aula.dt_cancelamento IS NULL 
								AND componente_curricular.dt_cancelamento IS NULL 								
								AND ( atribuicao_aula.dt_atribuicao_aula <= Getdate() ) 
								AND ( Getdate() <= COALESCE(Datepart(year, atribuicao_aula.dt_disponibilizacao_aulas), Getdate()) ) 
								and turma_escola.an_letivo = @anoLetivo 
								{IncluirCondicaoDre(codigoDre)}								
								and componente_curricular.cd_componente_curricular in (@componentesCurricularIds)
								AND etapa_ensino.cd_etapa_ensino in (@modalidadesIds )
								AND esc.tp_escola in (@tipoEscola)  
								{IncluirAnoTurma(anoTurma)}");

				var parametros = new { anoLetivo, codigoDre, componentesCurricularIds, modalidadesIds, tipoEscola = string.Join(',',tipoEscola), anoTurma };

				using var conn = ObterConexao();
				var retorno = await conn.QueryAsync<string>(query.ToString(), parametros);
				return retorno;
			}
			catch(Exception ex)
            {
				throw ex;
            }
		}

        private string IncluirCondicaoDre(string codigoDre)
        {
			return !string.IsNullOrEmpty(codigoDre) ? " and dre.cd_unidade_educacao = @codigoDre " : string.Empty;

		}

        private string IncluirAnoTurma(string anoTurma)
        {
			return !string.IsNullOrEmpty(anoTurma) ? " AND serie_ensino.sg_resumida_serie in (@alunoTurma) " : string.Empty;

		}
    }
}
