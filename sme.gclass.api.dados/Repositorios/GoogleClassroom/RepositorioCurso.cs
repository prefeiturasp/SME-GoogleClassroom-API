using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCurso : IRepositorioCurso
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioCurso(ConnectionStrings connectionStrings)
        {
            ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<IEnumerable<CursoParaInclusaoDto>> ObterCursosParaInclusao(DateTime dataUltimaExecucao)
        {
            var query = @"";

            using (var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringEol))
            {
                return await conn.QueryAsync<CursoParaInclusaoDto>(query, new { dataUltimaExecucao });
            }
        }
    }
}
