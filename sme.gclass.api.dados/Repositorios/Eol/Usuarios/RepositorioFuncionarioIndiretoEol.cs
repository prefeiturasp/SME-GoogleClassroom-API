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
    public class RepositorioFuncionarioIndiretoEol : RepositorioEol, IRepositorioFuncionarioIndiretoEol
    {
        public RepositorioFuncionarioIndiretoEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> ObterFuncionariosIndiretosParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string cpf)
        {
            using var conn = ObterConexao();

            var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
            var query = MontaQueryFuncionariosIndiretosParaInclusao(aplicarPaginacao, cpf);
            var parametros = new
            {
                dataReferencia = dataReferencia.Date,
                paginacao.QuantidadeRegistros,
                paginacao.QuantidadeRegistrosIgnorados,
                cpf
            };

            using var multi = await conn.QueryMultipleAsync(query, parametros);

            var retorno = new PaginacaoResultadoDto<FuncionarioIndiretoEol>();

            retorno.Items = multi.Read<FuncionarioIndiretoEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

        private static string MontaQueryFuncionariosIndiretosParaInclusao(bool aplicarPaginacao, string cpf)
        {
            var queryBase = @$"
                DECLARE @tipoEscola11 AS INT = 11;
                DECLARE @tipoEscola12 AS INT = 12;
                
                IF OBJECT_ID('tempdb..#tempFuncionariosIndiretos') IS NOT NULL
					DROP TABLE #tempFuncionariosIndiretos;
                SELECT
	                p.cd_cpf_pessoa AS Cpf,
	                p.nm_pessoa AS NomePessoa,
	                p.nm_social AS NomeSocial,
	                '/Professores/Conveniadas' AS OrganizationPath
                INTO #tempFuncionariosIndiretos
                FROM
	                contrato_externo ce (NOLOCK)
                INNER JOIN
	                pessoa p (NOLOCK)
	                ON ce.cd_pessoa = p.cd_pessoa
                INNER JOIN
	                escola e (NOLOCK)
	                ON ce.cd_unidade_educacao = e.cd_escola
                WHERE
	                ce.dt_inicio >= @dataReferencia
	                AND ce.dt_cancelamento IS NULL
	                AND e.tp_escola IN (@tipoEscola11, @tipoEscola12) ";

            var query = new StringBuilder(queryBase);
            if (!string.IsNullOrWhiteSpace(cpf))
                query.AppendLine("AND p.cd_cpf_pessoa = @cpf");

            query.AppendLine(@"
                SELECT
                    *
                FROM
                    #tempFuncionariosIndiretos ");

            query.AppendLine("ORDER BY NomePessoa");
            if (aplicarPaginacao)
                query.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY; ");

            query.AppendLine(@"
                SELECT
                    COUNT(*)
                FROM
                    #tempFuncionariosIndiretos;");

            return query.ToString();
        }

        //public Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> ObterFuncionariosIndiretosQueSeraoInativadosPaginados(Paginacao paginacao, string cpf)
        //{

        //   // var querySelectDados = @$" SELECT DISTINCT 
								//			//serv.cd_registro_funcional as rf,
								//			//serv.nm_pessoa as NomePessoa,
								//			//serv.nm_social as NomeSocial ";

        //   // var querySelectCount = "SELECT COUNT(DISTINCT serv.cd_registro_funcional) ";

        //   // var queryFrom = new StringBuilder(@$" FROM v_servidor_cotic serv
								//			//			INNER JOIN v_cargo_base_cotic AS cba ON cba.CD_SERVIDOR = serv.cd_servidor
								//			//			INNER JOIN cargo AS car ON cba.cd_cargo = car.cd_cargo
								//			//			INNER JOIN lotacao_servidor AS ls
								//			//						ON cba.cd_cargo_base_servidor = ls.cd_cargo_base_servidor
								//			//			WHERE cba.dt_fim_nomeacao <= @dataReferencia
								//			//				AND serv.cd_registro_funcional NOT IN(
								//			//					SELECT
								//			//						distinct serv.cd_registro_funcional
								//			//					FROM v_servidor_cotic serv
								//			//						INNER JOIN v_cargo_base_cotic AS cba ON cba.CD_SERVIDOR = serv.cd_servidor
								//			//						INNER JOIN cargo AS car ON cba.cd_cargo = car.cd_cargo
								//			//						INNER JOIN lotacao_servidor AS ls
								//			//					ON cba.cd_cargo_base_servidor = ls.cd_cargo_base_servidor
								//			//					WHERE cba.dt_fim_nomeacao IS NULL) ");

        //   // var queryPaginacao = @"ORDER BY serv.cd_registro_funcional offset @quantidadeRegistrosIgnorados rows fetch next @quantidadeRegistros rows only;";

        //   // var query = new StringBuilder(querySelectDados);
        //   // query.Append(queryFrom);
        //   // query.Append(queryPaginacao);
        //   // query.Append(querySelectCount);
        //   // query.Append(queryFrom);

        //   // using var conn = ObterConexao();
        //   // using var multi = await conn.QueryMultipleAsync(query.ToString(),
        //   //     new
        //   //     {
        //   //         quantidadeRegistros = paginacao.QuantidadeRegistros,
        //   //         quantidadeRegistrosIgnorados = paginacao.QuantidadeRegistrosIgnorados,
        //   //         cpf
        //   //     }, commandTimeout: 6000);

        //   // var retorno = new PaginacaoResultadoDto<FuncionarioIndiretoEol>
        //   // {
        //   //     Items = multi.Read<FuncionarioIndiretoEol>(),
        //   //     TotalRegistros = multi.ReadFirst<int>()
        //   // };

        //   // retorno.TotalPaginas = paginacao.QuantidadeRegistros > 0 ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;
        //   // return retorno;
        //}

        public async Task<IEnumerable<string>> ObterFuncionariosIndiretosQueSeraoInativados(string cpf)
        {
            var query = new StringBuilder();
            query.AppendLine(@" select 
	                                pe.cd_cpf_pessoa 
                                from contrato_externo ce
                                inner join pessoa pe on pe.cd_pessoa = ce.cd_pessoa
                                where 
	                                cd_motivo_desligamento_externo IS NOT NULL
                                and pe.cd_pessoa NOT IN (select 
							                                pe.cd_pessoa
						                                from contrato_externo ce
						                                inner join pessoa pe on pe.cd_pessoa = ce.cd_pessoa
						                                where 
							                                cd_motivo_desligamento_externo IS NULL) ");

            if (!string.IsNullOrEmpty(cpf))
                query.AppendLine(" and pe.cd_cpf_pessoa  = @cpf ");

            var parametros = new
            {
                cpf
            };

            using var conn = ObterConexao();
            return await conn.QueryAsync<string>(query.ToString(), parametros);
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> ObterFuncionariosIndiretosQueSeraoInativadosPaginados(Paginacao paginacao, string cpf)
        {
            var querySelectDados = @$"select 
	                                    distinct pe.cd_cpf_pessoa as cpf, 
	                                    pe.nm_pessoa as nomePessoa,
                                        '/Professores/Conveniadas' as organizationPath ";

            var querySelectCount = "SELECT COUNT(DISTINCT pe.cd_cpf_pessoa) ";

            var queryFrom = new StringBuilder(@$" from contrato_externo ce
                                inner join pessoa pe on pe.cd_pessoa = ce.cd_pessoa
                                where 
	                                cd_motivo_desligamento_externo IS NOT NULL
                                and pe.cd_pessoa NOT IN (select 
							                                pe.cd_pessoa
						                                from contrato_externo ce
						                                inner join pessoa pe on pe.cd_pessoa = ce.cd_pessoa
						                                where 
							                                cd_motivo_desligamento_externo IS NULL) ");

            if (!string.IsNullOrEmpty(cpf))
                queryFrom.AppendLine(" and pe.cd_cpf_pessoa = @cpf ");

            var queryPaginacao = @"ORDER BY pe.cd_cpf_pessoa offset @quantidadeRegistrosIgnorados rows fetch next @quantidadeRegistros rows only;";

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
                    cpf
                }, commandTimeout: 6000);

            var retorno = new PaginacaoResultadoDto<FuncionarioIndiretoEol>
            {
                Items = multi.Read<FuncionarioIndiretoEol>(),
                TotalRegistros = multi.ReadFirst<int>()
            };

            retorno.TotalPaginas = paginacao.QuantidadeRegistros > 0 ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;
            return retorno;
        }
    }
}