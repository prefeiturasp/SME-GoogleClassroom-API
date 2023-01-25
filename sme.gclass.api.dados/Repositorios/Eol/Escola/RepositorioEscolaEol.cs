using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Escola
{
    public class RepositorioEscolaEol : RepositorioEol, IRepositorioEscolaEol
    {
        public RepositorioEscolaEol(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<EscolaDTO>> ObterEscolas()
        {
            var query = @"	SELECT 
	                         esc.cd_escola Codigo,
	                         RTRIM(LTRIM(dre.nm_unidade_educacao)) NomeDRE,
	                         RTRIM(LTRIM(vcue.nm_unidade_educacao)) Nome,
	                         RTRIM(LTRIM(dre.nm_exibicao_unidade)) SiglaDRE,
	                         dre.cd_unidade_educacao CodigoDRE,
	                         RTRIM(LTRIM(te.sg_tp_escola)) SiglaTipoEscola
	                    FROM
		                     escola esc
                       INNER JOIN v_cadastro_unidade_educacao vcue ON esc.cd_escola = vcue.cd_unidade_educacao
                       INNER JOIN tipo_escola te ON esc.tp_escola = te.tp_escola
                       INNER JOIN v_cadastro_unidade_educacao dre ON dre.cd_unidade_educacao = vcue.cd_unidade_administrativa_referencia
                       order by RTRIM(LTRIM(dre.nm_unidade_educacao)), RTRIM(LTRIM(vcue.nm_unidade_educacao))";

            using var conn = ObterConexao();
            return await conn.QueryAsync<EscolaDTO>(query);
        }

        public async Task<int> ObterTipoDaEscolaPorCodigoEscola(string codigoEscola)
        {

            var query = @"	select e.tp_escola as TipoEscola
                            from escola e 
                            inner join tipo_escola te on e.tp_escola = te.tp_escola 
                            where e.cd_escola = @codigoEscola ";

            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<int>(query, new
            {
                codigoEscola
            });
        }
    }
}