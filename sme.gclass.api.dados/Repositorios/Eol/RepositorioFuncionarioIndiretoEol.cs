using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
	                p.nm_pessoa AS Nome,
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

            query.AppendLine("ORDER BY Nome");
            if (aplicarPaginacao)
                query.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY; ");

            query.AppendLine(@"
                SELECT
                    COUNT(*)
                FROM
                    #tempFuncionariosIndiretos;");

            return query.ToString();
        }
    }
}