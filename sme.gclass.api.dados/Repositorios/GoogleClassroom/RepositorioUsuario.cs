using Dapper;
using Npgsql;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioUsuario(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<IEnumerable<UsuarioDto>> ObterAlunosAsync()
        {
            var query = @" SELECT  * FROM usuarios ";

            using (var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom))
            {
                return await conn.QueryAsync<UsuarioDto>(query);
            }
        }
    }
}
