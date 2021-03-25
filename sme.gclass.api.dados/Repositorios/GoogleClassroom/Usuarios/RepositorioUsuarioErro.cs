using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioErro : RepositorioGoogle, IRepositorioUsuarioErro
    {
        public RepositorioUsuarioErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
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