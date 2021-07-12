using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAviso : RepositorioGoogle, IRepositorioAviso
    {
        public RepositorioAviso(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        private string ObterSelectAvisos()
            => @"select id 
                    , texto
                    , data_inclusao as DataInclusao
                    , usuario_id as UsuarioId
                    , curso_id as CursoId
                from avisos ";

        public async Task<IEnumerable<AvisoGsa>> ObterAvisosAsync(long usuarioId)
        {
            using var conn = ObterConexao();
            return await conn.QueryAsync<AvisoGsa>($"{ObterSelectAvisos()} where usuario_id = @usuarioId", new { usuarioId });
        }

        public async Task<IEnumerable<AvisoGsa>> ObterAvisosPorCursoId(long cursoId)
        {
            using var conn = ObterConexao();
            return await conn.QueryAsync<AvisoGsa>($"{ObterSelectAvisos()} where curso_id = @cursoId", new { cursoId });
        }

        public async Task<int> InserirAviso(AvisoGsa avisoGsa)
        {
            const string insertQuery = @"insert into public.avisos
                                        (id, texto, usuario_id, curso_id, data_inclusao, data_alteracao)
                                        values
                                        (@id, @texto, @usuarioId, @cursoId, @dataInclusao, @dataAlteracao)";

            var parametros = new
            {
                id = avisoGsa.Id,
                texto = avisoGsa.Texto,
                usuarioId = avisoGsa.UsuarioId,
                cursoId = avisoGsa.CursoId,
                dataInclusao = avisoGsa.DataInclusao,
                dataAlteracao = avisoGsa.DataAlteracao,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<int> AlterarAviso(AvisoGsa avisoGsa)
        {
            const string updateQuery = @"update public.avisos
                                            set curso_id = @cursoId
                                              , usuario_id = @usuarioId
                                              , texto = @texto
                                              , data_inclusao = @dataInclusao
                                        where id = @id";

            var parametros = new
            {
                id = avisoGsa.Id,
                usuarioId = avisoGsa.UsuarioId,
                cursoId = avisoGsa.CursoId,
                texto = avisoGsa.Texto,
                dataInclusao = avisoGsa.DataInclusao,

            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery, parametros);
        }

        public async Task<AvisoGsa> ObterPorId(long id)
        {
            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<AvisoGsa>($"{ObterSelectAvisos()} where id = @id", new { id });
        }

        public async Task<bool> RegistroExiste(long id)
        {
            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<bool>("select 1 from avisos where id = @id", new { id });
        }

        public async Task<PaginacaoResultadoDto<AvisoGsa>> ObterAvisosPorData(Paginacao paginacao, DateTime dataReferencia, string usuarioId, long? cursoId)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(false, paginacao, usuarioId, cursoId));
            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(true, paginacao, usuarioId, cursoId));

            var retorno = new PaginacaoResultadoDto<AvisoGsa>();

            using var conn = ObterConexao();

            var parametros = new
            {
                dataReferencia,
                usuarioId,
                cursoId
            };

            var multi = await conn.QueryAsync<AvisoGsa>(queryCompleta.ToString(), parametros);
            retorno.Items = multi;
            retorno.TotalRegistros = multi.ToList().Count();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryObterAvisosPorData(bool ehParaPaginacao, Paginacao paginacao, string usuarioId, long? cursoId)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@" A.ID AS Id, 
                                            A.TEXTO AS Texto, 
                                            A.DATA_INCLUSAO AS DataInclusao,  
                                            A.USUARIO_ID AS UsuarioId, 
                                            A.CURSO_ID AS CursoId");
            }

            queryCompleta.AppendLine("FROM AVISOS A");
            queryCompleta.AppendLine("INNER JOIN USUARIOS U ON U.INDICE = A.USUARIO_ID");
            queryCompleta.AppendLine("WHERE A.DATA_INCLUSAO = @dataReferencia");

            if (!string.IsNullOrEmpty(usuarioId))
                queryCompleta.AppendLine($"AND U.GOOGLE_CLASSROOM_ID = @usuarioId");

            if (cursoId.HasValue)
                queryCompleta.AppendLine(@"AND C.ID = @cursoId");

            if (paginacao.QuantidadeRegistros > 0)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }
    }
}