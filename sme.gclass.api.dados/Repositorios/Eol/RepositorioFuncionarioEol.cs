using Dapper;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Dados.Repositorios.Eol.Base;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Funcionarios;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Repositorios.Eol
{
    public class RepositorioFuncionarioEol : RepositorioEol, IRepositorioFuncionarioEol
    {
        public RepositorioFuncionarioEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<FuncionarioParaInclusaoDto>> ObterFuncionariosParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao)
        {
            const string queryObterFuncionariosParaInclusao = @"
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
					AND css.dt_nomeacao_cargo_sobreposto > @dataReferencia;
				GO

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

				-- 5.1 Paginação
				IF OBJECT_ID('tempdb..#tempCargosFuncionariosPaginados') IS NOT NULL
					DROP TABLE #tempCargosFuncionariosPaginados;
				SELECT
					*
				INTO #tempCargosFuncionariosPaginados
				FROM
					#tempCargosFuncionarios
				ORDER BY cd_servidor
				OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY;

				-- 6. Ajustar prioridade para funcionários com mais de um cargo
				IF OBJECT_ID('tempdb..#tempFuncionariosCargoPrioridade') IS NOT NULL
					DROP TABLE #tempFuncionariosCargoPrioridade;
				SELECT
					cd_servidor,
					MIN(prioridade) AS prioridade
				INTO #tempFuncionariosCargoPrioridade
				FROM
					#tempCargosFuncionariosPaginados
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
					SELECT TOP 1 * FROM #tempCargosFuncionariosPaginados temp WHERE temp.cd_servidor = t1.cd_servidor AND temp.prioridade = t1.prioridade
				) AS t2;

				-- 7. Final
				SELECT
					serv.cd_registro_funcional AS CdRegistroFuncional,
					[dbo].[proc_gerar_email_funcionario](serv.nm_pessoa, serv.cd_registro_funcional) AS Email,
					'True' AS Ativo,
					[dbo].[proc_gerar_unidade_organizacional_funcionario_v2](temp.cd_cargo, '') AS OrganizationPath,
					temp.cd_cargo AS CdCargo
				FROM
					v_servidor_cotic serv (NOLOCK)
				INNER JOIN
					#tempCargosFuncionariosRemovendoDuplicados temp
					ON temp.cd_servidor = serv.cd_servidor;
";

            using var conn = ObterConexao();
            using var multi = await conn.QueryMultipleAsync(queryObterFuncionariosParaInclusao,
                new
                {
                    dataReferencia.Date,
                    paginacao.QuantidadeRegistros,
                    paginacao.QuantidadeRegistrosIgnorados
                });

            var retorno = new PaginacaoResultadoDto<FuncionarioParaInclusaoDto>();

            retorno.Items = multi.Read<FuncionarioParaInclusaoDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
    }
}