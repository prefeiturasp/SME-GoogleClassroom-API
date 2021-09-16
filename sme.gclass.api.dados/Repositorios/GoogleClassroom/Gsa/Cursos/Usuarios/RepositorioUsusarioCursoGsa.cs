using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
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
            var query = @"SELECT exists(SELECT 1 from public.cursos_usuarios_gsa where usuario_id = @usuarioId and curso_id = @cursoId limit 1)";
            using var conn = ObterConexao();
            return (await conn.QuerySingleOrDefaultAsync<bool>(query, new { usuarioId, cursoId }));
        }

        public async Task<bool> SalvarAsync(UsuarioCursoGsa usuarioCursoGsa)
        {
            const string insertQuery = @"insert into public.cursos_usuarios_gsa
                                        (usuario_id, curso_id, usuario_curso_tipo)
                                        values
                                        (@usuarioId, @cursoId, @usuarioCursoTipo)";

            var parametros = new
            {
                usuarioCursoGsa.UsuarioId,
                usuarioCursoGsa.CursoId,
                usuarioCursoGsa.UsuarioCursoTipo
            };

            using var conn = ObterConexao();
            await conn.ExecuteAsync(insertQuery, parametros);

            return true;
        }

        public async Task<ConsultaCursosDoUsuarioGsa> ObterCursosDoUsuarioGsaAsync(string usuarioId)
        {
            const string query = @"
                select 
	                ug.id as UsuarioId,
	                ug.email,
	                ug.nome,
	                cg.id ,
	                cg.nome,
	                cg.secao,
                    cug.usuario_curso_tipo
                from 
	                usuarios_gsa ug 
                left join
	                cursos_usuarios_gsa cug 
	                on ug.id = cug.usuario_id 
                left join 	
	                cursos_gsa cg 
	                on cug.curso_id = cg.id 
                where 
	                ug.id = @usuarioId";

            var parametros = new
            {
                usuarioId
            };

            using var conn = ObterConexao();

            ConsultaCursosDoUsuarioGsa retorno = null;
            await conn.QueryAsync<ConsultaCursosDoUsuarioGsa, CursoDoUsuarioDto, ConsultaCursosDoUsuarioGsa>(query,
                (consulta, curso) =>
                {
                    if (retorno is null)
                        retorno = consulta;

                    retorno.Cursos = retorno.Cursos ?? new List<CursoDoUsuarioDto>();
                    if (curso != null)
                    {
                        retorno.Cursos.Add(curso);
                    }

                    return retorno;
                }, parametros);

            return retorno;
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM cursos_usuarios_gsa";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }

        public async Task<bool> RemoverAsync(UsuarioCursoGsa usuarioCursoGsa)
        {
            const string query = @"DELETE FROM cursos_usuarios_gsa where curso_id = @cursoId and usuario_id = @usuarioId";

            var parametros = new
            {
                cursoId = usuarioCursoGsa.CursoId,
                usuarioId = usuarioCursoGsa.UsuarioId
            };
            
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query, parametros);

            return true;
        }

        public async Task<IEnumerable<CursoUsuarioRemoverDto>> ObterAlunosCodigosComRegistroEmCurso(IEnumerable<long> alunosCodigos, long turmaId)
        {
            var query = @"SELECT
                    cu.id as CursoUsuarioId,
                    c.id as CursoId,
                    u.indice as UsuarioId,
                    u.google_classroom_id as UsuarioGsaId
                FROM cursos_usuarios cu
               inner join usuarios u on u.indice = cu.usuario_id 
               inner join cursos c on c.id = cu.curso_id 
               where c.turma_id = @turmaId
                 and u.id = ANY(@alunosCodigos)
                 and not cu.excluido
                 and u.usuario_tipo = 1";

            using var conn = ObterConexao();
            return await conn.QueryAsync<CursoUsuarioRemoverDto>(query, new { alunosCodigos, turmaId });
        }
    }
}