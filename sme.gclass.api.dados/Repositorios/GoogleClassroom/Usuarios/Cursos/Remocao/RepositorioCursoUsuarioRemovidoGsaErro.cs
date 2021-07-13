using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoUsuarioRemovidoGsaErro : RepositorioGoogle, IRepositorioCursoUsuarioRemovidoGsaErro
    {
        public RepositorioCursoUsuarioRemovidoGsaErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> SalvarAsync(CursoUsuarioRemovidoGsaErro usuarioCursoGsa)
        {
            var query = @"INSERT INTO public.curso_usuario_removido_gsa_erro 
                           (curso_id, usuario_id, mensagem, execucao_tipo, data_inclusao)
                         VALUES
                           (@cursoId, @usuarioId, @mensagem, @execucaoTipo, @dataInclusao)
                         RETURNING id";

            var parametros = new
            {
                usuarioCursoGsa.CursoId,
                usuarioCursoGsa.UsuarioId,
                usuarioCursoGsa.Mensagem,
                usuarioCursoGsa.ExecucaoTipo,
                usuarioCursoGsa.DataInclusao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}