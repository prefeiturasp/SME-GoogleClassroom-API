using Dapper;
using SME.GoogleClassroom.Infra;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SME.GoogleClassrom.Dados
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioUsuario(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<UsuarioDto> BuscarRfEmailAsync(string login)
        {

            var query = @" SELECT  
                        cd_registro_funcional AS CodigoRf,
                        v_servidor_email_cotic.dc_dispositivo AS Email
                    FROM v_servidor_cotic
                    LEFT JOIN v_servidor_email_cotic
                        ON v_servidor_cotic.cd_servidor = v_servidor_email_cotic.cd_servidor
                    WHERE v_servidor_cotic.cd_registro_funcional = @login ";
            var parametros = new { login };

            using (var conn = new SqlConnection(ConnectionStrings.ConnectionStringEol))
            {
                return await conn.QueryFirstOrDefaultAsync<UsuarioDto>(query, parametros);
            }
        }
    }
}
