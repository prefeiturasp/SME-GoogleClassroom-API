using System.Collections.Generic;
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
	        var query = @$"select te.cd_turma_escola as turmacodigo,
	                                   te.cd_escola as uecodigo,
	                                    ue.cd_unidade_administrativa_referencia as drecodigo,
	                                    g.dc_grade as descricaogradeprograma,
   	                                    gcc.cd_componente_curricular as componentecodigo
                                    from turma_escola te
										inner join turma_escola_grade_programa tegp on te.cd_turma_escola = tegp.cd_turma_escola
										inner join escola_grade eg on tegp.cd_escola_grade = eg.cd_escola_grade
										inner join grade g on g.cd_grade = eg.cd_grade
										inner join grade_componente_curricular gcc on gcc.cd_grade = g.cd_grade
										inner join escola e on e.cd_escola = te.cd_escola
										inner join v_cadastro_unidade_educacao ue on ue.cd_unidade_educacao = e.cd_escola
										inner join unidade_administrativa dre on dre.cd_unidade_administrativa = ue.cd_unidade_administrativa_referencia
									where gcc.cd_componente_curricular in ({string.Join(',', componentes)})
									and te.an_letivo = @anoLetivo
									and e.tp_escola = 27";
	        
	        using var conn = ObterConexao();
	        return await conn.QueryAsync<CursoCelpEolDto>(query, new { componentes, anoLetivo });
        }
    }
}