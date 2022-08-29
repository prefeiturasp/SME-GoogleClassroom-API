using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioConfiguracaoCelp : RepositorioGoogle, IRepositorioConfiguracaoCelp
    {
        public RepositorioConfiguracaoCelp(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<ConfiguracaoCelpDto>> ObterConfiguracaoInicial()
        {
            var query = @"select id, dre_id as DreCodigo, ue_id as UeCodigo, email from config_celp where ativo = true ";

            using var conn = ObterConexao();

            return await conn.QueryAsync<ConfiguracaoCelpDto>(query);
        }
    }
}
