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
        
        public async Task<IEnumerable<long>> ObterTurmasPorCodigoETipo(List<long> codigos, int tipo = 4)
        {

            var query = @"select te.cd_turma_escola from turma_escola te 
                          where
                                te.cd_tipo_turma = @tipoTurma and
                                te.cd_turma_escola in @CodigoTurmas;";
            
            using var conn = ObterConexao();
            return await conn.QueryAsync<long>(query, new
            {
                TipoTurma = tipo,
                CodigoTurmas = codigos
            });
        }
        
    }
}