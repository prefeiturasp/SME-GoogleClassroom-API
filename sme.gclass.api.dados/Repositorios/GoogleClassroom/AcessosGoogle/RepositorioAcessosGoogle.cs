using Dapper;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAcessosGoogle : RepositorioGoogle, IRepositorioAcessosGoogle
    {
        public RepositorioAcessosGoogle(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<AcessoGoogleDto>> Listar()
        {
            var query = @" SELECT
                            aplicacao_nome AS AplicacaoNome,
                            email_conta_servico AS EmailContaServico,
                            email_admin AS EmailAdmin,
                            private_key AS PrivateKey
                           FROM acessos_google ";

            using (var conn = ObterConexao())
            {
                return await conn.QueryAsync<AcessoGoogleDto>(query);
            }
        }
    }
}