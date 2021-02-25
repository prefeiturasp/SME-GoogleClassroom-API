using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public async Task<IEnumerable<CursoParaInclusaoDto>> ObterCursosParaInclusao(DateTime dataReferencia)
        {
            var query = QueriesCursos.ObterCursosParaInclusao();

            using (var conn = new SqlConnection(ConnectionStrings.ConnectionStringEol))
            {
                return await conn.QueryAsync<CursoParaInclusaoDto>(query, new { dataReferencia });
            }
        }
    }
}
