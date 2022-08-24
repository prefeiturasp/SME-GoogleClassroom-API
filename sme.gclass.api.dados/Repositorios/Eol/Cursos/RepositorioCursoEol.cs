using Dapper;
using SME.GoogleClassroom.Dados.Help;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        private async Task<IEnumerable<int>> ObterTiposItinerarioMedio()
        {
            using (var conn = ObterConexaoApiEOL())
                return await conn.QueryAsync<int>("select Id from turma_tipo_itinerario");
        }

        public async Task<PaginacaoResultadoDto<CursoEol>> ObterCursosParaInclusao(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime? dataReferencia, int anoLetivo, Paginacao paginacao, long? componenteCurricularId, long? turmaId)
        {
            dataReferencia = dataReferencia?.Add(new TimeSpan(0, 0, 0));

            var tiposItinerarioMedio = await ObterTiposItinerarioMedio();

            var paginar = paginacao.QuantidadeRegistros > 0;
            var query = MontaQueryCursosParaInclusaoComPaginacao(parametrosCargaInicialDto, componenteCurricularId, turmaId);

            using var conn = ObterConexao();

            query = query.Replace("@tiposItinerarioMedio", string.Join(", ", tiposItinerarioMedio));
            query = query.Replace("@tiposEscola", string.Join(", ", parametrosCargaInicialDto.TiposUes));
            query = query.Replace("@ues", string.Join(", ", parametrosCargaInicialDto.Ues));
            query = query.Replace("@turmasId", string.Join(", ", parametrosCargaInicialDto.Turmas));

            var parametros = new
            {
                anoLetivo,
                pagina = paginacao.Pagina,
                quantidadeRegistros = paginacao.QuantidadeRegistros,
                componenteCurricularId,
                turmaId
            };

            var cursos = await conn.QueryAsync<CursoEol>(query, parametros, commandTimeout: 600);

            var retorno = new PaginacaoResultadoDto<CursoEol>();

            retorno.Items = cursos;
            retorno.TotalRegistros = cursos.Count();
            retorno.TotalPaginas =
                paginar ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;

        }

        public async Task<CursoEol> ObterCursoPorIdParaInclusao(long componenteCurricularId, long turmaId, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var paginar = false;
            var tiposItinerarioMedio = await ObterTiposItinerarioMedio();
            var query = MontaQueryCursosParaInclusao(parametrosCargaInicialDto, null, paginar, componenteCurricularId, turmaId, tiposItinerarioMedio);

            using var conn = ObterConexao();

            var parametros = new
            {
                componenteCurricularId,
                turmaId,
                anoLetivo,
                parametrosCargaInicialDto.TiposUes,
                parametrosCargaInicialDto.Ues,
                parametrosCargaInicialDto.Turmas
            };

            return await conn.QuerySingleOrDefaultAsync<CursoEol>(query, parametros, commandTimeout: 300);
        }

        public async Task<IEnumerable<ProfessorCursoEol>> ObterProfessoresDoCursoParaIncluirGoogleAsync(int anoLetivo, long turmaId, long componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var query = new StringBuilder(@"-- 1. Busca os cursos regulares do Professor
								with tempProfessoresDeTurmasComponentesRegulares as (
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									te.cd_turma_escola TurmaId,
									CASE
										WHEN etapa_ensino.cd_etapa_ensino = 1 THEN 512
									ELSE
										cc.cd_componente_curricular
									END ComponenteCurricularId
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
									AND   te.an_letivo = @anoLetivo
									AND	  te.cd_turma_escola = @turmaId
									AND   gcc.cd_componente_curricular = @componenteCurricularId 
			");

            query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

            query.AppendLine(@"--2. Busca os cursos de programa do Professor
								), tempProfessoresDeTurmasComponentesPrograma as (
								SELECT
									DISTINCT
									serv.cd_registro_funcional AS Rf,
									pcc.cd_componente_curricular AS ComponenteCurricularId,
									te.cd_turma_escola TurmaId
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
									AND   te.an_letivo = @anoLetivo
									AND	  te.cd_turma_escola = @turmaId
									AND   pgcc.cd_componente_curricular = @componenteCurricularId
			");

            query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

            query.AppendLine(@")
								SELECT
									*
								FROM
									(SELECT * FROM tempProfessoresDeTurmasComponentesRegulares) AS Regulares
								UNION
									(SELECT * FROM tempProfessoresDeTurmasComponentesPrograma);");

            using var conn = ObterConexao();
            return await conn.QueryAsync<ProfessorCursoEol>(query.ToString()
                , new
                {
                    turmaId,
                    componenteCurricularId,
                    anoLetivo,
                    parametrosCargaInicialDto.TiposUes,
                    parametrosCargaInicialDto.Ues,
                    parametrosCargaInicialDto.Turmas,
                });
        }

        public async Task<IEnumerable<AlunoCursoEol>> ObterAlunosDoCursoParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
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

            var sql = new StringBuilder(query);

            sql.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            sql.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            sql.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            sql.Append(";");


            return await conn.QueryAsync<AlunoCursoEol>(sql.ToString(),
                new
                {
                    turmaId,
                    componenteCurricularId,
                    anoLetivo,
                    parametrosCargaInicialDto.TiposUes,
                    parametrosCargaInicialDto.Ues,
                    parametrosCargaInicialDto.Turmas
                });
        }

        public async Task<PaginacaoResultadoDto<GradeCursoEol>> ObterGradesDeCursosAsync(DateTime dataReferencia, Paginacao paginacao, long? turmaId, long? componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            using var conn = ObterConexao();

            var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
            var query = MontaQueryGradesCursosParaInclusao(aplicarPaginacao, turmaId, componenteCurricularId, parametrosCargaInicialDto);
            var parametros = new
            {
                anoLetivo = dataReferencia.Year,
                dataReferencia = dataReferencia.Date,
                paginacao.QuantidadeRegistros,
                paginacao.QuantidadeRegistrosIgnorados,
                turmaId,
                componenteCurricularId,
                parametrosCargaInicialDto.TiposUes,
                parametrosCargaInicialDto.Ues,
                parametrosCargaInicialDto.Turmas
            };

            using var multi = await conn.QueryMultipleAsync(query, parametros, commandTimeout: 300);

            var retorno = new PaginacaoResultadoDto<GradeCursoEol>();

            retorno.Items = multi.Read<GradeCursoEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = aplicarPaginacao
                ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros)
                : 1;

            return retorno;
        }

        public async Task<IEnumerable<FuncionarioCursoEol>> ObterFuncionariosDoCursoCelpParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId)
        {
            using var conn = ObterConexao();

            var variaveis = ObterVariaveis();

            var queryBuscafuncionarioPorCargoFixo = ObterQueryBuscafuncionarioPorCargoFixo();

            var queryBuscafuncionarioPorCargoSobreposto = ObterQueryBuscafuncionarioPorCargoSobreposto();

            var queryBuscafuncionarioPorFuncao = ObterQueryBuscafuncionarioPorFuncao();

            var queryBuscafuncionarioPorCargoFixoStringBuilder = new StringBuilder(queryBuscafuncionarioPorCargoFixo);
            var queryBuscafuncionarioPorCargoSobrepostoStringBuilder = new StringBuilder(queryBuscafuncionarioPorCargoSobreposto);
            var queryBuscafuncionarioPorFuncaoStringBuilder = new StringBuilder(queryBuscafuncionarioPorFuncao);

            queryBuscafuncionarioPorCargoFixoStringBuilder.AppendLine($" AND esc.tp_escola = 27");
            queryBuscafuncionarioPorCargoFixoStringBuilder.AppendLine($" AND te.cd_turma_escola = @turmaId");
            queryBuscafuncionarioPorCargoFixoStringBuilder.Append("), ");
            
            queryBuscafuncionarioPorCargoSobrepostoStringBuilder.AppendLine($" AND esc.tp_escola = 27");
            queryBuscafuncionarioPorCargoSobrepostoStringBuilder.AppendLine($" AND te.cd_turma_escola = @turmaId");
            queryBuscafuncionarioPorCargoSobrepostoStringBuilder.Append("), ");

            queryBuscafuncionarioPorFuncaoStringBuilder.AppendLine($" AND esc.tp_escola = 27");
            queryBuscafuncionarioPorFuncaoStringBuilder.AppendLine($" AND te.cd_turma_escola = @turmaId");
            queryBuscafuncionarioPorFuncaoStringBuilder.Append("), ");

            var query = AdicionarQueryFuncionarioCargoSobrepostoFuncaoEVariaveis(variaveis, queryBuscafuncionarioPorCargoFixoStringBuilder, queryBuscafuncionarioPorCargoSobrepostoStringBuilder, queryBuscafuncionarioPorFuncaoStringBuilder);

            var retorno = await conn.QueryAsync<FuncionarioCursoEol>(query,
                new
                {
                    turmaId,
                    componenteCurricularId,
                    anoLetivo
                });

            return retorno;
        }

        private string ObterVariaveis()
        {
	        return @"DECLARE @cargoCP AS INT = 3379;
				DECLARE @cargoAD AS INT = 3085;
				DECLARE @cargoDiretor AS INT = 3360;
				DECLARE @tipoFuncaoPAP AS INT = 30;
				DECLARE @tipoFuncaoPAEE AS INT = 6;
				DECLARE @tipoFuncaoCIEJAASSISTPED AS INT = 42;
				DECLARE @tipoFuncaoCIEJAASSISTCOORD AS INT = 43;
				DECLARE @tipoFuncaoCIEJACOORD AS INT = 44;
				DECLARE @cdUe AS VARCHAR(20) = (SELECT cd_escola FROM turma_escola (NOLOCK) WHERE cd_turma_escola = @turmaId); ";
        }

        public async Task<IEnumerable<FuncionarioCursoEol>> ObterFuncionariosDoCursoParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            using var conn = ObterConexao();

            var variaveis = ObterVariaveis();

            var queryBuscafuncionarioPorCargoFixo = ObterQueryBuscafuncionarioPorCargoFixo();

            var queryBuscafuncionarioPorCargoSobreposto = ObterQueryBuscafuncionarioPorCargoSobreposto();

            var queryBuscafuncionarioPorFuncao = ObterQueryBuscafuncionarioPorFuncao();

            var queryBuscafuncionarioPorCargoFixoStringBuilder = new StringBuilder(queryBuscafuncionarioPorCargoFixo);
            var queryBuscafuncionarioPorCargoSobrepostoStringBuilder = new StringBuilder(queryBuscafuncionarioPorCargoSobreposto);
            var queryBuscafuncionarioPorFuncaoStringBuilder = new StringBuilder(queryBuscafuncionarioPorFuncao);

            queryBuscafuncionarioPorCargoFixoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuscafuncionarioPorCargoFixoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuscafuncionarioPorCargoFixoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuscafuncionarioPorCargoFixoStringBuilder.Append("), ");

            queryBuscafuncionarioPorCargoSobrepostoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuscafuncionarioPorCargoSobrepostoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuscafuncionarioPorCargoSobrepostoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuscafuncionarioPorCargoSobrepostoStringBuilder.Append("), ");

            queryBuscafuncionarioPorFuncaoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuscafuncionarioPorFuncaoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuscafuncionarioPorFuncaoStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryBuscafuncionarioPorFuncaoStringBuilder.Append("), ");

            var query = AdicionarQueryFuncionarioCargoSobrepostoFuncaoEVariaveis(variaveis, queryBuscafuncionarioPorCargoFixoStringBuilder, queryBuscafuncionarioPorCargoSobrepostoStringBuilder, queryBuscafuncionarioPorFuncaoStringBuilder);

            return await conn.QueryAsync<FuncionarioCursoEol>(query,
                new
                {
                    turmaId,
                    componenteCurricularId,
                    anoLetivo,
                    parametrosCargaInicialDto.TiposUes,
                    parametrosCargaInicialDto.Ues,
                    parametrosCargaInicialDto.Turmas
                });
        }

        private string AdicionarQueryFuncionarioCargoSobrepostoFuncaoEVariaveis(string variaveis, StringBuilder queryBuscafuncionarioPorCargoFixoStringBuilder, StringBuilder queryBuscafuncionarioPorCargoSobrepostoStringBuilder, StringBuilder queryBuscafuncionarioPorFuncaoStringBuilder)
        {
	        return $@" {variaveis}
							{queryBuscafuncionarioPorCargoFixoStringBuilder} 
						    {queryBuscafuncionarioPorCargoSobrepostoStringBuilder}
						    {queryBuscafuncionarioPorFuncaoStringBuilder}
				tempServidorCargos as (
				SELECT
					base.Rf,
					CASE
						WHEN NOT sobreposto.CdCagoFuncao IS NULL THEN sobreposto.CdCagoFuncao
						WHEN NOT funcao.CdCagoFuncao IS NULL THEN funcao.CdCagoFuncao
						ELSE base.CdCagoFuncao
					END AS CdCagoFuncao,
					CASE
						WHEN NOT sobreposto.CdUe IS NULL THEN sobreposto.CdUe
						WHEN NOT funcao.CdUe IS NULL THEN funcao.CdUe
						ELSE base.CdUe
					END AS CdUe
				FROM
					tempServidorCargosBase base
				LEFT JOIN
					tempServidorCargosSobrepostos sobreposto
					ON base.cd_cargo_base_servidor = sobreposto.cd_cargo_base_servidor
				LEFT JOIN
					tempServidorFuncao funcao
					ON base.cd_cargo_base_servidor = funcao.cd_cargo_base_servidor
				)

				SELECT
					temp.Rf,
					@turmaId AS TurmaId,
					@componenteCurricularId AS ComponenteCurricularId,
					temp.CdUe AS UeCodigo
				FROM
					tempServidorCargos temp
				WHERE
					temp.CdCagoFuncao IN (@cargoCP, @cargoAD, @cargoDiretor, @tipoFuncaoPAP, @tipoFuncaoPAEE, @tipoFuncaoCIEJAASSISTPED, @tipoFuncaoCIEJAASSISTCOORD, @tipoFuncaoCIEJACOORD)
					AND temp.CdUe = @cdUe;";
        }

        private string ObterQueryBuscafuncionarioPorFuncao()
        {
	        return @"
				-- 3. Busca os funcionários por função
				tempServidorFuncao as (
				SELECT
					serv.cd_registro_funcional AS Rf,
					esc.cd_escola AS CdUe,
					facs.cd_tipo_funcao AS CdCagoFuncao,
					cbc.cd_cargo_base_servidor
				FROM
					tempServidorCargosBase temp
				INNER JOIN
					v_cargo_base_cotic cbc (NOLOCK)
					ON temp.cd_cargo_base_servidor = cbc.cd_cargo_base_servidor
				INNER JOIN
					v_servidor_cotic serv (NOLOCK)
					ON serv.cd_servidor = cbc.cd_servidor
				INNER JOIN
					funcao_atividade_cargo_servidor facs (NOLOCK)
					ON cbc.cd_cargo_base_servidor = facs.cd_cargo_base_servidor
				INNER JOIN
					escola esc
					ON facs.cd_unidade_local_servico = esc.cd_escola
				WHERE
					(facs.dt_fim_funcao_atividade IS NULL OR facs.dt_fim_funcao_atividade > GETDATE())
					AND dt_fim_nomeacao IS NULL ";
        }

        private string ObterQueryBuscafuncionarioPorCargoSobreposto()
        {
	        return @"
				-- 2. Busca os funcionários por cargo sobreposto fixo
				tempServidorCargosSobrepostos as (
				SELECT
					serv.cd_registro_funcional AS Rf,
					css.cd_unidade_local_servico AS CdUe,
					css.cd_cargo AS CdCagoFuncao,
					cbc.cd_cargo_base_servidor
				FROM
					tempServidorCargosBase temp
				INNER JOIN
					v_cargo_base_cotic cbc (NOLOCK)
					ON temp.cd_cargo_base_servidor = cbc.cd_cargo_base_servidor
				INNER JOIN
					v_servidor_cotic serv (NOLOCK)
					ON serv.cd_servidor = cbc.cd_servidor
				INNER JOIN
					cargo_sobreposto_servidor css (NOLOCK)
					ON cbc.cd_cargo_base_servidor = css.cd_cargo_base_servidor
				INNER JOIN
					escola esc
					ON css.cd_unidade_local_servico = esc.cd_escola
				WHERE
					(css.dt_fim_cargo_sobreposto IS NULL OR css.dt_fim_cargo_sobreposto > GETDATE()) ";
        }

        private string ObterQueryBuscafuncionarioPorCargoFixo()
        {
	        return @"
				-- 1. Busca os funcionários por cargo fixo
				with tempServidorCargosBase as(
				SELECT
					serv.cd_registro_funcional AS Rf,
					esc.cd_escola AS CdUe,
					cbc.cd_cargo AS CdCagoFuncao,
					cbc.cd_cargo_base_servidor
				FROM
					v_servidor_cotic serv (NOLOCK)
				INNER JOIN
					v_cargo_base_cotic cbc (NOLOCK)
					ON serv.cd_servidor = cbc.cd_servidor
				INNER JOIN
					lotacao_servidor ls (NOLOCK)
					ON ls.cd_cargo_base_servidor = cbc.cd_cargo_base_servidor
				INNER JOIN
					escola esc
					ON ls.cd_unidade_educacao = esc.cd_escola
				WHERE
					dt_fim_nomeacao IS NULL
					AND (ls.dt_fim IS NULL OR ls.dt_fim > GETDATE()) ";
        }

        public async Task<bool> ExisteTurmaAtivaPorId(long turmaId)
        {
            using var conn = ObterConexao();

            const string query = @"select 1
								  	 from turma_escola te 
								 	where te.cd_turma_escola = @turmaId
								 	  and te.st_turma_escola in ('O', 'A')";

            return await conn.QueryFirstOrDefaultAsync<bool>(query, new { turmaId });
        }

        public async Task<IEnumerable<CursoExtintoEolDto>> ObterCursosExtintosPorPeriodo(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime dataInicio, DateTime dataFim, int anoLetivo, long? turmaId)
        {
            var query = MontaQueryCursosExtintos(turmaId, false, false, parametrosCargaInicialDto);

            using var conn = ObterConexao();
            return await conn.QueryAsync<CursoExtintoEolDto>(query, new
            {
                dataInicio,
                dataFim,
                anoLetivo,
                turmaId,
                parametrosCargaInicialDto.TiposUes,
                parametrosCargaInicialDto.Ues,
                parametrosCargaInicialDto.Turmas,
            });
        }

        public async Task<PaginacaoResultadoDto<CursoExtintoEolDto>> ObterCursosExtintosPorPeriodoPaginado(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime dataInicio, DateTime dataFim, int anoLetivo, long? turmaId, Paginacao paginacao)
        {
            var query = MontaQueryCursosExtintos(turmaId, true, false, parametrosCargaInicialDto);
            query += MontaQueryCursosExtintos(turmaId, false, true, parametrosCargaInicialDto);

            using var conn = ObterConexao();
            using var multi = await conn.QueryMultipleAsync(query,
                new
                {
                    dataInicio,
                    dataFim,
                    anoLetivo,
                    turmaId,
                    paginacao.QuantidadeRegistrosIgnorados,
                    paginacao.QuantidadeRegistros,
                    parametrosCargaInicialDto.TiposUes,
                    parametrosCargaInicialDto.Ues,
                    parametrosCargaInicialDto.Turmas,
                });

            var retorno = new PaginacaoResultadoDto<CursoExtintoEolDto>();

            retorno.Items = multi.Read<CursoExtintoEolDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryCursosParaArquivaPorAno(int anoLetivo, bool paginacao, bool contador, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var queryBuilder = new StringBuilder();

            queryBuilder.Append(contador ?
                "select count(*) " :
                @"select distinct
					cd_turma_escola as TurmaId ");

            queryBuilder.Append(@" from turma_escola te (NOLOCK)
							inner join escola esc (NOLOCK) ON te.cd_escola = esc.cd_escola
							where st_turma_escola = 'C' 								
								and an_letivo = @anoLetivo ");

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

            if (!contador)
                queryBuilder.Append(" order by cd_turma_escola ");

            if (paginacao)
                queryBuilder.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY");

            queryBuilder.Append(";");

            return queryBuilder.ToString();
        }

        public async Task<PaginacaoResultadoDto<CursoArquivarEolDto>> ObterCursosParaArquivarPorAnoPaginado(int anoLetivo, Paginacao paginacao, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var query = MontaQueryCursosParaArquivaPorAno(anoLetivo, true, false, parametrosCargaInicialDto);
            query += MontaQueryCursosParaArquivaPorAno(anoLetivo, false, false, parametrosCargaInicialDto);

            using var conn = ObterConexao();
            using var multi = await conn.QueryMultipleAsync(query, new
            {
                anoLetivo,
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                parametrosCargaInicialDto.TiposUes,
                parametrosCargaInicialDto.Ues,
                parametrosCargaInicialDto.Turmas,
            });

            var retorno = new PaginacaoResultadoDto<CursoArquivarEolDto>
            {
                Items = multi.Read<CursoArquivarEolDto>(),
                TotalRegistros = multi.ReadFirst<int>()
            };

            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<IEnumerable<CursoEolDto>> ObterTurmasConcluidasPorAnoLetivo(ParametrosCargaInicialDto parametrosCargaInicialDto, int anoLetivo, long? turmaId)
        {
            var query = @"	select 
								cd_turma_escola as TurmaId
							from turma_escola te (NOLOCK)
							inner join escola esc (NOLOCK) ON te.cd_escola = esc.cd_escola
							where st_turma_escola = 'C' 
							and an_letivo = @anoLetivo";

            if (turmaId.HasValue)
                query += " and te.cd_turma_escola = @turmaId ";

            var queryMainStringBuilder = new StringBuilder(query);

            queryMainStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryMainStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryMainStringBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));
            queryMainStringBuilder.Append(";");

            using var conn = ObterConexao();
            return await conn.QueryAsync<CursoEolDto>(queryMainStringBuilder.ToString(), new
            {
                anoLetivo,
                turmaId,
                parametrosCargaInicialDto.TiposUes,
                parametrosCargaInicialDto.Ues,
                parametrosCargaInicialDto.Turmas,
            });
        }

        private static string MontaQueryGradesCursosParaInclusao(bool aplicarPaginacao, long? turmaId, long? componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var query = new StringBuilder();
            query.AppendLine(@"-- 2) Busca os cursos regulares
							with tempTurmasComponentesRegulares as
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
								AND   serie_turma_grade.dt_inicio >= @dataReferencia
								AND   (serie_turma_grade.dt_fim IS NULL OR serie_turma_grade.dt_fim >= GETDATE())");

            query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

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
							), tempTurmasComponentesRegularesProfessores as (
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email
							FROM
								tempTurmasComponentesRegulares temp
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
								AND atr.dt_disponibilizacao_aulas IS NULL

							--- 2.2) Define a tabela final de cursos regulares com responsáveis
							), tempCursosRegulares as (
							SELECT
								t1.*,
								t2.Email
							FROM
								tempTurmasComponentesRegulares t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM #tempTurmasComponentesRegularesProfessores temp WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2

							-- 3) Busca os cursos de Programa
							), tempTurmasComponentesPrograma as (
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
								AND   tegp.dt_inicio >= @dataReferencia
								AND   (tegp.dt_fim IS NULL OR tegp.dt_fim >= GETDATE())");

            query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

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
							), tempTurmasComponentesProgramaProfessores as (
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email
							FROM
								tempTurmasComponentesPrograma temp
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
								AND atr.dt_disponibilizacao_aulas IS NULL

							--- 3.2) Define a tabela final de cursos de programa com responsáveis
							), tempCursosPrograma as (
							SELECT
								t1.*,
								t2.Email
							FROM
								tempTurmasComponentesPrograma t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM #tempTurmasComponentesProgramaProfessores temp WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2


							-- 4) Junta cursos regulares e turmas de programa
							), tempCursosDre as (
							SELECT
								*
							FROM
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.DataInicioGrade, temp.Email FROM #tempCursosRegulares temp) AS Regulares
							UNION
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.DataInicioGrade, temp.Email FROM #tempCursosPrograma temp)

							-- 4.1) Paginacao
							), tempCursosDrePaginado as (
							SELECT *
							 from tempCursosDre
							ORDER by 1 ");

            if (aplicarPaginacao)
                query.AppendLine(
                    "OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY;");
            else query.AppendLine(";");

            query.AppendLine(
                @"-- 5) Busca os responsáveis das UEs sem atribuição de aula para definir um criador do curso
							), tempUEsSemAtribuicao as (
							SELECT
								DISTINCT
								temp.cd_unidade_educacao
							FROM
								tempCursosDrePaginado temp
							WHERE
								Email IS NULL )

							IF EXISTS (SELECT TOP 1 1 FROM tempUEsSemAtribuicao)
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
									tempUEsSemAtribuicao temp
								CROSS APPLY 
									[dbo].[proc_obter_nivel](null, temp.cd_unidade_educacao) servsub;

								UPDATE t1
									SET t1.Email = t2.Email
								FROM
									tempCursosDrePaginado t1
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
								tempCursosDrePaginado temp;

					-- Totalizacao
						SELECT
							COUNT(*)
						FROM
							#tempCursosDre temp;");

            return query.ToString();
        }

        private string MontaQueryCursosExtintos(long? turmaId, bool paginacao, bool contador, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            var queryBuilder = new StringBuilder();

            queryBuilder.Append(contador
                                        ? "select count(*) "
                                        : @"select 
											cd_turma_escola as TurmaId, 
											dt_fim as DataExtincao ");

            queryBuilder.Append(@"from turma_escola te (NOLOCK)
				 inner join escola esc (NOLOCK) ON te.cd_escola = esc.cd_escola
					  where st_turma_escola in ('E', 'C')
						and an_letivo = @anoLetivo 
						and dt_fim between @dataInicio and @dataFim ");

            if (turmaId.HasValue)
                queryBuilder.Append(" and te.cd_turma_escola = @turmaId ");

            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            queryBuilder.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

            if (!contador)
                queryBuilder.Append(" order by dt_fim ");

            if (paginacao)
                queryBuilder.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            queryBuilder.Append("; ");

            return queryBuilder.ToString();
        }

        private static string MontaQueryCursosParaInclusao(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime? dataReferencia, bool ehParaPaginar, long? componenteCurricularId, long? turmaId, IEnumerable<int> tiposItinerarioMedio)
        {
            var query = new StringBuilder();
            query.AppendLine(@$"-- 2) Busca os cursos regulares
							with tempTurmasComponentesRegulares as (
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
										WHEN te.cd_tipo_turma in ({string.Join(',', tiposItinerarioMedio)})
											or etapa_ensino.cd_etapa_ensino IN ( 6, 7, 8, 9, 17, 14 ) THEN
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
								te.cd_tipo_turma TurmaTipo
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
								ON serie_turma_grade.cd_turma_escola = serie_turma_escola.cd_turma_escola 
								AND serie_turma_grade.dt_fim IS NULL
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
								{(dataReferencia != null ? "AND   te.dt_inicio_turma >= @dataReferencia" : "")}								
								AND   (serie_turma_grade.dt_fim IS NULL OR serie_turma_grade.dt_fim >= GETDATE())
                                AND te.cd_tipo_turma not in (4,8)");

            query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));

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

            query.AppendLine(@$"--- 2.1) Busca as atribuições de aula para os professores de cada curso regular
							), tempTurmasComponentesRegularesProfessores as (
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email
							FROM
								tempTurmasComponentesRegulares temp
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
								AND atr.dt_disponibilizacao_aulas IS NULL

							--- 2.2) Define a tabela final de cursos regulares com responsáveis
							), tempCursosRegulares as (
							SELECT
								t1.*,
								t2.Email
							FROM
								tempTurmasComponentesRegulares t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM tempTurmasComponentesRegularesProfessores temp 
									WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2

							-- 3) Busca os cursos de Programa
							), tempTurmasComponentesPrograma as (
							SELECT
								DISTINCT
								pcc.dc_componente_curricular Nome,
								CONCAT(
									CASE
										WHEN te.cd_tipo_turma in ({string.Join(',', tiposItinerarioMedio)}) 
										THEN 'EM - ' --médio
										ELSE 'P - '
									END,  te.dc_turma_escola, ' - ',
									te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ', LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao) Secao,
								pcc.cd_componente_curricular AS ComponenteCurricularId,
								te.cd_turma_escola TurmaId,
								pg.cd_grade,
								tegp.cd_turma_escola_grade_programa,
								ue.cd_unidade_educacao,
								te.cd_tipo_turma TurmaTipo
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
								AND	  te.st_turma_escola in ('O', 'A', 'C')
								{(dataReferencia != null ? "AND   te.dt_inicio_turma >= @dataReferencia" : "")}
								AND   (tegp.dt_fim IS NULL OR tegp.dt_fim >= GETDATE())
                                AND te.cd_tipo_turma not in (4,8)");

            query.AdicionarCondicaoIn(parametrosCargaInicialDto.TiposUes, "esc.tp_escola", nameof(parametrosCargaInicialDto.TiposUes));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Ues, "te.cd_escola", nameof(parametrosCargaInicialDto.Ues));
            query.AdicionarCondicaoIn(parametrosCargaInicialDto.Turmas, "te.cd_turma_escola", nameof(parametrosCargaInicialDto.Turmas));


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

            query.AppendLine(@$"--- 3.1) Busca as atribuições de aula para os professores de cada curso de programa
							), tempTurmasComponentesProgramaProfessores as (
							SELECT
								temp.TurmaId,
								temp.ComponenteCurricularId,
								[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email,
								temp.TurmaTipo
							FROM
								tempTurmasComponentesPrograma temp
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
								AND atr.dt_disponibilizacao_aulas IS NULL

							-- - 3.2) Define a tabela final de cursos de programa com responsáveis
							), tempCursosPrograma as (
							SELECT
								t1.*,
								t2.Email
							FROM
								tempTurmasComponentesPrograma t1
							OUTER APPLY
								(
									SELECT TOP 1 Email FROM tempTurmasComponentesProgramaProfessores temp WHERE temp.TurmaId = t1.TurmaId AND temp.ComponenteCurricularId = t1.ComponenteCurricularId
								) AS t2

							-- 4) Junta cursos regulares e turmas de programa
							), tempCursosDre as (
							SELECT
								*
							FROM
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.Email, temp.TurmaTipo  
								FROM tempCursosRegulares temp) AS Regulares
							UNION
								(SELECT temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.Email, temp.TurmaTipo 
								FROM tempCursosPrograma temp)

								-- 4.1) Paginacao
								), tempCursosDrePaginado as (
								SELECT
									temp.Nome, temp.Secao, temp.ComponenteCurricularId, temp.TurmaId, temp.cd_unidade_educacao, temp.TurmaTipo
									, coalesce(temp.email, [dbo].[proc_gerar_email_funcionario](servsub.NomeServidor, servsub.CodigoRf)) AS Email
									from tempCursosDre temp
									CROSS APPLY
									[dbo].[proc_obter_nivel](null, temp.cd_unidade_educacao) servsub");


            query.AppendLine(
                @"-- 5) Busca os responsáveis das UEs sem atribuição de aula para definir um criador do curso
							), tempResultadoFinalAgrupado as (
							
							SELECT
								temp.Nome,
								temp.Secao,
								max(temp.ComponenteCurricularId) as ComponenteCurricularId,
								temp.TurmaId,
								temp.cd_unidade_educacao as UeCodigo,
								temp.Email,
								temp.TurmaTipo
						    
							FROM
								tempCursosDrePaginado temp
							group by Nome, Secao, TurmaId, cd_unidade_educacao, Email, TurmaTipo
			)
			         
					 
					 select * from tempResultadoFinalAgrupado;");

            return query.ToString();
        }

        private static string MontaQueryCursosParaInclusaoComPaginacao(ParametrosCargaInicialDto parametrosCargaInicialDto, long? componenteCurricularId, long? turmaId)
        {
            var query = new StringBuilder();

            query.AppendLine("DECLARE @tmpListaCursosPaginada TABLE(Nome VARCHAR(1000),");
            query.AppendLine("									    Secao VARCHAR(1000),");
            query.AppendLine("									    ComponenteCurricularId INT,");
            query.AppendLine("									    TurmaId INT,");
            query.AppendLine("									    CodigoGrade INT,");
            query.AppendLine("									    CodigoSerieGrade INT,");
            query.AppendLine("									    CodigoUe CHAR(6),");
            query.AppendLine("									    TurmaTipo INT,");
            query.AppendLine("									    NomePessoa VARCHAR(500),");
            query.AppendLine("									    Rf CHAR(7))");
            query.AppendLine("INSERT INTO @tmpListaCursosPaginada");
            query.AppendLine("SELECT CASE");
            query.AppendLine("			WHEN ee.cd_etapa_ensino = 1 THEN 'REGÊNCIA DE CLASSE INFANTIL'");
            query.AppendLine("			ELSE IIF(tgte.cd_serie_grade IS NOT NULL, CONCAT(LTRIM(RTRIM(ts.dc_territorio_saber)), ' - ',  LTRIM(RTRIM(tep.dc_experiencia_pedagogica))), LTRIM(RTRIM(cc.dc_componente_curricular)))");
            query.AppendLine("		END Nome,");
            query.AppendLine("		CONCAT(CASE");
            query.AppendLine("	   			WHEN ee.cd_etapa_ensino IN(2, 3, 7, 11) THEN 'EJA'");
            query.AppendLine("	   			WHEN ee.cd_etapa_ensino IN(4, 5, 12, 13) THEN 'EF'");
            query.AppendLine("	   			WHEN te.cd_tipo_turma IN(@tiposItinerarioMedio) OR ee.cd_etapa_ensino IN(6, 7, 8, 9, 17, 14) THEN 'EM'");
            query.AppendLine("	   			WHEN ee.cd_etapa_ensino = 1 THEN 'EI'");
            query.AppendLine("	   			ELSE 'P'");
            query.AppendLine("	   		END, ' - ', te.dc_turma_escola, ' - ', te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ', LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao) Secao,");
            query.AppendLine("		MAX(CASE WHEN ee.cd_etapa_ensino = 1 THEN 512 ELSE cc.cd_componente_curricular END) ComponenteCurricularId,");
            query.AppendLine("		te.cd_turma_escola TurmaId,");
            query.AppendLine("		g.cd_grade,");
            query.AppendLine("		stg.cd_serie_grade,");
            query.AppendLine("		ue.cd_unidade_educacao,");
            query.AppendLine("		te.cd_tipo_turma TurmaTipo,");
            query.AppendLine("		sc.nm_pessoa,");
            query.AppendLine("		sc.cd_registro_funcional");
            query.AppendLine("	FROM turma_escola te(NOLOCK)");
            query.AppendLine("		INNER JOIN escola e(NOLOCK)");
            query.AppendLine("			ON te.cd_escola = e.cd_escola");
            query.AppendLine("		INNER JOIN v_cadastro_unidade_educacao ue(NOLOCK)");
            query.AppendLine("			ON ue.cd_unidade_educacao = e.cd_escola");
            query.AppendLine("		INNER JOIN tipo_escola tpe(NOLOCK)");
            query.AppendLine("			ON e.tp_escola = tpe.tp_escola");
            query.AppendLine("		INNER JOIN unidade_administrativa dre(NOLOCK)");
            query.AppendLine("			ON ue.cd_unidade_administrativa_referencia = dre.cd_unidade_administrativa");
            query.AppendLine("		INNER JOIN serie_turma_escola ste(NOLOCK)");
            query.AppendLine("			ON te.cd_turma_escola = ste.cd_turma_escola");
            query.AppendLine("		INNER JOIN serie_turma_grade stg(NOLOCK)");
            query.AppendLine("			ON ste.cd_turma_escola = stg.cd_turma_escola AND");
            query.AppendLine("				stg.dt_fim IS NULL");
            query.AppendLine("		INNER JOIN escola_grade eg(NOLOCK)");
            query.AppendLine("			ON stg.cd_escola_grade = eg.cd_escola_grade");
            query.AppendLine("		INNER JOIN grade g(NOLOCK)");
            query.AppendLine("			ON eg.cd_grade = g.cd_grade");
            query.AppendLine("		INNER JOIN grade_componente_curricular gcc(NOLOCK)");
            query.AppendLine("			ON g.cd_grade = gcc.cd_grade");
            query.AppendLine("		INNER JOIN componente_curricular cc(NOLOCK)");
            query.AppendLine("			ON gcc.cd_componente_curricular = cc.cd_componente_curricular AND");
            query.AppendLine("				cc.dt_cancelamento IS NULL");
            query.AppendLine("		INNER JOIN serie_ensino se(NOLOCK)");
            query.AppendLine("			ON g.cd_serie_ensino = se.cd_serie_ensino");
            query.AppendLine("		INNER JOIN etapa_ensino ee(NOLOCK)");
            query.AppendLine("			ON se.cd_etapa_ensino = ee.cd_etapa_ensino");
            query.AppendLine("		INNER JOIN atribuicao_aula aa(NOLOCK)");
            query.AppendLine("			ON g.cd_grade = aa.cd_grade AND");
            query.AppendLine("				stg.cd_serie_grade = aa.cd_serie_grade AND");
            query.AppendLine("				cc.cd_componente_curricular = aa.cd_componente_curricular");
            query.AppendLine("		INNER JOIN v_cargo_base_cotic cbc(NOLOCK)");
            query.AppendLine("			ON aa.cd_cargo_base_servidor = cbc.cd_cargo_base_servidor");
            query.AppendLine("		INNER JOIN v_servidor_cotic sc(NOLOCK)");
            query.AppendLine("			ON cbc.cd_servidor = sc.cd_servidor");
            query.AppendLine("		LEFT JOIN turma_grade_territorio_experiencia tgte(NOLOCK)");
            query.AppendLine("			ON stg.cd_serie_grade = tgte.cd_serie_grade AND");
            query.AppendLine("				cc.cd_componente_curricular = tgte.cd_componente_curricular");
            query.AppendLine("		LEFT JOIN territorio_saber ts(NOLOCK)");
            query.AppendLine("			ON tgte.cd_territorio_saber = ts.cd_territorio_saber");
            query.AppendLine("		LEFT JOIN tipo_experiencia_pedagogica tep(NOLOCK)");
            query.AppendLine("			ON tgte.cd_experiencia_pedagogica = tep.cd_experiencia_pedagogica");
            query.AppendLine("WHERE te.an_letivo = @anoLetivo AND");
            query.AppendLine("		te.st_turma_escola IN ('O', 'A', 'C') AND");
            query.AppendLine("		te.cd_tipo_turma NOT IN (4, 8) AND");
            query.AppendLine("		e.tp_escola IN(@tiposEscola) AND");
            query.AppendLine("		(stg.dt_fim IS NULL OR stg.dt_fim >= GETDATE()) AND");
            query.AppendLine("		aa.an_atribuicao = @anoLetivo AND");
            query.AppendLine("		aa.dt_cancelamento IS NULL AND");
            query.AppendLine("		aa.dt_disponibilizacao_aulas IS NULL");
            if (parametrosCargaInicialDto.Ues.Any())
                query.AppendLine("		AND e.cd_escola = ANY(@ues)");
            if (turmaId.HasValue)
                query.AppendLine("		AND ee.cd_turma_escola = @turmaId");
            else if (parametrosCargaInicialDto.Turmas.Any())
                query.AppendLine("		AND ee.cd_turma_escola IN(@turmasId)");
            if (componenteCurricularId.HasValue && componenteCurricularId.Value != 512)
                query.AppendLine("		AND cc.cd_componente_curricular = @componenteCurricularId");
            query.AppendLine("GROUP BY ee.cd_etapa_ensino,");
            query.AppendLine("		   tgte.cd_serie_grade,");
            query.AppendLine("		   ts.dc_territorio_saber,");
            query.AppendLine("		   tep.dc_experiencia_pedagogica,");
            query.AppendLine("		   cc.dc_componente_curricular,");
            query.AppendLine("		   ee.cd_etapa_ensino,");
            query.AppendLine("		   te.dc_turma_escola,");
            query.AppendLine("		   te.cd_turma_escola,");
            query.AppendLine("		   g.cd_grade,");
            query.AppendLine("		   stg.cd_serie_grade,");
            query.AppendLine("		   ue.cd_unidade_educacao,");
            query.AppendLine("		   tpe.sg_tp_escola,");
            query.AppendLine("		   ue.nm_unidade_educacao,");
            query.AppendLine("		   te.cd_tipo_turma,");
            query.AppendLine("		   sc.nm_pessoa,");
            query.AppendLine("		   sc.cd_registro_funcional");
            query.AppendLine("UNION");
            query.AppendLine("SELECT cc.dc_componente_curricular Nome,");
            query.AppendLine("	     CONCAT(");
            query.AppendLine("			CASE");
            query.AppendLine("				WHEN te.cd_tipo_turma IN(@tiposItinerarioMedio) THEN 'EM - '");
            query.AppendLine("		  		ELSE 'P - '");
            query.AppendLine("		  	END, te.dc_turma_escola, ' - ', te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ', LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao) Secao,");
            query.AppendLine("	     MAX(cc.cd_componente_curricular) ComponenteCurricularId,");
            query.AppendLine("	     te.cd_turma_escola TurmaId,");
            query.AppendLine("	     g.cd_grade,");
            query.AppendLine("	     tegp.cd_turma_escola_grade_programa,");
            query.AppendLine("	     ue.cd_unidade_educacao,");
            query.AppendLine("	     te.cd_tipo_turma TurmaTipo,");
            query.AppendLine("	     sc.nm_pessoa,");
            query.AppendLine("	     sc.cd_registro_funcional");
            query.AppendLine("	FROM turma_escola te(NOLOCK)");
            query.AppendLine("		INNER JOIN escola e(NOLOCK)");
            query.AppendLine("			ON te.cd_escola = e.cd_escola");
            query.AppendLine("		INNER JOIN v_cadastro_unidade_educacao ue(NOLOCK)");
            query.AppendLine("			ON e.cd_escola = ue.cd_unidade_educacao");
            query.AppendLine("		INNER JOIN tipo_escola tpe(NOLOCK)");
            query.AppendLine("			ON e.tp_escola = tpe.tp_escola");
            query.AppendLine("		INNER JOIN unidade_administrativa dre(NOLOCK)");
            query.AppendLine("			ON ue.cd_unidade_administrativa_referencia = dre.cd_unidade_administrativa");
            query.AppendLine("		INNER JOIN turma_escola_grade_programa tegp(NOLOCK)");
            query.AppendLine("			ON te.cd_turma_escola = tegp.cd_turma_escola");
            query.AppendLine("		INNER JOIN escola_grade eg(NOLOCK)");
            query.AppendLine("			ON tegp.cd_escola_grade = eg.cd_escola_grade");
            query.AppendLine("		INNER JOIN grade g(NOLOCK)");
            query.AppendLine("			ON eg.cd_grade = g.cd_grade");
            query.AppendLine("		INNER JOIN grade_componente_curricular gcc(NOLOCK)");
            query.AppendLine("			ON g.cd_grade = gcc.cd_grade");
            query.AppendLine("		INNER JOIN componente_curricular cc(NOLOCK)");
            query.AppendLine("			ON gcc.cd_componente_curricular = cc.cd_componente_curricular AND");
            query.AppendLine("			   cc.dt_cancelamento IS NULL");
            query.AppendLine("		LEFT JOIN atribuicao_aula aa(NOLOCK)");
            query.AppendLine("			ON g.cd_grade = aa.cd_grade AND");
            query.AppendLine("			   tegp.cd_turma_escola_grade_programa = aa.cd_turma_escola_grade_programa AND");
            query.AppendLine("			   cc.cd_componente_curricular = aa.cd_componente_curricular");
            query.AppendLine("		LEFT JOIN v_cargo_base_cotic cbc(NOLOCK)");
            query.AppendLine("			ON aa.cd_cargo_base_servidor = cbc.cd_cargo_base_servidor");
            query.AppendLine("		LEFT JOIN v_servidor_cotic sc(NOLOCK)");
            query.AppendLine("			ON cbc.cd_servidor = sc.cd_servidor");
            query.AppendLine("WHERE te.an_letivo = @anoLetivo AND");
            query.AppendLine("		te.st_turma_escola IN ('O', 'A', 'C') AND");
            query.AppendLine("		te.cd_tipo_turma NOT IN (4, 8) AND");
            query.AppendLine("		e.tp_escola IN (@tiposEscola) AND");
            query.AppendLine("		(tegp.dt_fim IS NULL OR tegp.dt_fim >= GETDATE()) AND");
            query.AppendLine("		aa.an_atribuicao = @anoLetivo AND");
            query.AppendLine("		aa.dt_cancelamento IS NULL AND");
            query.AppendLine("		aa.dt_disponibilizacao_aulas IS NULL");
            if (parametrosCargaInicialDto.Ues.Any())
                query.AppendLine("		AND e.cd_escola = ANY(@ues)");
            if (turmaId.HasValue)
                query.AppendLine("		AND ee.cd_turma_escola = @turmaId");
            else if (parametrosCargaInicialDto.Turmas.Any())
                query.AppendLine("		AND ee.cd_turma_escola IN(@turmasId)");
            if (componenteCurricularId.HasValue && componenteCurricularId.Value != 512)
                query.AppendLine("		AND cc.cd_componente_curricular = @componenteCurricularId");
            query.AppendLine("GROUP BY cc.dc_componente_curricular,");
            query.AppendLine("		   te.cd_tipo_turma,");
            query.AppendLine("		   te.dc_turma_escola,");
            query.AppendLine("		   te.cd_turma_escola,");
            query.AppendLine("		   ue.cd_unidade_educacao,");
            query.AppendLine("		   tpe.sg_tp_escola,");
            query.AppendLine("		   ue.nm_unidade_educacao,");
            query.AppendLine("		   te.cd_turma_escola,");
            query.AppendLine("		   g.cd_grade,");
            query.AppendLine("		   tegp.cd_turma_escola_grade_programa,");
            query.AppendLine("		   ue.cd_unidade_educacao,");
            query.AppendLine("		   te.cd_tipo_turma,");
            query.AppendLine("		   sc.nm_pessoa,");
            query.AppendLine("		   sc.cd_registro_funcional");
            query.AppendLine("ORDER BY te.cd_turma_escola");
            query.AppendLine("OFFSET(@pagina - 1) * @quantidadeRegistros ROWS");
            query.AppendLine("FETCH NEXT @quantidadeRegistros ROWS ONLY");
            query.AppendLine("SELECT Nome,");
            query.AppendLine("	     Secao,");
            query.AppendLine("	     ComponenteCurricularId,");
            query.AppendLine("	     TurmaId,");
            query.AppendLine("	     CodigoUe,");
            query.AppendLine("	     TurmaTipo,");
            query.AppendLine("	     dbo.proc_gerar_email_funcionario(NomePessoa, Rf) Email");
            query.AppendLine("	FROM @tmpListaCursosPaginada");

            return query.ToString();
        }
    }
}
