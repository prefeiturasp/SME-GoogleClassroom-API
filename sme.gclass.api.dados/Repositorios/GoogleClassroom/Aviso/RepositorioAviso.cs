using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SME.GoogleClassroom.Dados.Interfaces.GoogleClassroom;
using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Aviso
{
    public class RepositorioAviso : RepositorioGoogle, IRepositorioAviso
    {
        public RepositorioAviso(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<AvisoGsa>> ObterAvisosAsync(long usuarioId)
        {
            using var conn = ObterConexao();
            return await conn.QueryAsync<AvisoGsa>("select * from avisos where usuario_id = @usuario_id");
        
        }

        public async Task<int> SalvarAsync(AvisoGsa avisoGsa)
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
    }
}