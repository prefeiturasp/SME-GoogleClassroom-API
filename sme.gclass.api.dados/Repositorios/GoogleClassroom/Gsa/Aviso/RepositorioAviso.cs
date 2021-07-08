using System.Collections.Generic;
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
                                        (id, data_inclusao,curso_id,texto, usuario_id)
                                        values
                                        (@id, @data_inclusao, @curso_id, @texto, @usuario_id)";

            var parametros = new
            {
                id = avisoGsa.Id,
                dataInclusao = avisoGsa.DataInclusao,
                cursoId = avisoGsa.CursoId,
                texto = avisoGsa.Texto,
                usuarioId = avisoGsa.UsuarioId
                
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
    }
}