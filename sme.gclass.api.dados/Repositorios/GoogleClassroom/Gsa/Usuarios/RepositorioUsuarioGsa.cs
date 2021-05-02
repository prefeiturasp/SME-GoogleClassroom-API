using Dapper;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Dominio;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioGsa : RepositorioGoogle, IRepositorioUsuarioGsa
    {
        public RepositorioUsuarioGsa(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {

        }

        public async Task<bool> ExistePorIdAsync(string usuarioId)
        {
            var query = @"SELECT exists(SELECT 1 from public.usuarios_gsa where id = @usuarioId limit 1)";
            using var conn = ObterConexao();
            return (await conn.QuerySingleOrDefaultAsync<bool>(query, new { usuarioId }));
        }

        public async Task<int> ValidarUsuariosExistentesUsuariosComparativosAsync()
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
                    usuarios_gsa uc
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

        public async Task<PaginacaoResultadoDto<UsuarioGsa>> ObterUsuariosComparativosAsync(Paginacao paginacao, string nome, string email, string organizationPath)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterUsuariosComparativos(false, paginacao, nome, email, organizationPath));
            queryCompleta.AppendLine(MontaQueryObterUsuariosComparativos(false, paginacao, nome, email, organizationPath));

            var retorno = new PaginacaoResultadoDto<UsuarioGsa>();

            using var conn = ObterConexao();

            var parametros = new
            {
                paginacao,
                nome,
                email,
                organizationPath
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);

            retorno.Items = multi.Read<UsuarioGsa>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryObterUsuariosComparativos(bool ehParaPaginacao, Paginacao paginacao, string nome, string email, string organizationPath)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"UC.ID, 
                                  UC.NOME,
                                  UC.SECAO,
                                  UC.CRIADOR_ID AS CRIADORID,
                                  UC.DESCRICAO,
                                  UC.DATA_INCLUSAO AS DATAINCLUSAO,
                                  UC.INSERIDO_MANUALMENTE_GOOGLE AS INSERIDOMANUALMENTEGOOGLE");
            }

            queryCompleta.AppendLine(@"FROM usuarios_gsa UC");
            queryCompleta.AppendLine(@"WHERE 1=1");

            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.nome like('%" + nome?.Trim().ToLower() + "%')");

            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.email like('%" + email?.Trim().ToLower() + "%')");
            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.organization_path like('%" + organizationPath?.Trim().ToLower() + "%')");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }

        public async Task<bool> SalvarAsync(UsuarioGsa usuarioComparativo)
        {
            const string insertQuery = @"insert into public.usuarios_gsa
                                        (id, nome, email, data_inclusao, data_ultimo_login, eh_admin, organization_path, inserido_manualmente_google)
                                        values
                                        (@id, @nome, @email, @dataInclusao, @dataUltimoLogin, @EhAdmin, @OrganizationPath, @inseridoManualmenteGoogle)
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
                usuarioComparativo.InseridoManualmenteGoogle
            };

            using var conn = ObterConexao();
            await conn.ExecuteAsync(insertQuery, parametros);

            return true;
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM usuarios_gsa";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }
    }
}
