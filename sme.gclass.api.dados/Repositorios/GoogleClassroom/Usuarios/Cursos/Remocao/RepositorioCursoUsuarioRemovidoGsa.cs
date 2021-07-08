using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoUsuarioRemovidoGsa : RepositorioGoogle, IRepositorioCursoUsuarioRemovidoGsa
    {
        public RepositorioCursoUsuarioRemovidoGsa(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoGsa>> ObterAlunosCursosRemovidosPorCursoId(Paginacao paginacao, string cursoId)
        {
            var query = new StringBuilder(@"SELECT
                                                   ucr.usuario_id UsuarioId,
                                                   ucr.curso_id CursoId,
                                                   ucr.removido_em RemovidoEm 
                                              FROM curso_usuario_removido_gsa ucr
                                             WHERE ucr.usuario_tipo = @tipo ");

            var queryCount = new StringBuilder("SELECT count(*) from usuarios u WHERE u.usuario_tipo = @tipo ");

            if (!string.IsNullOrEmpty(cursoId))
            {
                query.AppendLine("AND u.curso_id = @cursoId");
                queryCount.AppendLine("AND u.curso_id = @cursoId");
            }

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");
            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<CursoUsuarioRemovidoGsa>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Aluno,
                cursoId
            };

            using var conn = ObterConexao();

            using var registros = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = registros.Read<CursoUsuarioRemovidoGsa>();
            retorno.TotalRegistros = registros.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<long> SalvarAsync(CursoUsuarioRemovidoGsa entidade)
        {
            var query = @"INSERT INTO public.curso_usuario_removido_gsa
                           (curso_id, usuario_id, removido_em, usuario_tipo)
                         VALUES
                           (@cursoId, @usuarioId, @removidoEm, @usuarioTipo)
                         RETURNING id";

            var parametros = new
            {
                entidade.CursoId,
                entidade.UsuarioId,
                entidade.RemovidoEm,
                entidade.UsuarioTipo
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM curso_usuario_removido_gsa";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }
    }
}