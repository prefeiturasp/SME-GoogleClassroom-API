using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioConectaFormacao : RepositorioConectaFormacaoBase, IRepositorioConectaFormacao
    {
        public RepositorioConectaFormacao(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<InscricaoConfirmadaDTO>> ListagemInscricoesConfirmadas(long codigoDaTurma)
        {
            var query = @" select   u.login codigoRf,
                                    u.cpf,
                                    u.nome,
                                    u.email,
                                    dre.abreviacao as dre 
                                    from inscricao i 
                                    join proposta_turma pt on i.proposta_turma_id = pt.id 
                                    join usuario u on u.id = i.usuario_id 
                                    join proposta_turma_dre ptd on ptd.proposta_turma_id = i.proposta_turma_id 
                                    join dre on dre.id = ptd.dre_id 
                                    where not u.excluido 
                                        and not u.excluido
                                        and not ptd.excluido
                                        and not dre.excluido
                                        and i.situacao = 1
                                        and i.proposta_turma_id = @codigoDaTurma";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<InscricaoConfirmadaDTO>(query, new {codigoDaTurma});
            }
        }
    }
}