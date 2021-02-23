using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio.Enumerados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioExecucaoControle : IRepositorioExecucaoControle
    {
        private readonly ConnectionStrings connectionStrings;

        public RepositorioExecucaoControle(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }
        public async Task<bool> AtualizaControleExecucao(ExecucaoTipo execucaoTipo, DateTime data)
        {
            var query = @"UPDATE EXECUCAO_CONTROLE SET ULTIMA_EXECUCAO = @data WHERE EXECUCAO_TIPO = @execucaoTipo";
            var parametros = new { execucaoTipo, data };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            return await conn.ExecuteAsync(query, parametros) > 0;

        }
    }
}
