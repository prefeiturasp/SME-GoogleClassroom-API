using System.Collections.Generic;
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

        public async Task<IEnumerable<CursoUsuarioRemovidoGsaErro>> ObterTodos()
        {
            using var conn = ObterConexao();
            return await conn.QueryAsync<CursoUsuarioRemovidoGsaErro>(@"select 
                usuario_id as UsuarioId,
	            curso_id as CursoId,
	            mensagem as Mensagem,
	            execucao_tipo as ExecucaoTipo,
	            data_inclusao as DataInclusao
            from public.curso_usuario_removido_gsa_erro");
        }


        public async Task<int> Excluir(long usuarioId, long cursoId)
        {
            using var conn = ObterConexao();

            const string command = @"DELETE
                                        FROM
                                    public.curso_usuario_removido_gsa_erro
                                    WHERE
                                        usuario_id = @usuarioId 
                                        and
                                         curso_id = @cursoId;
                                        ";

            return await conn.ExecuteAsync(command, new {usuarioId, cursoId});
        }
    }
}