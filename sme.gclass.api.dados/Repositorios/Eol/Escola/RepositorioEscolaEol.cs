using System.Threading.Tasks;
using Dapper;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Escola
{
    public class RepositorioEscolaEol : RepositorioEol, IRepositorioEscolaEol
    {
        public RepositorioEscolaEol(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<int> ObterTipoDaEscolaPorCodigoEscola(string codigoEscola)
        {
            var query = @"	select e.tp_escola as TipoEscola
                            from escola e 
                            inner join tipo_escola te on e.tp_escola = te.tp_escola 
                            where e.cd_escola = @codigoEscola ";

            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<int>(query, new
            {
                codigoEscola
            });
        }
    }
}