using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioComponenteCurricular : RepositorioSgp, IRepositorioComponenteCurricular
    {
        public RepositorioComponenteCurricular(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<bool> LancaNota(long componenteCurricularId)
        {
            var query = @"select permite_lancamento_nota from componente_curricular cc where id = @componenteCurricularId ";

            var parametros = new
            {
                componenteCurricularId
            };

            using var conn = ObterConexao();

            return (await conn.QueryFirstOrDefaultAsync<long>(query, parametros)) > 0;
        }
    }
}
