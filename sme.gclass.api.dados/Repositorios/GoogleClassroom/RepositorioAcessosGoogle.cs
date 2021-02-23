using Dapper;
using Npgsql;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAcessosGoogle : IRepositorioAcessosGoogle
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioAcessosGoogle(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<IEnumerable<AcessoGoogleDto>> Listar()
        {
            var query = @" SELECT  
                            aplicacao_nome AS AplicacaoNome, 
                            email_conta_servico AS EmailContaServico,
                            email_admin AS EmailAdmin, 
                            private_key AS PrivateKey
                           FROM acessos_google ";

            using (var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom))
            {
                return await conn.QueryAsync<AcessoGoogleDto>(query);
            }
        }
    }
}
