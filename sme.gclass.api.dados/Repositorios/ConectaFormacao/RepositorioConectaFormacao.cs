using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
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
                                    coalesce(funcao_dre_codigo, cargo_dre_codigo, u.codigo_eol_unidade) dreCodigo,
                                    coalesce(funcao_ue_codigo, cargo_ue_codigo, u.codigo_eol_unidade) ueCodigo,
                                    (u.tipo = 2) EhUsuarioCustistaUeParceira
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

        public async Task<IEnumerable<FormacaoDTO>> ListagemFormacoesPorAno(int ano, long? areaPromotoraId)
        {
            var query = @"
                            select
	                            p.id as codigo,
	                            p.nome_formacao as nome,
	                            ap.id as codigoAreaPromotora,
	                            ap.nome as nomeAreaPromotora,
	                            extract(year from p.data_realizacao_inicio) as ano
                            from
	                            proposta p
                            inner join area_promotora ap on
	                            ap.id = p.area_promotora_id
	                            and not ap.excluido
                            where
	                            not p.excluido
	                            and p.situacao = @SituacaoPublicada
	                            and p.integrar_no_sga = true
	                            and p.data_realizacao_fim >= current_date
	                            and extract(year from p.data_realizacao_inicio) = @ano";

            if (areaPromotoraId.HasValue)
                query += " and p.area_promotora_id = @areaPromotoraId ";

            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<FormacaoDTO>(query, new { ano, SituacaoPublicada, areaPromotoraId });
            }
        }

        public async Task<IEnumerable<FormacaoTurmaDTO>> ListagemTurmasPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @"    select pt.proposta_id as codigoFormacao,
                                     pt.id as codigo,
  		                             pt.nome as nome
                              from proposta_turma pt 
                              where not pt.excluido    
                                and pt.proposta_id = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<FormacaoTurmaDTO>(query, new { codigosDasFormacoes });
            }
        }

        public async Task<IEnumerable<FormacaoTurmaProfessoresDTO>> ListagemProfessoresRegentesPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @" select pt.id as codigoTurma,
                                  regente.registro_funcional as rf,
		                          regente.nome_regente as nome,
                                  regente.cpf  
                           from proposta_turma pt 
                              join proposta_regente_turma prt on prt.turma_id = pt.id and not prt.excluido
                              join proposta_regente regente on regente.id = prt.proposta_regente_id and not regente.excluido
                           where not pt.excluido
                             and pt.proposta_id = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<FormacaoTurmaProfessoresDTO>(query, new { codigosDasFormacoes });
            }
        }

        public async Task<IEnumerable<FormacaoTurmaProfessoresDTO>> ListagemProfessoresTutoresPorCodigosFormacoes(long[] codigosDasFormacoes)
        {
            var query = @"select pt.id as codigoTurma,
                                 tutor.registro_funcional as rf,
		                         tutor.nome_tutor as nome,
                                 tutor.cpf,
		                         true as tutor
                          from proposta_turma pt 
                            join proposta_tutor_turma ptt on ptt.turma_id = pt.id and not ptt.excluido
                            join proposta_tutor tutor on tutor.id = ptt.proposta_tutor_id and not tutor.excluido
                          where not pt.excluido
                            and pt.proposta_id = any(@codigosDasFormacoes)";
        
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<FormacaoTurmaProfessoresDTO>(query, new { codigosDasFormacoes });
            }
        }

        public async Task<IEnumerable<AreaPromotoraDTO>> ListagemAreaPromotora()
        {
            var query = @"select id as CodigoIE, nome as NomeIE
                          from area_promotora
                          where not excluido";

            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<AreaPromotoraDTO>(query);
            }
        }
    }
}