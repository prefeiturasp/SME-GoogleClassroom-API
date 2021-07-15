using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioInativo : RepositorioGoogle, IRepositorioUsuarioInativo
    {
        public RepositorioUsuarioInativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<bool> InativarUsuarioAsync(long usuarioId, UsuarioTipo tipo, DateTime inativadoEm)
        {
            try
            {
                const string insertQuery = @"insert into public.usuario_inativo 
                                        (usuario_id, usuario_tipo, inativado_em)
                                        values (@usuarioId, @tipo, @inativadoEm) ";

                var parametros = new
                {
                    usuarioId,
                    tipo,
                    inativadoEm
                };

                using var conn = ObterConexao();
                await conn.ExecuteAsync(insertQuery, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM usuario_inativo";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }
    }
}
