using SME.GoogleClassroom.Infra;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SME.GoogleClassroom.Dados.Repositorios.Eol.Base
{
    public abstract class RepositorioEol
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioEol(ConnectionStrings connectionStrings)
        {
            ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        protected IDbConnection ObterConexao() => new SqlConnection(ConnectionStrings.ConnectionStringEol);
    }
}