using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
	public class RepositorioParametrosEol : RepositorioEol, IRepositorioParametrosEol
    {
		public RepositorioParametrosEol(ConnectionStrings connectionStrings)
			: base(connectionStrings)
		{
		}

        public async Task<ParametroAPIEol> ObterParametroAPIPorNome(string nome)
        {
            var query = @"select nome, valor from parametros 
                          where nome = @nome";

            using var conn = ObterConexaoApiEOL();
            return await conn.QueryFirstOrDefaultAsync<ParametroAPIEol>(query, new { nome });
        }
    }
}
