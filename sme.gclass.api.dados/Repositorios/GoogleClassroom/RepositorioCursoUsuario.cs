using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoUsuario : IRepositorioCursoUsuario
    {
        private readonly ConnectionStrings connectionStrings;

        public RepositorioCursoUsuario(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<bool> ExisteProfessorCurso(long usuarioId, long cursoId)
        {
            var query = @"select count(id) 
                           from cursos_usuarios
                          where usuario_id = @usuarioId
                            and curso_id = @cursoId
                            and not excluido";

            var parametros = new
            {
                usuarioId,
                cursoId
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }


        public async Task<long> SalvarAsync(CursoUsuario cursoUsuario)
        {
            var query = @"INSERT INTO public.cursos_usuarios
                           (curso_id, usuario_id, data_inclusao, data_atualizacao, excluido)
                         VALUES
                           (@cursoId, @usuarioId, @dataInclusao);
                         RETURNING id";

            var parametros = new
            {
                cursoUsuario.CursoId,
                cursoUsuario.UsuarioId,
                cursoUsuario.DataInclusao
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}
