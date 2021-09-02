using SME.GoogleClassroom.Infra;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SME.GoogleClassroom.Dados
{
    public abstract class RepositorioSgp
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioSgp(ConnectionStrings connectionStrings)
        {
            ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        protected IDbConnection ObterConexao()
        {
            var conexao = new SqlConnection(ConnectionStrings.ConnectionStringSgp);
            conexao.Open();
            return conexao;
        }
    }
}
