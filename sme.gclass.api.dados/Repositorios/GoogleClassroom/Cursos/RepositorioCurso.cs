using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCurso : RepositorioGoogle, IRepositorioCurso
    {
        public RepositorioCurso(ConnectionStrings connectionStrings)
            :base(connectionStrings)
        {
        }

        private string MontaQueryObterTodosOsCursos(bool ehParaPaginacao, Paginacao paginacao, long? turmaId, long? componenteCurricularId, long? cursoId, string emailCriador)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"C.ID, 
                                  C.NOME,
                                  C.SECAO,
                                  C.TURMA_ID AS TURMAID,
                                  C.COMPONENTE_CURRICULAR_ID AS COMPONENTECURRICULARID,
                                  C.DATA_INCLUSAO AS DATAINCLUSAO,
                                  C.DATA_ATUALIZACAO AS DATAATUALIZACAO,
                                  C.EMAIL ");
            }

            queryCompleta.AppendLine(@"FROM CURSOS C");
            queryCompleta.AppendLine(@"WHERE 1=1");

            if (turmaId.HasValue)
                queryCompleta.AppendLine(@"AND C.TURMA_ID = @turmaId");

            if (componenteCurricularId.HasValue)
                queryCompleta.AppendLine(@"AND C.COMPONENTE_CURRICULAR_ID = @componenteCurricularId");

            if (cursoId.HasValue)
                queryCompleta.AppendLine(@"AND C.Id = @cursoId");

            if (!string.IsNullOrEmpty(emailCriador))
                queryCompleta.AppendLine(@"AND C.email like('%" + emailCriador?.Trim().ToLower() + "%')");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }

        public async Task<PaginacaoResultadoDto<CursoGoogle>> ObterTodosCursosAsync(Paginacao paginacao, long? turmaId, long? componenteCurricularId, long? cursoId, string emailCriador)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterTodosOsCursos(false, paginacao, turmaId, componenteCurricularId, cursoId, emailCriador));
            queryCompleta.AppendLine(MontaQueryObterTodosOsCursos(true, paginacao, turmaId, componenteCurricularId, cursoId, emailCriador));

            var retorno = new PaginacaoResultadoDto<CursoGoogle>();

            using var conn = ObterConexao();

            var parametros = new
            {
                paginacao,
                turmaId,
                componenteCurricularId,
                cursoId                
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);

            retorno.Items = multi.Read<CursoGoogle>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
        public async Task<long> SalvarAsync(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao)
        {
            var query = @" INSERT INTO public.cursos
                            (id, email, nome, secao, turma_id, componente_curricular_id, data_inclusao, data_atualizacao)
                            values
                            (@Id, @Email, @Nome, @Secao, @TurmaId, @ComponenteCurricularId, @DataInclusao, @DataAtualizacao)";

            var parametros = new
            {
                id,
                email,
                nome,
                secao,
                turmaId,
                componenteCurricularId,
                dataInclusao,
                dataAtualizacao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }

        public async Task<bool> AlterarAsync(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao)
        {
            var query = @" UPDATE public.cursos set 
                            email = @Email, 
                            nome = @Nome, 
                            secao = @Secao, 
                            turma_id = @TurmaId, 
                            componente_curricular_id = @ComponenteCurricularId, 
                            data_inclusao = @DataInclusao, 
                            data_atualizacao = @DataAtualizacao
                            where id = @Id";

            var parametros = new
            {
                id,
                email,
                nome,
                secao,
                turmaId,
                componenteCurricularId,
                dataInclusao,
                dataAtualizacao
            };

            using var conn = ObterConexao();
            await conn.ExecuteAsync(query, parametros);
            return true;
        }

        public async Task<bool> ExisteCursoPorTurmaComponenteCurricular(long turmaId, long componenteCurricularId)
        {
            var query = @"select id from public.cursos where turma_id = @turmaId and componente_curricular_id = @componenteCurricularId";

            var parametros = new
            {
                turmaId,
                componenteCurricularId
            };

            using var conn = ObterConexao();

            return (await conn.QueryFirstOrDefaultAsync<long>(query, parametros)) > 0;
        }

        public async Task<CursoGoogle> ObterCursoPorTurmaComponenteCurricular(long turmaId, long componenteCurricularId)
        {
            var query = @"select c.id, 
                                 c.nome,
                                 c.secao,
                                 c.turma_id AS TurmaId,
                                 c.componente_curricular_id AS ComponenteCurricularId,
                                 c.data_inclusao AS DataInclusao,
                                 c.data_atualizacao AS DataAtualizacao,
                                 c.Email       
                            from public.cursos c 
                           where turma_id = @turmaId 
                             and componente_curricular_id = @componenteCurricularId";

            var parametros = new
            {
                turmaId,
                componenteCurricularId
            };

            using var conn = ObterConexao();

            return await conn.QueryFirstOrDefaultAsync<CursoGoogle>(query, parametros);
        }

        public async Task<CursoGoogle> ObterCursoPorId(long id)
        {
            var query = @"select c.id, 
                                 c.nome,
                                 c.secao,
                                 c.turma_id AS TurmaId,
                                 c.componente_curricular_id AS ComponenteCurricularId,
                                 c.data_inclusao AS DataInclusao,
                                 c.data_atualizacao AS DataAtualizacao,
                                 c.Email       
                            from public.cursos c 
                           where id = @id";

            var parametros = new
            {
                id
            };

            using var conn = ObterConexao();

            return await conn.QueryFirstOrDefaultAsync<CursoGoogle>(query, parametros);
        }

        public async Task<int> ExcluirCursoAsync(long cursoId)
        {
            const string query = @"delete from cursos_usuarios where curso_id  = @cursoId;
                                   delete from cursos where id  = @cursoId; ";

            var parametros = new
            {
                cursoId
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }

        public async Task<IEnumerable<CursoDto>> ObterCursosPorAno(int anoLetivo, long? cursoId = null)
        {
            var query = @"select id as CursoId
                            , nome
                            , secao
                            , turma_id as TurmaId
                            , componente_curricular_id as ComponenteCurricularId
                        from cursos c 
                        where extract(year from c.data_inclusao) = @anoLetivo ";

            if (cursoId.HasValue)
                query += " and c.id = @cursoId";

            using var conn = ObterConexao();
            return await conn.QueryAsync<CursoDto>(query, new { anoLetivo, cursoId });
        }

        public async Task<IEnumerable<long>> ObterIdsCursosPorTurma(long turmaId)
        {
            using var conn = ObterConexao();
                return await conn.QueryAsync<long>(@"select id from cursos where turma_id = @turmaId ", new { turmaId });
        }
    }
}
