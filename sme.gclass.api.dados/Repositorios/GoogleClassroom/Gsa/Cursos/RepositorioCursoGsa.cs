using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoGsa: RepositorioGoogle, IRepositorioCursoGsa
    {
        public RepositorioCursoGsa(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<bool> ExistePorIdAsync(long cursoId)
        {
            var query = @"SELECT exists(SELECT 1 from public.cursos_gsa where id = @cursoId limit 1)";
            using var conn = ObterConexao();
            return (await conn.QuerySingleOrDefaultAsync<bool>(query, new { cursoId }));
        }

        public async Task<int> SalvarAsync(CursoGsa cursoGsa)
        {
            const string insertQuery = @"insert into public.cursos_gsa
                                        (id, nome, secao, criador_id, descricao, data_inclusao, inserido_manualmente_google)
                                        values
                                        (@id, @nome, @secao, @criadorId, @descricao, @dataInclusao, @inseridoManualmenteGoogle)";

            var parametros = new
            {
                id = cursoGsa.Id,
                nome = cursoGsa.Nome,
                secao = cursoGsa.Secao,
                criadorId = cursoGsa.CriadorId,
                descricao = cursoGsa.Descricao,
                inseridoManualmenteGoogle = cursoGsa.InseridoManualmenteGoogle,
                dataInclusao = cursoGsa.DataInclusao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<PaginacaoResultadoDto<CursoGsaDto>> ObterCursosComparativosAsync(Paginacao paginacao, string secao, string nome, string descricao)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterCursosComparativos(false, paginacao, secao, nome, descricao));
            queryCompleta.AppendLine(MontaQueryObterCursosComparativos(true, paginacao, secao, nome, descricao));

            var retorno = new PaginacaoResultadoDto<CursoGsaDto>();

            using var conn = ObterConexao();

            var parametros = new
            {
                paginacao,
                secao
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);

            retorno.Items = multi.Read<CursoGsaDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryObterCursosComparativos(bool ehParaPaginacao, Paginacao paginacao, string secao, string nome, string descricao)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"CC.ID, 
                                  CC.NOME,
                                  CC.SECAO,
                                  CC.CRIADOR_ID AS CRIADORID,
                                  CC.DESCRICAO,
                                  CC.DATA_INCLUSAO AS DATAINCLUSAO,
                                  CC.INSERIDO_MANUALMENTE_GOOGLE AS INSERIDOMANUALMENTEGOOGLE");
            }

            queryCompleta.AppendLine(@"FROM cursos_gsa CC");
            queryCompleta.AppendLine(@"WHERE 1=1");


            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND CC.nome like('%" + nome?.Trim().ToLower() + "%')");

            if (!string.IsNullOrEmpty(descricao))
                queryCompleta.AppendLine(@"AND CC.descricao like('%" + descricao?.Trim().ToLower() + "%')");

            if (!string.IsNullOrEmpty(secao))
                queryCompleta.AppendLine(@"AND CC.secao like('%" + secao?.Trim().ToLower() + "%')");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }

        public async Task<int> ValidarCursosExistentesCursosComparativosAsync()
        {
            const string updateQuery = @"
                drop table if exists tempCursosValidacao;
                select 
                    c.id,
                    not cc.id is null as existe_google
                into tempCursosValidacao
                from 
                    cursos c
                left join
                    cursos_gsa cc
                    on cast(c.id as varchar) = cc.id;
   
                update 
                    cursos c
                set
                    existe_google = t1.existe_google
                from 
                    tempCursosValidacao t1
                where
                    c.id = t1.id;";

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery);
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM cursos_gsa";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }

        public async Task<IEnumerable<CursoGsaId>> ObterCursosGsaPorAno(int anoLetivo, long? cursoId, int pagina = 0, int quantidadeRegistrosPagina = 100)
        {
            int qtdeRegistrosIgnorados = quantidadeRegistrosPagina * (pagina - 1);
            int qtdeRegistros = quantidadeRegistrosPagina;

            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("select c.id as CursoId,");
            sqlQuery.AppendLine("       c.inserido_manualmente_google as CriadoManualmente");
            sqlQuery.AppendLine("from cursos_gsa c");
            sqlQuery.AppendLine("where extract(year from c.data_inclusao) = @anoLetivo");


            if (cursoId.HasValue)
                sqlQuery.AppendLine("and c.id = @cursoId");

            sqlQuery.AppendLine("offset @qtdeRegistrosIgnorados rows fetch next @qtdeRegistros rows only;");

            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<CursoGsaId>(sqlQuery.ToString(), new
                {
                    anoLetivo,
                    cursoId,
                    qtdeRegistrosIgnorados,
                    qtdeRegistros
                }, commandTimeout: 120);
            }
        }
    }
}
