using Dapper;
using SME.GoogleClassroom.Dados.Help;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.Pedagogico.Interface.DTO.RetornoQueryDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
	public class RepositorioComponenteCurricularEol : RepositorioEol, IRepositorioComponenteCurricularEol
    {
        public readonly static int CODIGORF_LENGTH = 7;
        public readonly static int CODIGOCPF_LENGTH = 11;
        private const long MOTIVO_DISPONIBILIZACAO_ERRO_CADASTRO = 26;

        const string SQL_CAMPOS_TABELA_AGRUPÀMENTO_TERRITORIO = @"codagrupamento as CodigoAgrupamento,
	                                       codterritoriosaber as CodigoTerritorioSaber,
	                                       codexperienciapedagogica as CodigoExperienciaPedagogica,
	                                       dtinicioatribuicao as DtInicioAtribuicao,
                                           anoatribuicao as AnoAtribuicao,
	                                       dtfimatribuicao as DtFimAtribuicao,
                                           dtfimturma as DtFimTurma,
	                                       rfprofessor as RfProfessor,
	                                       codturma as CodigoTurma,
	                                       codcomponentescurriculares as CodigosComponentesCurriculares,
	                                       anoletivo as AnoLetivo,
	                                       codmotivodisponibilizacao as CodigoMotivoDisponibilizacao,
	                                       descterritoriosaber as DescricaoTerritorioSaber,
	                                       descexperienciapedagogica as DescricaoExperienciaPedagogica,
	                                       criado_em as CriadoEm,
                                           alterado_em as AlteradoEm";

        internal static string ObterComponentesCurricularesTerritorioAtribuidos(string condicaoAndWhere)
            => $@"select 	 
                    cc.cd_componente_curricular as CodigoComponenteCurricular,
                    cc.dc_componente_curricular as DescricaoComponenteCurricular,
                    serie_ensino.sg_resumida_serie   as AnoTurma,
                    te.an_letivo as anoletivo,
                    te.cd_turma_escola as TurmaCodigo,
                    vsc.cd_registro_funcional as rfProfessor,
                    tgt.cd_experiencia_pedagogica as CodigoExperienciaPedagogica,
                    tgt.cd_territorio_saber as CodigoTerritorioSaber,
                    ter.dc_territorio_saber as DescricaoTerritorioSaber,
                    exp.dc_experiencia_pedagogica as DescricaoExperienciaPedagogica,
                    aa.dt_atribuicao_aula as dataAtribuicao,
                    aa.an_atribuicao as AnoAtribuicao,
                    te.dt_fim_turma as DataFimTurma,
                    0 as AtribuicaoExterna,
                    max(aa.dt_disponibilizacao_aulas) as dataDisponibilizacao,
                    max(aa.cd_motivo_disponibilizacao) as CodigoMotivoDisponibilizacao
	                    from turma_escola te
                        inner join escola esc ON te.cd_escola = esc.cd_escola
                        inner join v_cadastro_unidade_educacao ue on ue.cd_unidade_educacao = esc.cd_escola
                        inner join unidade_administrativa dre on dre.tp_unidade_administrativa = 24 and ue.cd_unidade_administrativa_referencia = dre.cd_unidade_administrativa
	                    --Serie Ensino
                        inner join serie_turma_escola ON serie_turma_escola.cd_turma_escola = te.cd_turma_escola
                        inner join serie_turma_grade ON serie_turma_grade.cd_turma_escola = serie_turma_escola.cd_turma_escola and serie_turma_grade.dt_fim is null
                        inner join escola_grade ON serie_turma_grade.cd_escola_grade = escola_grade.cd_escola_grade
                        inner join grade ON escola_grade.cd_grade = grade.cd_grade
                        inner join grade_componente_curricular gcc on gcc.cd_grade = grade.cd_grade
                        inner join componente_curricular cc on cc.cd_componente_curricular = gcc.cd_componente_curricular and cc.dt_cancelamento is null
                        inner join serie_ensino ON grade.cd_serie_ensino = serie_ensino.cd_serie_ensino
                        inner join turma_grade_territorio_experiencia tgt on tgt.cd_serie_grade = serie_turma_grade.cd_serie_grade and tgt.cd_componente_curricular = cc.cd_componente_curricular
	                    inner join tipo_experiencia_pedagogica exp on exp.cd_experiencia_pedagogica = tgt.cd_experiencia_pedagogica
	                    inner join território_saber ter on ter.cd_territorio_saber = tgt.cd_territorio_saber
                        -- Atribuição                    
                        inner join atribuicao_aula (nolock) aa on (gcc.cd_grade = aa.cd_grade 
    											                    and gcc.cd_componente_curricular = aa.cd_componente_curricular 
    											                    and aa.cd_serie_grade = serie_turma_grade.cd_serie_grade)
					                                                and aa.dt_cancelamento is null
					                                                and aa.an_atribuicao = te.an_letivo
					                                                AND ( COALESCE(aa.dt_disponibilizacao_aulas, Getdate()) >= '2020-02-05' )	
                                                                    and (aa.cd_motivo_disponibilizacao <> {MOTIVO_DISPONIBILIZACAO_ERRO_CADASTRO} or aa.cd_motivo_disponibilizacao is null)
					                                                and aa.dt_atribuicao_aula <= Getdate()
                        inner join v_cargo_base_cotic (nolock) vcbc on aa.cd_cargo_base_servidor = vcbc.cd_cargo_base_servidor
                        inner join v_servidor_cotic (nolock) vsc on vcbc.cd_servidor = vsc.cd_servidor 
                        where te.st_turma_escola in ('O', 'A', 'C', 'E')
                          {condicaoAndWhere}
                    group by cc.cd_componente_curricular,
                    cc.dc_componente_curricular,
                    serie_ensino.sg_resumida_serie,
                    te.an_letivo,
                    te.cd_turma_escola,
                    vsc.cd_registro_funcional,
                    tgt.cd_experiencia_pedagogica,
                    tgt.cd_territorio_saber,
                    ter.dc_territorio_saber,
                    exp.dc_experiencia_pedagogica,
                    aa.dt_atribuicao_aula,
                    te.dt_fim_turma,
                    aa.an_atribuicao ";

        internal static string ObterComponentesCurricularesTerritorioAtribuidosExterno(string condicaoAndWhere)
            => $@"select 	 
                    cc.cd_componente_curricular as CodigoComponenteCurricular,
                    cc.dc_componente_curricular as DescricaoComponenteCurricular,
                    serie_ensino.sg_resumida_serie   as AnoTurma,
                    te.an_letivo as anoletivo,
                    te.cd_turma_escola as TurmaCodigo,
                    pe.cd_cpf_pessoa as rfProfessor,
                    tgt.cd_experiencia_pedagogica as CodigoExperienciaPedagogica,
                    tgt.cd_territorio_saber as CodigoTerritorioSaber,
                    ter.dc_territorio_saber as DescricaoTerritorioSaber,
                    exp.dc_experiencia_pedagogica as DescricaoExperienciaPedagogica,
                    aa_ext.dt_atribuicao as dataAtribuicao,
                    aa_ext.an_atribuicao as AnoAtribuicao,
                    te.dt_fim_turma as DataFimTurma,
                    1 as AtribuicaoExterna,
                    max(aa_ext.dt_disponibilizacao) as dataDisponibilizacao,
                    max(aa_ext.cd_motivo_disponibilizacao_externo) as CodigoMotivoDisponibilizacao
                        from turma_escola te
                        inner join escola esc ON te.cd_escola = esc.cd_escola
                        inner join v_cadastro_unidade_educacao ue on ue.cd_unidade_educacao = esc.cd_escola
                        inner join unidade_administrativa dre on dre.tp_unidade_administrativa = 24 and ue.cd_unidade_administrativa_referencia = dre.cd_unidade_administrativa
                        --Serie Ensino
                        inner join serie_turma_escola ON serie_turma_escola.cd_turma_escola = te.cd_turma_escola
                        inner join serie_turma_grade ON serie_turma_grade.cd_turma_escola = serie_turma_escola.cd_turma_escola and serie_turma_grade.dt_fim is null
                        inner join escola_grade ON serie_turma_grade.cd_escola_grade = escola_grade.cd_escola_grade
                        inner join grade ON escola_grade.cd_grade = grade.cd_grade
                        inner join grade_componente_curricular gcc on gcc.cd_grade = grade.cd_grade
                        inner join componente_curricular cc on cc.cd_componente_curricular = gcc.cd_componente_curricular and cc.dt_cancelamento is null
                        inner join serie_ensino ON grade.cd_serie_ensino = serie_ensino.cd_serie_ensino
                        inner join turma_grade_territorio_experiencia tgt on tgt.cd_serie_grade = serie_turma_grade.cd_serie_grade and tgt.cd_componente_curricular = cc.cd_componente_curricular
                        inner join tipo_experiencia_pedagogica exp on exp.cd_experiencia_pedagogica = tgt.cd_experiencia_pedagogica
                        inner join território_saber ter on ter.cd_territorio_saber = tgt.cd_territorio_saber
                        -- Atribuição externa
		                inner join atribuicao_externo (nolock) aa_ext
                                   on (gcc.cd_grade = aa_ext.cd_grade and
                                      gcc.cd_componente_curricular = aa_ext.cd_componente_curricular
                                       and aa_ext.cd_serie_grade = serie_turma_grade.cd_serie_grade)
					                   and aa_ext.dt_cancelamento is null
					                   and aa_ext.an_atribuicao = te.an_letivo
                       	                AND ( COALESCE(aa_ext.dt_disponibilizacao, Getdate()) >= '2020-02-05' )	
                                                                    and (aa_ext.cd_motivo_disponibilizacao_externo <> {MOTIVO_DISPONIBILIZACAO_ERRO_CADASTRO} or aa_ext.cd_motivo_disponibilizacao_externo is null)
	                                                                and aa_ext.dt_atribuicao <= Getdate()											
		                inner JOIN contrato_externo ce with (NOLOCK) on ce.cd_contrato_externo = aa_ext.cd_contrato_externo 
  		                inner JOIN pessoa pe with (NOLOCK) on pe.cd_pessoa = ce.cd_pessoa	
	                where te.st_turma_escola in ('O', 'A', 'C', 'E')
                          {condicaoAndWhere}
                    group by cc.cd_componente_curricular,
                    cc.dc_componente_curricular,
                    serie_ensino.sg_resumida_serie,
                    te.an_letivo,
                    te.cd_turma_escola,
                    pe.cd_cpf_pessoa,
                    tgt.cd_experiencia_pedagogica,
                    tgt.cd_territorio_saber,
                    ter.dc_territorio_saber,
                    exp.dc_experiencia_pedagogica,
                    aa_ext.dt_atribuicao,
                    te.dt_fim_turma,
                    aa_ext.an_atribuicao ";

        public RepositorioComponenteCurricularEol(ConnectionStrings connectionStrings)
			: base(connectionStrings)
		{
		}

		public async Task<IEnumerable<ComponenteCurricularEol>> ObterDisciplinasAsync()
		{
            var query = @"SELECT 
                            cc.IdComponenteCurricular,                             
                            cc.EhTerritorio
                     FROM ComponenteCurricular cc
                        LEFT JOIN componentecurricularpai ccp on cc.idcomponentecurricular = ccp.idcomponentecurricular";

            using var conn = ObterConexaoApiEOL();
			return await conn.QueryAsync<ComponenteCurricularEol>(query);
        }

        public async Task<IEnumerable<DisciplinaTerritorioSaberDTO>> ObterDisciplinaTerritorioDosSaberesAsync(string codigoTurma, IEnumerable<long> codigosComponentesCurriculares)
        {
			var query = @"select
						grade_ter.cd_experiencia_pedagogica as CodigoExperienciaPedagogica,
						grade_ter.cd_territorio_saber as CodigoTerritorioSaber,
						ter.dc_territorio_saber as DescricaoTerritorioSaber,
						exp.dc_experiencia_pedagogica as DescricaoExperienciaPedagogica,
						Convert(date, dt_inicio) as DataInicio,
						grade_ter.cd_componente_curricular as CodigoComponenteCurricular
					from
						turma_grade_territorio_experiencia grade_ter
						inner join território_saber ter on ter.cd_territorio_saber = grade_ter.cd_territorio_saber
						inner join tipo_experiencia_pedagogica exp on exp.cd_experiencia_pedagogica = grade_ter.cd_experiencia_pedagogica
					where
						exists (
							select
								*
							from
								serie_turma_grade grade_tur
							where
								cd_turma_escola = @codigoTurma
								and grade_tur.cd_serie_grade = grade_ter.cd_serie_grade
						)
						and grade_ter.cd_componente_curricular in @codigosComponentesCurriculares
					";
			using var conn = ObterConexao();
            return await conn.QueryAsync<DisciplinaTerritorioSaberDTO>(query, new { codigoTurma = int.Parse(codigoTurma), codigosComponentesCurriculares });
        }

        public async Task<IEnumerable<AgrupamentoAtribuicaoTerritorioSaber>> ObterAgrupamentosTerritorioSaber(long codigoTurma,
                                                                                                 long? codigoTerritorioSaber,
                                                                                                 long? codigoExperienciaPegagogica,
                                                                                                 long? codigoComponenteCurricular = null,
                                                                                                 DateTime? dataBase = null,
                                                                                                 DateTime? dataInicio = null,
                                                                                                 string rfProfessor = null,
                                                                                                 string codigosComponentesCurriculares = null,
                                                                                                 bool? encerramentoAtribuicaoViaAtualizacaoComponentesAgrupados = null)
        {
            var sql = $@"select {SQL_CAMPOS_TABELA_AGRUPÀMENTO_TERRITORIO} from agrupamentoatribuicaoterritoriosaber 
                         where  codturma = @codigoTurma 
                                {(codigoTerritorioSaber != null ? " and codterritoriosaber = @codigoTerritorioSaber " : string.Empty)}
                                {(codigoExperienciaPegagogica != null ? " and codexperienciapedagogica = @codigoExperienciaPegagogica " : string.Empty)}
                                {(codigoComponenteCurricular != null ? " and @CodigoComponenteCurricular = ANY(string_to_array(codcomponentescurriculares, ',')) " : string.Empty)}
                                {(codigosComponentesCurriculares != null ? " and codcomponentescurriculares = @codigosComponentesCurriculares " : string.Empty)}
                                {(!string.IsNullOrEmpty(rfProfessor) ? " and rfprofessor = @rfProfessor " : string.Empty)}
                                {(dataInicio != null ? " and dtinicioatribuicao = @dataInicio " : string.Empty)}
                                {(encerramentoAtribuicaoViaAtualizacaoComponentesAgrupados != null ? " and encerramento_atribuicao_agrupamento_atualizado = @encerramentoAtribuicaoViaAtualizacaoComponentesAgrupados " : string.Empty)}
                                and dtinicioatribuicao <= @dataBase ";
            using (var conn = ObterConexaoApiEOL())
            {
                return await conn.QueryAsync<AgrupamentoAtribuicaoTerritorioSaber>(sql, new
                {
                    codigoTurma,
                    codigoTerritorioSaber,
                    codigoExperienciaPegagogica,
                    codigoComponenteCurricular = codigoComponenteCurricular.ToString(),
                    dataBase = dataBase ?? DateTime.Today,
                    rfProfessor,
                    codigosComponentesCurriculares,
                    dataInicio,
                    encerramentoAtribuicaoViaAtualizacaoComponentesAgrupados
                });
            }
        }

        public async Task<IEnumerable<ComponenteCurricularTerritorioAtribuidoTurmaDTO>> ObterComponentesCurricularesTerritorioAtribuidos(long codigoTurma, string rfProf = null)
        {
            var condicaoAndWhere = $@" and te.cd_turma_escola = @CodigoTurma 
                                          {(!string.IsNullOrEmpty(rfProf) ? " and vsc.cd_registro_funcional = @rfProf " : string.Empty)}";

            var condicaoAndWhereAtribuicaoExterno = $@" and te.cd_turma_escola = @CodigoTurma 
                                          {(!string.IsNullOrEmpty(rfProf) ? " and pe.cd_cpf_pessoa = @cpfProf " : string.Empty)}";

            return await ObterComponentesCurricularesTerritorioAtribuidos(condicaoAndWhere, condicaoAndWhereAtribuicaoExterno, new
            {
                codigoTurma,
                rfProf = new DbString { Value = rfProf, Length = CODIGORF_LENGTH, IsFixedLength = true, IsAnsi = true },
                cpfProf = new DbString { Value = rfProf, Length = CODIGOCPF_LENGTH, IsFixedLength = true, IsAnsi = true } 
            });
        }

        private async Task<IEnumerable<ComponenteCurricularTerritorioAtribuidoTurmaDTO>> ObterComponentesCurricularesTerritorioAtribuidos(string whereAtribuicaoAula, string whereAtribuicaoExterna, object parametro)
        {
            var consultaSQL = $@"{ObterComponentesCurricularesTerritorioAtribuidos(whereAtribuicaoAula)}
                                 union all   
                                 {ObterComponentesCurricularesTerritorioAtribuidosExterno(whereAtribuicaoExterna)}
                                 order by dataAtribuicao, CodigoTerritorioSaber, CodigoExperienciaPedagogica, rfProfessor, CodigoComponenteCurricular;";
            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<ComponenteCurricularTerritorioAtribuidoTurmaDTO>(consultaSQL, parametro);
            }
        }
    }
}
