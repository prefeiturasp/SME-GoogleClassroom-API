using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioConectaFormacao : RepositorioConectaFormacaoBase, IRepositorioConectaFormacao
    {
        private const int SituacaoPublicada = 1;
        
        public RepositorioConectaFormacao(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<InscricaoConfirmadaDTO>> ListagemInscricoesConfirmadas(long codigoDaTurma)
        {
            var query = @" select   u.login codigoRf,
                                    u.cpf,
                                    u.nome,
                                    u.email
                                    from inscricao i 
                                    join proposta_turma pt on i.proposta_turma_id = pt.id 
                                    join usuario u on u.id = i.usuario_id 
                                    where not u.excluido
                                        and not pt.excluido
                                        and not i.excluido
                                        and i.situacao = @SituacaoPublicada
                                        and i.proposta_turma_id = @codigoDaTurma";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<InscricaoConfirmadaDTO>(query, new {codigoDaTurma, SituacaoPublicada});
            }
        }

        public async Task<IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>> ListagemFormacoesPorAno(int ano)
        {
            var situacaoPublicada = 1;
            
            var query = @" select pt.id as codigoFormacao,
                                  p.nome_formacao as nomeFormacao,
                                  p.data_realizacao_inicio as dataRealizacaoInicio,
                                  p.data_realizacao_fim as dataRealizacaoFim,
                                  ap.nome as coordenadoria
                           from proposta_turma pt 
                             join proposta p on p.id = pt.proposta_id 
                             join area_promotora ap on ap.id = p.area_promotora_id
                           where not pt.excluido    
                             and not ap.excluido
                             and p.situacao = @SituacaoPublicada
 and p.id = 241
                             --and EXTRACT(YEAR FROM p.data_realizacao_inicio) >= @ano";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>(query, new { ano,SituacaoPublicada });
            }
        }

        public async Task<IEnumerable<CodigoNomeTurmaProfessoresDTO>> ListagemTurmasPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @"    select pt.id as codigoTurma,
  		                             pt.nome as nomeTurma
                              from proposta_turma pt 
                              where not pt.excluido    
                                and pt.id = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<CodigoNomeTurmaProfessoresDTO>(query, new { codigosDasFormacoes });
            }
        }

        public async Task<IEnumerable<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>> ListagemProfessoresRegentesPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @" select pt.id as codigoTurma,
                                  regente.registro_funcional as rf,
		                          regente.nome_regente as nome
                           from proposta_turma pt 
                             join proposta_regente regente on regente.proposta_id = pt.proposta_id
                           where not pt.excluido
                             and not regente.excluido
                             and pt.id = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>(query, new { codigosDasFormacoes });
            }
        }

        public async Task<IEnumerable<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>> ListagemProfessoresTutoresPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @"select pt.id as codigoTurma,
                                 tutor.registro_funcional as rf,
		                         tutor.nome_tutor as nome,
		                         true as tutor
                          from proposta_turma pt 
                            join proposta_tutor tutor on tutor.proposta_id = pt.proposta_id
                          where not pt.excluido
                            and not tutor.excluido
                            and pt.id  = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>(query, new { codigosDasFormacoes });
            }
        }
    }
}