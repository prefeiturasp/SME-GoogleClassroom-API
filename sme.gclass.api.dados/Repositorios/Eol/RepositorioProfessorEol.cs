using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioProfessorEol : RepositorioEol, IRepositorioProfessorEol
    {
        public RepositorioProfessorEol(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<ProfessorEol>> ObterProfessoresParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao)
        {
            using var conn = ObterConexao();

            var aplicarPaginacao = paginacao.QuantidadeRegistros > 0;
            var query = MontaQueryProfessorParaInclusao(aplicarPaginacao);
            using var multi = await conn.QueryMultipleAsync(query,
                new
                {
                    anoLetivo = dataReferencia.Year,
                    dataReferencia = dataReferencia.Date,
                    paginacao.QuantidadeRegistros,
                    paginacao.QuantidadeRegistrosIgnorados
                });

            var retorno = new PaginacaoResultadoDto<ProfessorEol>();

            retorno.Items = multi.Read<ProfessorEol>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = aplicarPaginacao ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 1;

            return retorno;
        }

        private static string MontaQueryProfessorParaInclusao(bool aplicarPaginacao)
        {
            const string queryBase = @"IF OBJECT_ID('tempdb..#tempCargosProfessores') IS NOT NULL
	                                        DROP TABLE #tempCargosProfessores;
                                        SELECT
	                                        DISTINCT 
	                                        atr.cd_cargo_base_servidor
                                        INTO #tempCargosProfessores
                                        FROM
	                                        atribuicao_aula atr
                                        WHERE 
                                            an_atribuicao = @anoLetivo
                                            AND dt_atribuicao_aula > @dataReferencia
	                                        AND dt_cancelamento is null AND (dt_disponibilizacao_aulas is null OR dt_disponibilizacao_aulas > GETDATE());

                                        IF OBJECT_ID('tempdb..#tempProfessoresAtivos') IS NOT NULL
	                                        DROP TABLE #tempProfessoresAtivos;
                                        SELECT
	                                        DISTINCT
	                                        serv.cd_registro_funcional AS Rf,
	                                        serv.nm_pessoa AS NomePessoa,
                                            serv.nm_social AS NomeSocial,
	                                        'True' AS Ativo,
	                                        '/Professores' AS OrganizationPath
                                        INTO #tempProfessoresAtivos
                                        FROM
	                                        v_servidor_cotic serv (NOLOCK)
                                        INNER JOIN
	                                        v_cargo_base_cotic cbc (NOLOCK)
	                                        ON serv.cd_servidor = cbc.cd_servidor
                                        INNER JOIN
	                                        #tempCargosProfessores temp
	                                        ON cbc.cd_cargo_base_servidor = temp.cd_cargo_base_servidor;

                                        -- Resultado
                                        SELECT
	                                        *
                                        FROM
	                                        #tempProfessoresAtivos
                                        ORDER BY
	                                        Rf";

            var query = new StringBuilder(queryBase);
            if (aplicarPaginacao)
                query.Append(" OFFSET @quantidadeRegistrosIgnorados ROWS  FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.Append(";");

            query.Append(@"SELECT COUNT(*)
                             FROM #tempProfessoresAtivos;");

            return query.ToString();
        }
    }
}
