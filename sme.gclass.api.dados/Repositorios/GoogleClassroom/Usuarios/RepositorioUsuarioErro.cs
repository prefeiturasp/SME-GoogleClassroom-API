using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioErro : RepositorioGoogle, IRepositorioUsuarioErro
    {
        public RepositorioUsuarioErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<int> ExcluirAsync(long usuarioErroId)
        {
            const string command = @"DELETE
                                        FROM
                                    public.usuarios_erro
                                    WHERE
                                        id = @usuarioErroId;";

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(command, new { usuarioErroId });
        }

        public async Task<IEnumerable<UsuarioErro>> ObtemUsuariosErrosPorTipoAsync(UsuarioTipo usuarioTipo)
        {
            const string query = @"SELECT
                                    id, 
                                    usuario_id AS UsuarioId, 
                                    email, mensagem, 
                                    usuario_tipo AS UsuarioTipo, 
                                    execucao_tipo AS ExecucaoTipo, 
                                    data_inclusao AS DataInclusao
                                 FROM
                                    public.usuarios_erro
                                 WHERE
                                    usuario_tipo = @usuarioTipo
                                    AND usuario_id is not null;";

            using var conn = ObterConexao();
            return await conn.QueryAsync<UsuarioErro>(query, new { usuarioTipo });
        }

        public async Task<long> SalvarAsync(UsuarioErro usuarioErro)
        {
            var query = @" INSERT INTO public.usuarios_erro
                                  (usuario_id, email, mensagem, usuario_tipo, execucao_tipo, data_inclusao)
                           VALUES (@usuarioId, @email, @mensagem, @usuarioTipo, @execucaoTipo, @dataInclusao)
                           RETURNING id";

            using (var conn = ObterConexao())
            {
                return await conn.ExecuteScalarAsync<long>(query,
                    new
                    {
                        usuarioId = usuarioErro.UsuarioId,
                        email = usuarioErro.Email,
                        mensagem = usuarioErro.Mensagem,
                        usuarioTipo = usuarioErro.UsuarioTipo,
                        execucaoTipo = usuarioErro.ExecucaoTipo,
                        dataInclusao = usuarioErro.DataInclusao
                    });
            }
        }
    }
}