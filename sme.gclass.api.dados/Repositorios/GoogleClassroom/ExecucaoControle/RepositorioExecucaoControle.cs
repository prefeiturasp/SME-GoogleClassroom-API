using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioExecucaoControle : RepositorioGoogle, IRepositorioExecucaoControle
    {
        public RepositorioExecucaoControle(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<bool> AtualizaControleExecucao(ExecucaoTipo execucaoTipo, DateTime data)
        {
            var query = @"UPDATE EXECUCAO_CONTROLE SET ULTIMA_EXECUCAO = @data WHERE EXECUCAO_TIPO = @execucaoTipo";
            var parametros = new { execucaoTipo, data };

            using var conn = ObterConexao();

            return await conn.ExecuteAsync(query, parametros) > 0;
        }

        public async Task<DateTime> ObterDataUltimaExecucaoPorTipo(ExecucaoTipo execucaoTipo)
        {
            var query = @"SELECT ULTIMA_EXECUCAO FROM EXECUCAO_CONTROLE WHERE EXECUCAO_TIPO = @execucaoTipo ORDER BY ULTIMA_EXECUCAO DESC LIMIT 1";
            var parametros = new { execucaoTipo };

            using var conn = ObterConexao();

            return await conn.QueryFirstOrDefaultAsync<DateTime>(query, parametros);
        }
    }
}