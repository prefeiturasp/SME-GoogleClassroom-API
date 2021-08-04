using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCargaInicial : RepositorioGoogle, IRepositorioCargaInicial
    {
        public RepositorioCargaInicial(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<CargaInicial>> ObterPorAno(int ano)
        {
            var query = @"select id
                            , ano
                            , tipos_ue as TiposUe
                            , Ues
                            , Turmas
                            , criado_em as CriadoEm
                     from carga_incial
                    where ano = @ano";

            using (var conexao = ObterConexao())
                return await conexao.QueryAsync<CargaInicial>(query, new { ano });
        }
    }
}
