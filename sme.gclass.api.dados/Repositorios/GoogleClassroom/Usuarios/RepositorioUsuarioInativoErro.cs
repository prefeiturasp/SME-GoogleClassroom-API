using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioInativoErro : RepositorioGoogle, IRepositorioUsuarioInativoErro
    {
        public RepositorioUsuarioInativoErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> SalvarAsync(UsuarioInativoErro usuarioInativoErro)
        {
            var query = @"INSERT INTO public.aluno_inativo_erro  
                           (usuario_id, mensagem, execucao_tipo, data_inclusao)
                         VALUES
                           (@usuarioId, @mensagem, @execucaoTipo, @dataInclusao)
                         RETURNING id";

            var parametros = new
            {
                usuarioInativoErro.UsuarioId,
                usuarioInativoErro.Mensagem,
                usuarioInativoErro.ExecucaoTipo,
                usuarioInativoErro.DataInclusao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }

        public async Task<IEnumerable<UsuarioInativoErro>> BuscarTodo()
        {
            using var conn = ObterConexao();
            return await conn.QueryAsync<UsuarioInativoErro>(
                @"select 
                         usuario_id as UsuarioId,
                         mensagem as Mensagem,
                         execucao_tipo as UsuarioTipo,
                         data_inclusao as DataInclusao
                     from public.aluno_inativo_erro;");
        }

        public async Task<int> Excluir(long usuarioId)
        {
            const string query = @"delete from public.aluno_inativo_erro where usuario_id  = @usuarioId;";

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, new {usuarioId});
        }
    }
}