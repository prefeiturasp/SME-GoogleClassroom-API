using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioCursoRemovidoGsa : RepositorioGoogle, IRepositorioUsuarioCursoRemovidoGsa
    {
        public RepositorioUsuarioCursoRemovidoGsa(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>> ObterAlunosCursosRemovidosPorCursoId(Paginacao paginacao, string cursoId)
        {
            var query = new StringBuilder(@"SELECT
                                                   ucr.usuario_id UsuarioId,
                                                   ucr.curso_id CursoId,
                                                   ucr.removido_em RemovidoEm 
                                              FROM usuario_curso_removido_gsa ucr
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

            var retorno = new PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Aluno,
                cursoId
            };

            using var conn = ObterConexao();

            using var registros = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = registros.Read<UsuarioCursoRemovidoGsa>();
            retorno.TotalRegistros = registros.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
    }
}