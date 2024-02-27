using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa.FormacaoCidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Repositorios.Eol.Unidade
{
    public class RepositorioUnidade : RepositorioEol, IRepositorioUnidade
    {
        public RepositorioUnidade(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<UnidadeDto>> ObterUnidadesPorCodigos(string[] codigos)
        {
            using var conn = ObterConexao();

            var query = $@" SELECT vcue.cd_unidade_educacao Codigo, 
	                               vcue.nm_unidade_educacao Nome
                            FROM v_cadastro_unidade_educacao vcue (NOLOCK)
                            INNER JOIN unidade_administrativa ua on ua.cd_unidade_administrativa = vcue.cd_unidade_educacao
                            WHERE ua.tp_unidade_administrativa <> 24 and vcue.cd_unidade_educacao in @codigos";

            return await conn.QueryAsync<UnidadeDto>(query, new { codigos }, commandTimeout: 180);
        }
    }
}
