using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioFuncionarioEol : RepositorioEol, IRepositorioFuncionarioEol
    {
        public RepositorioFuncionarioEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<FuncionarioEol>> ObterFuncionariosParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string rf)
        {
            using var conn = ObterConexao();

			var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
			var query = MontaQueryCursosParaInclusao(aplicarPaginacao, rf);
			var parametros = new
			{
				dataReferencia = dataReferencia.Date,
				paginacao.QuantidadeRegistros,
				paginacao.QuantidadeRegistrosIgnorados,
				rf
			};

			using var multi = await conn.QueryMultipleAsync(query, parametros);

            var retorno = new PaginacaoResultadoDto<FuncionarioEol>();

            retorno.Items = multi.Read<FuncionarioEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

		private static string MontaQueryCursosParaInclusao(bool aplicarPaginacao, string rf)
        {
			string queryBase = @$"
                DECLARE @cargoCP AS INT = 3379;
				DECLARE @cargoAD AS INT = 3085;
				DECLARE @cargoDiretor AS INT = 3360;
				DECLARE @cargoSupervisor AS INT = 3352;
				DECLARE @cargoSupervisorTecnico433 AS INT = 433;
				DECLARE @cargoSupervisorTecnico434 AS INT = 434;
				DECLARE @cargoATE AS INT = 4906;
				DECLARE @cargoAuxDesenvolvimentoInfantil AS INT = (SELECT cd_cargo FROM cargo (NOLOCK) WHERE dc_cargo = 'AUXILIAR DE DESENVOLVIMENTO INFANTIL');

				-- Cargos base Fixos
				IF OBJECT_ID('tempdb..#tempCargosBaseFuncionarios_Fixos') IS NOT NULL
					DROP TABLE #tempCargosBaseFuncionarios_Fixos;
				SELECT
					cbc.cd_cargo_base_servidor,
					cbc.cd_servidor,
					cbc.cd_cargo,
					CASE
						WHEN cbc.cd_cargo = @cargoSupervisorTecnico433 OR cbc.cd_cargo = @cargoSupervisorTecnico434 THEN 1
						WHEN cbc.cd_cargo = @cargoSupervisor THEN 2
						WHEN cbc.cd_cargo = @cargoDiretor THEN 3
						WHEN cbc.cd_cargo = @cargoAD THEN 4
						WHEN cbc.cd_cargo = @cargoCP THEN 5
						WHEN cbc.cd_cargo = @cargoATE THEN 8
						WHEN cbc.cd_cargo = @cargoAuxDesenvolvimentoInfantil THEN 9
					END AS prioridade
				INTO #tempCargosBaseFuncionarios_Fixos
				FROM
					v_cargo_base_cotic cbc (NOLOCK)
				WHERE
					cbc.cd_cargo IN (@cargoCP, @cargoAD, @cargoDiretor, @cargoSupervisor, @cargoSupervisorTecnico433, @cargoSupervisorTecnico434, @cargoATE, @cargoAuxDesenvolvimentoInfantil)
					AND (dt_fim_nomeacao IS NULL OR dt_fim_nomeacao > GETDATE())
					AND cbc.dt_nomeacao > @dataReferencia;

				-- 2. Cargos sobrepostos fixos
				IF OBJECT_ID('tempdb..#tempCargosSobrepostosFuncionarios_Fixos') IS NOT NULL
					DROP TABLE #tempCargosSobrepostosFuncionarios_Fixos;
				SELECT
					css.cd_cargo_base_servidor,
					cbc.cd_servidor,
					css.cd_cargo,
					CASE
						WHEN css.cd_cargo = @cargoSupervisorTecnico433 OR css.cd_cargo = @cargoSupervisorTecnico434 THEN 1
						WHEN css.cd_cargo = @cargoSupervisor THEN 2
						WHEN css.cd_cargo = @cargoDiretor THEN 3
						WHEN css.cd_cargo = @cargoAD THEN 4
						WHEN css.cd_cargo = @cargoCP THEN 5
						WHEN css.cd_cargo = @cargoATE THEN 8
						WHEN css.cd_cargo = @cargoAuxDesenvolvimentoInfantil THEN 9
					END AS prioridade
				INTO #tempCargosSobrepostosFuncionarios_Fixos
				FROM
					v_servidor_cotic serv (NOLOCK)
				INNER JOIN
					v_cargo_base_cotic cbc (NOLOCK)
					ON serv.cd_servidor = cbc.cd_servidor
				INNER JOIN
					cargo_sobreposto_servidor css (NOLOCK)
					ON cbc.cd_cargo_base_servidor = css.cd_cargo_base_servidor
				WHERE
					css.cd_cargo IN (@cargoCP, @cargoAD, @cargoDiretor, @cargoSupervisor, @cargoSupervisorTecnico433, @cargoSupervisorTecnico434, @cargoATE, @cargoAuxDesenvolvimentoInfantil)
					AND (css.dt_fim_cargo_sobreposto IS NULL OR css.dt_fim_cargo_sobreposto > GETDATE())
					AND css.dt_nomeacao_cargo_sobreposto > @dataReferencia
					{(!string.IsNullOrEmpty(rf) ? $"AND serv.cd_registro_funcional = @rf;" : ";")}

				-- 3. União das tabelas de cargo fixo
				IF OBJECT_ID('tempdb..#tempCargosFuncionarios_Fixos') IS NOT NULL
					DROP TABLE #tempCargosFuncionarios_Fixos;

				SELECT
					*
				INTO #tempCargosFuncionarios_Fixos
				FROM
					(SELECT * FROM #tempCargosSobrepostosFuncionarios_Fixos) AS sobrepostos
				UNION
					(SELECT * FROM #tempCargosBaseFuncionarios_Fixos
						WHERE NOT cd_cargo_base_servidor IN (SELECT DISTINCT cd_cargo_base_servidor FROM #tempCargosSobrepostosFuncionarios_Fixos));

				-- 4. Funções específicas ativas
				DECLARE @tipoFuncaoPAP AS INT = 30;
				DECLARE @tipoFuncaoPAEE AS INT = 6;
				DECLARE @tipoFuncaoCIEJAASSISTPED AS INT = 42;
				DECLARE @tipoFuncaoCIEJAASSISTCOORD AS INT = 43;
				DECLARE @tipoFuncaoCIEJACOORD AS INT = 44;

				IF OBJECT_ID('tempdb..#tempProfessores_PAP_PAEE_CIEJA') IS NOT NULL
					DROP TABLE #tempProfessores_PAP_PAEE_CIEJA;
				SELECT
					cbc.cd_cargo_base_servidor,
					cbc.cd_servidor,
					cbc.cd_cargo,
					CASE
						WHEN facs.cd_tipo_funcao = @tipoFuncaoPAP THEN 6
						WHEN facs.cd_tipo_funcao = @tipoFuncaoPAEE THEN 7
						ELSE 10
					END AS prioridade
				INTO #tempProfessores_PAP_PAEE_CIEJA
				FROM
					v_cargo_base_cotic cbc (NOLOCK)
				INNER JOIN
					funcao_atividade_cargo_servidor facs (NOLOCK)
					ON cbc.cd_cargo_base_servidor = facs.cd_cargo_base_servidor
				WHERE
					facs.cd_tipo_funcao IN (@tipoFuncaoPAP, @tipoFuncaoPAEE, @tipoFuncaoCIEJAASSISTPED, @tipoFuncaoCIEJAASSISTCOORD, @tipoFuncaoCIEJACOORD)
					AND (facs.dt_fim_funcao_atividade IS NULL OR facs.dt_fim_funcao_atividade > GETDATE())
					AND dt_fim_nomeacao IS NULL
					AND facs.dt_designacao > @dataReferencia;

				-- 5. União das tabelas de cargo fixo e função
				IF OBJECT_ID('tempdb..#tempCargosFuncionarios') IS NOT NULL
					DROP TABLE #tempCargosFuncionarios;
				SELECT
					*
				INTO #tempCargosFuncionarios
				FROM
					(SELECT * FROM #tempCargosFuncionarios_Fixos) AS fixos
				UNION
					(SELECT * FROM #tempProfessores_PAP_PAEE_CIEJA);

				-- 6. Ajustar prioridade para funcionários com mais de um cargo
				IF OBJECT_ID('tempdb..#tempFuncionariosCargoPrioridade') IS NOT NULL
					DROP TABLE #tempFuncionariosCargoPrioridade;
				SELECT
					cd_servidor,
					MIN(prioridade) AS prioridade
				INTO #tempFuncionariosCargoPrioridade
				FROM
					#tempCargosFuncionarios
				GROUP BY
					cd_servidor;

				IF OBJECT_ID('tempdb..#tempCargosFuncionariosRemovendoDuplicados') IS NOT NULL
					DROP TABLE #tempCargosFuncionariosRemovendoDuplicados;
				SELECT
					DISTINCT
					t2.cd_cargo,
					t1.cd_servidor
				INTO #tempCargosFuncionariosRemovendoDuplicados
				FROM
					#tempFuncionariosCargoPrioridade t1
				CROSS APPLY
				(
					SELECT TOP 1 * FROM #tempCargosFuncionarios temp WHERE temp.cd_servidor = t1.cd_servidor AND temp.prioridade = t1.prioridade
				) AS t2; 

				IF OBJECT_ID('tempdb..#tempCargosFuncionariosRemovendoDuplicadosFinal') IS NOT NULL
					DROP TABLE #tempCargosFuncionariosRemovendoDuplicadosFinal;
				SELECT
					*
				INTO #tempCargosFuncionariosRemovendoDuplicadosFinal
				FROM
					#tempCargosFuncionariosRemovendoDuplicados
				ORDER BY cd_servidor";

			var query = new StringBuilder(queryBase);
			if (aplicarPaginacao)
				query.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY; ");

			query.Append(@$"
				SELECT
					serv.cd_registro_funcional AS Rf,
					serv.nm_pessoa AS NomePessoa,
					serv.nm_social AS NomeSocial,
					'True' AS Ativo,
					[dbo].[proc_gerar_unidade_organizacional_funcionario_v2](temp.cd_cargo, '') AS OrganizationPath
				FROM
					v_servidor_cotic serv (NOLOCK)
				INNER JOIN
					#tempCargosFuncionariosRemovendoDuplicadosFinal temp
					ON temp.cd_servidor = serv.cd_servidor
				{(!string.IsNullOrEmpty(rf) ? $"WHERE serv.cd_registro_funcional = @rf; " : "; ")}

				SELECT
					COUNT(*)
				FROM
					#tempCargosFuncionariosRemovendoDuplicados temp;");

			return query.ToString();

		}

	}
}