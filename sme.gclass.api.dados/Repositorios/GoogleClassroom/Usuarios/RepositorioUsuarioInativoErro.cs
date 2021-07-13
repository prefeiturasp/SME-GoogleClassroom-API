using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
   }
}