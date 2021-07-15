using Dapper;
using System;
using System.Text;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAtividade : RepositorioGoogle, IRepositorioAtividade
    {
        public RepositorioAtividade(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }


        public async Task<PaginacaoResultadoDto<AtividadeGsa>> ObterAtividadesPorData(Paginacao paginacao,
            DateTime dataReferencia, long? cursoId)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(false, paginacao, cursoId));
            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(true, paginacao, cursoId));

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
            retorno.TotalPaginas = retorno.TotalRegistros > 0 ? (int) Math.Ceiling((double) retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 0;

            return retorno;
        }


        private string MontaQueryObterAvisosPorData(bool ehParaPaginacao, Paginacao paginacao, long? cursoId)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@" A.id AS Id, 
                                            A.titulo AS Titulo, 
                                            A.descricao AS Descricao,  
                                            A.usuario_id AS UsuarioId,
                                            A.curso_id AS CursoId,
                                            A.data_inclusao AS DataInclusao, 
                                            A.data_alteracao AS DataAlteracao ");
            }

            queryCompleta.AppendLine("FROM atividades A ");
            queryCompleta.AppendLine("INNER JOIN CURSOS U ON U.Id = A.CURSO_ID ");
            queryCompleta.AppendLine("WHERE A.DATA_INCLUSAO = @dataReferencia;");


            if (cursoId.HasValue)
                queryCompleta.AppendLine(@"AND A.ID = @cursoId");

            if (paginacao.QuantidadeRegistros > 0)
                queryCompleta.AppendLine(
                    $" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }
        
        
        
        public async Task<long> AlterarAtividade(AtividadeGsa atividadeGsa)
        {
            const string updateQuery = @"update public.atividades
                                            set curso_id = @cursoId
                                              , usuario_id = @usuarioId
                                              , titulo = @titulo
                                              , descricao = @descricao
                                              , data_inclusao = @dataInclusao
                                              , data_alteracao = @dataAlteracao
                                        where id = @id";

            var parametros = new
            {
                id = atividadeGsa.Id,
                usuarioId = atividadeGsa.UsuarioId,
                cursoId = atividadeGsa.CursoId,
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
                                        (id, titulo, descricao, usuario_id, curso_id, data_inclusao, data_alteracao)
                                        values
                                        (@id, @titulo, @descricao, @usuarioId, @cursoId, @dataInclusao, @dataAlteracao)";

            var parametros = new
            {
                id = avisoGsa.Id,
                titulo = avisoGsa.Titulo,
                descricao = avisoGsa.Descricao,
                usuarioId = avisoGsa.UsuarioId,
                cursoId = avisoGsa.CursoId,
                dataInclusao = avisoGsa.DataInclusao,
                dataAlteracao = avisoGsa.DataAlteracao,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<bool> RegistroExiste(long id)
        {
            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<bool>("select 1 from atividades where id = @id", new { id });
        }
    }
}