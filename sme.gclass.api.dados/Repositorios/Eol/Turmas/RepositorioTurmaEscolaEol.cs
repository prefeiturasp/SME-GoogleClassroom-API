using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Turmas
{
    public class RepositorioTurmaEscolaEol : RepositorioEol, IRepositorioTurmaEscolaEol
    {

        public RepositorioTurmaEscolaEol(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }
        
        public async Task<IEnumerable<long>> ObterTurmasPorCodigoETipo4e8(List<long> codigos)
        {

            var query = @"select te.cd_turma_escola from turma_escola te 
                          where
                                te.cd_tipo_turma in (4,8) and
                                te.cd_turma_escola in @CodigoTurmas;";
            
            using var conn = ObterConexao();
            return await conn.QueryAsync<long>(query, new
            {   
                CodigoTurmas = codigos
            });
        }
        
    }
}