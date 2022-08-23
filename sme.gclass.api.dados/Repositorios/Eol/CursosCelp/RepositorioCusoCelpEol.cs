using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCusoCelpEol : RepositorioEol, IRepositorioCursoCelpEol
    {
        public RepositorioCusoCelpEol(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<CursoCelpEolDto>> ObterCursosCelpPorComponentesEAno(IReadOnlyList<int> componentes, int anoLetivo)
        {
	        var tiposItinerarioMedio = (await ObterTiposItinerarioMedio()).ToList();
	        
	        var query = @$"select te.cd_turma_escola as turmacodigo,
				te.cd_escola as uecodigo,
				ue.cd_unidade_administrativa_referencia as drecodigo,
				g.dc_grade as descricaogradeprograma,
				gcc.cd_componente_curricular as componentecodigo,
				CONCAT(CASE
				    WHEN ee.cd_etapa_ensino IN (2, 3, 7, 11) THEN
				    	'EJA'
				    WHEN ee.cd_etapa_ensino IN (4, 5, 12, 13) THEN
				    	'EF'
				    WHEN te.cd_tipo_turma IN ({string.Join(',', tiposItinerarioMedio)}) OR ee.cd_etapa_ensino IN (6, 7, 8, 9, 17, 14) THEN
				    	'EM'
				    WHEN ee.cd_etapa_ensino IN (1) THEN
				    	'EI'
				    ELSE
				    	'P'
				    END, ' - ', te.dc_turma_escola, ' - ', te.cd_turma_escola, ' - ', ue.cd_unidade_educacao, ' - ',
				    	LTRIM(RTRIM(tpe.sg_tp_escola)), ' ', ue.nm_unidade_educacao
				) as secao,
    			te.cd_tipo_turma turmatipo
				from turma_escola te
				inner join turma_escola_grade_programa tegp on te.cd_turma_escola = tegp.cd_turma_escola
				inner join escola_grade eg on tegp.cd_escola_grade = eg.cd_escola_grade
				inner join grade g on g.cd_grade = eg.cd_grade
				inner join grade_componente_curricular gcc on gcc.cd_grade = g.cd_grade
				inner join escola e on e.cd_escola = te.cd_escola
				inner join v_cadastro_unidade_educacao ue on ue.cd_unidade_educacao = e.cd_escola
				inner join unidade_administrativa dre on dre.cd_unidade_administrativa = ue.cd_unidade_administrativa_referencia
				left join serie_ensino se ON se.cd_serie_ensino = g.cd_serie_ensino
				left join etapa_ensino ee ON ee.cd_etapa_ensino = se.cd_etapa_ensino
				inner join tipo_escola tpe ON tpe.tp_escola	= e.tp_escola
				where gcc.cd_componente_curricular in ({string.Join(',', componentes)})
				and te.an_letivo = @anoLetivo
				and e.tp_escola = 27";
	        
	        using var conn = ObterConexao();
	        return await conn.QueryAsync<CursoCelpEolDto>(query, new { componentes, anoLetivo });
        }
        
        private async Task<IEnumerable<int>> ObterTiposItinerarioMedio()
        {
	        using var conn = ObterConexaoApiEOL();
	        return await conn.QueryAsync<int>("select Id from turma_tipo_itinerario");
        } 
    }
}