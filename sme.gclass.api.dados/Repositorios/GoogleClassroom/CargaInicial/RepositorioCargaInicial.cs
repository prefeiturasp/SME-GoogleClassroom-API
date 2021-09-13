using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
                            , tipos_ue_cursos as TiposUeCursos
                            , Ues
                            , Turmas
                            , criado_em as CriadoEm
                     from public.carga_inicial
                    where ano = @ano";

            using (var conexao = ObterConexao())
                return await conexao.QueryAsync<CargaInicial>(query, new { ano });
        }

        public async Task<int> InserirCargaInicial(int ano, string tiposUes, string ues, string turmas)
        {
            var query = @"INSERT INTO public.carga_inicial
                                            (ano, tipos_ue, ues, turmas, criado_em)
                                            VALUES(@ano, @tiposUes, @ues, @turmas, @criadoem) RETURNING ANO";

            using (var conexao = ObterConexao())
                return await conexao.ExecuteAsync(query, new { ano, tiposUes, ues, turmas, criadoem = DateTime.Now });
        }
    }
}
