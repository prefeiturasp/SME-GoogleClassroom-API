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
                                    u.email,
                                    coalesce(funcao_dre_codigo, cargo_dre_codigo) dreCodigo,
                                    coalesce(funcao_ue_codigo, cargo_ue_codigo) ueCodigo
                                    from inscricao i 
                                    join proposta_turma pt on i.proposta_turma_id = pt.id
                                    join proposta p on p.id = pt.proposta_id 
                                    join usuario u on u.id = i.usuario_id 
                                    where not u.excluido
                                        and not pt.excluido
                                        and not i.excluido
                                        and p.integrar_no_sga = true
                                        and i.situacao = @SituacaoPublicada
                                        and i.proposta_turma_id = @codigoDaTurma";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<InscricaoConfirmadaDTO>(query, new {codigoDaTurma, SituacaoPublicada});
            }
        }

        public async Task<IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>> ListagemFormacoesPorAno(int ano)
        {
            var query = @" select p.id as codigoFormacao,
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
                             and p.integrar_no_sga = true
                             and EXTRACT(YEAR FROM p.data_realizacao_inicio) >= @ano";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>(query, new { ano,SituacaoPublicada });
            }
        }

        public async Task<IEnumerable<CodigoFormacaoCodigoNomeTurmaProfessoresDTO>> ListagemTurmasPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @"    select pt.id as codigoTurma,
  		                             pt.nome as nomeTurma,
  		                             pt.proposta_id as codigoFormacao
                              from proposta_turma pt 
                              where not pt.excluido    
                                and pt.proposta_id = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<CodigoFormacaoCodigoNomeTurmaProfessoresDTO>(query, new { codigosDasFormacoes });
            }
        }

        public async Task<IEnumerable<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>> ListagemProfessoresRegentesPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @" select pt.id as codigoTurma,
                                  regente.registro_funcional as rf,
		                          regente.nome_regente as nome
                           from proposta_turma pt 
                              join proposta_regente_turma prt on prt.turma_id = pt.id 
                              join proposta_regente regente on regente.id = prt.proposta_regente_id 
                           where not pt.excluido
                             and not regente.excluido
                             and pt.proposta_id = any(@codigosDasFormacoes)";
        
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
                            join proposta_tutor_turma ptt on ptt.turma_id = pt.id 
                            join proposta_tutor tutor on tutor.id = ptt.proposta_tutor_id                            
                          where not pt.excluido
                            and not tutor.excluido
                            and pt.proposta_id  = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>(query, new { codigosDasFormacoes });
            }
        }
    }
}