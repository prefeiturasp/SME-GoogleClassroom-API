using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioParametroSistema : RepositorioGoogle, IRepositorioParametroSistema
    {
        public RepositorioParametroSistema(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<ParametrosSistema> ObterParametroSistemaPorTipoEAno(TipoParametroSistema tipo, int ano)
        {
            const string query = @"
                        select
                            id,
                            nome,
                            tipo,
                            descricao,
                            valor,
                            ano,
                            ativo
                        from parametro_sistema
                        where tipo = @tipo
                            and ano = @ano";

            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<ParametrosSistema>(query, new { tipo, ano });
        }
    }
}