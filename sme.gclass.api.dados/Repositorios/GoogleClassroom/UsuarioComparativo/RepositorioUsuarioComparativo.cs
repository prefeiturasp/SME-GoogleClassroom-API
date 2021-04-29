using Dapper;
using SME.GoogleClassroom.Dominio;
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

        public async Task<bool> SalvarAsync(UsuarioComparativo usuarioComparativo)
        {
            const string insertQuery = @"insert into public.usuario_comparativo
                                        (id, nome, email, data_inclusao, data_ultimo_login, eh_admin, organization_path)
                                        values
                                        (@id, @nome, @email, @dataInclusao, @dataUltimoLogin, @EhAdmin, @OrganizationPath)
                                        RETURNING id";

            var parametros = new
            {
                usuarioComparativo.Id,
                usuarioComparativo.Nome,
                usuarioComparativo.Email,
                usuarioComparativo.DataInclusao,
                usuarioComparativo.DataUltimoLogin,
                usuarioComparativo.EhAdmin,
                usuarioComparativo.OrganizationPath,
            };

            using var conn = ObterConexao();
            await conn.ExecuteAsync(insertQuery, parametros);

            return true;
        }
    }
}
