using System.Collections.Generic;
using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioParametroSistema : RepositorioGoogle, IRepositorioParametroSistema
    {
        public RepositorioParametroSistema(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<ParametrosSistema> ObterParametroSistemaPorTipoEAno(TipoParametroSistema tipo, int ano)
        {
            const string query = @"
                        select
                            id,
                            nome,
                            tipo,
                            descricao,
                            valor,
                            ano,
                            ativo
                        from parametro_sistema
                        where tipo = @tipo
                            and ano = @ano";

            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<ParametrosSistema>(query, new { tipo, ano });
        }

        public async Task<IEnumerable<ParametrosSistema>> ObterParametroSistemaPorAno(int ano)
        {
            const string query = @"
                        select
                            id,
                            nome,
                            tipo,
                            descricao,
                            valor,
                            ano,
                            ativo
                        from parametro_sistema
                        where  ano = @ano order by tipo, ano desc";

            using var conn = ObterConexao();
            return await conn.QueryAsync<ParametrosSistema>(query, new { ano });
        }
        

        public async Task<long> ReplicarPorAno(ParametrosSistema parametrosSistema, int novoAno)
        {
            var query = @"INSERT INTO PUBLIC.PARAMETRO_SISTEMA
                                    (NOME, TIPO, DESCRICAO, VALOR, ANO, ATIVO)
                                    VALUES(@nome, @tipo,@descricao, @valor, @ano, @ativo)
                         RETURNING ID";

            var parametros = new
            {
                nome = parametrosSistema.Nome,
                tipo = parametrosSistema.Tipo,
                descricao = parametrosSistema.Descricao,
                valor = parametrosSistema.Valor,
                ano = novoAno,
                ativo = parametrosSistema.Ativo,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}