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
    }
}
