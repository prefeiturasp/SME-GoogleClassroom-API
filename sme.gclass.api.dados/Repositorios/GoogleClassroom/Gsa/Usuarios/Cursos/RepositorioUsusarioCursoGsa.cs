using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioCursoGsa : RepositorioGoogle, IRepositorioUsuarioCursoGsa
    {
        public RepositorioUsuarioCursoGsa(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<bool> ExistePorUsuarioIdCursoIdAsync(string usuarioId, string cursoId)
        {
            var query = @"SELECT exists(SELECT 1 from public.usuario_gsa where usuario_id = @usuarioId and curso_id = @cursoId limit 1)";
            using var conn = ObterConexao();
            return (await conn.QuerySingleOrDefaultAsync<bool>(query, new { usuarioId, cursoId }));
        }

        public async Task<bool> SalvarAsync(UsuarioCursoGsa usuarioCursoGsa)
        {
            const string insertQuery = @"insert into public.usuario_gsa
                                        (usuario_id, curso_id)
                                        values
                                        (@usuarioId, @cursoId)
                                        RETURNING id";

            var parametros = new
            {
                usuarioCursoGsa.UsuarioId,
                usuarioCursoGsa.CursoId
            };

            using var conn = ObterConexao();
            await conn.ExecuteAsync(insertQuery, parametros);

            return true;
        }
    }
}