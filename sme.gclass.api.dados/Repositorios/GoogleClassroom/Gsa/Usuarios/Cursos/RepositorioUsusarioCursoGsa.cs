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
                                        (usuario_id, curso_id)
                                        values
                                        (@usuarioId, @cursoId)";

            var parametros = new
            {
                usuarioCursoGsa.UsuarioId,
                usuarioCursoGsa.CursoId
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
	                cg.secao 
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
    }
}