using Dapper;
using Npgsql;
using NpgsqlTypes;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAtividade : RepositorioGoogle, IRepositorioAtividade
    {
        public RepositorioAtividade(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<AtividadeGsa>> ObterAtividadesPorDataCurso(Paginacao paginacao,
            DateTime dataReferencia, long? cursoId)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterAtividadesPorData(false, paginacao, cursoId));
            queryCompleta.AppendLine(MontaQueryObterAtividadesPorData(true, paginacao, cursoId));

            var retorno = new PaginacaoResultadoDto<AtividadeGsa>();

            using var conn = ObterConexao();

            var parametros = new
            {
                dataReferencia,
                cursoId
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);
            retorno.Items = multi.Read<AtividadeGsa>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = retorno.TotalRegistros > 0
                ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros)
                : 0;

            return retorno;
        }

        private string MontaQueryObterAtividadesPorData(bool ehParaPaginacao, Paginacao paginacao, long? cursoId)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@" A.id AS Id, 
                                            A.titulo AS Titulo, 
                                            A.descricao AS Descricao,  
                                            A.usuario_gsa_id AS UsuarioGsaId,
                                            A.curso_gsa_id AS CursoGsaId,
                                            A.data_inclusao AS DataInclusao, 
                                            A.data_alteracao AS DataAlteracao,
                                            A.data_entrega as DataEntrega,
                                            A.nota_maxima as NotaMaxima");
            }

            queryCompleta.AppendLine("FROM atividades A ");
            queryCompleta.AppendLine("WHERE A.DATA_INCLUSAO = @dataReferencia ");


            if (cursoId.HasValue)
                queryCompleta.AppendLine(@"AND A.ID = @cursoId");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine(
                    $" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }

        public async Task<long> AlterarAtividade(AtividadeGsa atividadeGsa)
        {
            const string updateQuery = @"update public.atividades
                                            set curso_gsa_id = @cursoId
                                              , usuario_gsa_id = @usuarioId
                                              , titulo = @titulo
                                              , descricao = @descricao
                                              , data_inclusao = @dataInclusao
                                              , data_alteracao = @dataAlteracao
                                        where id = @id";

            var parametros = new
            {
                id = atividadeGsa.Id,
                usuarioId = atividadeGsa.UsuarioGsaId,
                cursoId = atividadeGsa.CursoGsaId,
                titulo = atividadeGsa.Titulo,
                descricao = atividadeGsa.Descricao,
                dataInclusao = atividadeGsa.DataInclusao,
                dataAlteracao = atividadeGsa.DataAlteracao,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery, parametros);
        }

        public async Task<long> InserirAtividade(AtividadeGsa avisoGsa)
        {
            const string insertQuery = @"insert into public.atividades
                                        (id, titulo, descricao, usuario_gsa_id, curso_gsa_id, data_inclusao, data_alteracao, data_entrega, nota_maxima)
                                        values
                                        (@id, @titulo, @descricao, @usuarioId, @cursoId, @dataInclusao, @dataAlteracao, @dataEntrega, @notaMaxima)";

            var parametros = new
            {
                id = avisoGsa.Id,
                titulo = avisoGsa.Titulo,
                descricao = avisoGsa.Descricao,
                usuarioId = avisoGsa.UsuarioGsaId,
                cursoId = avisoGsa.CursoGsaId,
                dataInclusao = avisoGsa.DataInclusao,
                dataAlteracao = avisoGsa.DataAlteracao,
                dataEntrega = avisoGsa.DataEntrega,
                notaMaxima = avisoGsa.NotaMaxima
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<bool> RegistroExiste(long id)
        {
            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<bool>("select 1 from atividades where id = @id", new { id });
        }

        public async Task<IEnumerable<long>> ObterComponentesIdsAtividadesPorAnoLetivo(int anoLetivo)
        {
            const string query = @"select distinct(c.componente_curricular_id) as componente_curricular_id
                                     from atividades a 
                                    inner join cursos c on a.curso_gsa_id = c.id
                                    where EXTRACT(YEAR FROM a.data_inclusao) = @anoLetivo
                                    order by c.componente_curricular_id ";


            using var conn = ObterConexao();
            return await conn.QueryAsync<long>(query, new { anoLetivo });
        }

        public async Task<(int? totalPaginas, IEnumerable<DadosAvaliacaoDto>)> ObterAtividadesPorPeriodo(DateTime dataInicio,
            DateTime dataFim, long? cursoId, int pagina = 1, int quantidadeRegistrosPagina = 100)
        {
            var totalPaginas = (int?)null;

            using (var conn = ObterConexao())
            {
                var parametros = new
                {
                    dataInicio,
                    dataFim,
                    cursoId,
                    pagina = cursoId.HasValue ? (int?)null : pagina,
                    quantidadeRegistrosPagina = cursoId.HasValue ? (int?)null : quantidadeRegistrosPagina
                };

                if (pagina == 1 && !cursoId.HasValue)
                {
                    var query = await ObterQueryAtividadePorPeriodo(cursoId, true);

                    var totalRegistros = (long)(await conn.ExecuteScalarAsync(query, parametros));
                    totalPaginas = (int)Math.Ceiling((double)totalRegistros / (double)quantidadeRegistrosPagina);
                }

                return await Task.FromResult((totalPaginas, await conn.QueryAsync<DadosAvaliacaoDto>(await ObterQueryAtividadePorPeriodo(cursoId), parametros)));
            }
        }

        private async Task<string> ObterQueryAtividadePorPeriodo(long? cursoId, bool contagem = false)
        {
            var colunas = contagem ? " count(0) " :
                @" a.id AS Id, 
                   a.titulo AS Titulo, 
                   a.descricao AS Descricao,  
                   a.usuario_gsa_id AS UsuarioId,
                   c.turma_id AS TurmaId,
                   c.componente_curricular_id as ComponenteCurricularId,
                   a.curso_gsa_id AS CursoId,
                   a.data_inclusao AS DataInclusao, 
                   a.data_alteracao AS DataAlteracao,
                   a.data_entrega as DataEntrega,
                   a.nota_maxima as NotaMaxima ";

            var sqlQuery = new StringBuilder();

            sqlQuery.AppendLine($"select {colunas}");
            sqlQuery.AppendLine("    from atividades a");
            sqlQuery.AppendLine("    left join cursos c");
            sqlQuery.AppendLine("      on a.curso_gsa_id = c.id");
            sqlQuery.AppendLine("where (a.data_inclusao between @dataInicio and @dataFim or a.data_entrega = CURRENT_DATE)");

            if (cursoId.HasValue)
                sqlQuery.AppendLine("and c.id = @cursoId");

            if (!contagem)
            {
                sqlQuery.AppendLine("order by a.id");
                sqlQuery.AppendLine("limit @quantidadeRegistrosPagina offset(@pagina - 1) * @quantidadeRegistrosPagina");
            }

            return await Task.FromResult(sqlQuery.ToString());
        }

        public async Task<IEnumerable<AtividadeCursoDto>> ObterAtividadesExistentesAsync(IEnumerable<long> idsParaImportar)
        {
            var query = @"select
	                        a.id as atividadeId, c.componente_curricular_id as ComponenteCurricularId, c.turma_id as TurmaId
                        from
	                        atividades a
                        inner join cursos c on
	                        a.curso_id = c.id 
	                        where a.id = ANY(@idsParaImportar) ";


            using var conn = ObterConexao();

            return await conn.QueryAsync<AtividadeCursoDto>(query.ToString(), new { idsParaImportar });
        }

        public async Task RemoverPorIds(IEnumerable<long> idsParaExcluir)
        {
            var query = @"delete from atividades where id = ANY(@idsParaExcluir) ";

            using var conn = ObterConexao();

            await conn.ExecuteAsync(query.ToString(), new { idsParaExcluir });
        }

        public async Task<bool> InserirVarios(IEnumerable<AtividadeGsa> atividades)
        {
            var sql = @"copy atividades (                                         
                                        id, 
                                        titulo, 
                                        descricao, 
                                        usuario_id, 
                                        curso_id,
                                        data_inclusao,
                                        data_alteracao,                                        
                                        data_entrega, 
                                        nota_maxima)
                            from
                            stdin (FORMAT binary)";

            using var conn = ObterConexao();

            conn.Open();

            using (var writer = ((NpgsqlConnection)conn).BeginBinaryImport(sql))
            {
                foreach (var atividade in atividades)
                {
                    writer.StartRow();
                    writer.Write(atividade.Id, NpgsqlDbType.Bigint);
                    writer.Write(atividade.Titulo);
                    writer.Write(atividade.Descricao);
                    writer.Write(atividade.UsuarioId, NpgsqlDbType.Bigint);
                    writer.Write(atividade.CursoId, NpgsqlDbType.Bigint);
                    writer.Write(atividade.DataInclusao, NpgsqlDbType.Timestamp);
                    writer.Write(atividade.DataAlteracao, NpgsqlDbType.Timestamp);
                    if (atividade.DataEntrega.HasValue)
                    {
                        writer.Write(atividade.DataEntrega.Value.AddSeconds(1), NpgsqlDbType.Timestamp);
                    }
                    else
                    {
                        writer.WriteNull();
                    }
                    writer.Write(atividade.NotaMaxima, NpgsqlDbType.Numeric);

                }
                writer.Complete();
            }

            conn.Close();

            return await Task.FromResult(true);
        }

    }
}
