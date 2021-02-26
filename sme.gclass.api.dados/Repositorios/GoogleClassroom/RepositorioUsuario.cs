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
        private readonly ConnectionStrings connectionStrings;

        public RepositorioUsuario(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }
        public async Task<IEnumerable<UsuarioDto>> ObterFuncionarios()
        {
            var query = @" select id,
	                               usuario_tipo as UsuarioTipo,
	                               email,
	                               organization_path as OrganizationPath,
	                               data_inclusao as DataInclusao,
	                               data_atualizacao as DataAtualizacao
                              from usuarios 
                             where usuario_tipo = 3 ";

            using (var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom))
            {
                return await conn.QueryAsync<UsuarioDto>(query);
            }
        }
    }
}
