using Dapper;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioComparativo : RepositorioGoogle, IRepositorioUsuarioComparativo
    {
        public RepositorioUsuarioComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {

        }

        public async Task<int> ValidarCursosExistentesCursosComparativosAsync()
        {
            const string updateQuery = @"
               drop table if exists tempUsuariosValidacao;
                    select
                    u.id,
                    not uc.id is null as existe_google
                    into tempUsuariosValidacao
                    from
                    usuarios u
                    left join
                    usuario_comparativo uc
                    on cast(u.id as varchar) = uc.id;

                    update
                    usuarios c
                    set
                    existe_google = t1.existe_google
                    from
                    tempUsuariosValidacao t1
                    where
                    c.id = t1.id;";

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery);
        }
    }
}
