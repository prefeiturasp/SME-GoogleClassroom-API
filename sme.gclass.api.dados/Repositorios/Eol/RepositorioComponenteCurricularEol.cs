using SME.GoogleClassroom.Dados.Help;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.Pedagogico.Interface.DTO.RetornoQueryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
	public class RepositorioComponenteCurricularEol : RepositorioEol, IRepositorioComponenteCurricularEol
    {
		public RepositorioComponenteCurricularEol(ConnectionStrings connectionStrings)
			: base(connectionStrings)
		{
		}

		public Task<IEnumerable<ComponenteCurricularEol>> ObterDisciplinasAsync()
		{
            var query = @"SELECT ccp.Id,
                            cc.IdComponenteCurricular, 
                            cc.EhCompartilhada, 
                            cc.EhRegencia, 
                            cc.PermiteRegistroFrequencia, 
                            cc.PermiteLancamentoDeNota,
                            cc.EhTerritorio,
                            cc.EhBaseNacional,
                            cc.IdGrupoMatriz,
                            cc.Descricao,
                            ccp.idcomponentecurricularpai,
                            ccp.vigencia
                     FROM ComponenteCurricular cc
                        LEFT JOIN componentecurricularpai ccp on cc.idcomponentecurricular = ccp.idcomponentecurricular";

            using var conn = ObterConexao();
            return conn.QueryAsync<ComponenteCurricularEol>(query);
        }

        public Task<IEnumerable<DisciplinaTerritorioSaberDTO>> ObterDisciplinaTerritorioDosSaberesAsync(string codigoTurma, IEnumerable<long> codigosComponentesCurriculares)
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
            return conn.QueryAsync<DisciplinaTerritorioSaberDTO>(query, new { codigoTurma = int.Parse(codigoTurma), codigosComponentesCurriculares });
        }
    }
}
