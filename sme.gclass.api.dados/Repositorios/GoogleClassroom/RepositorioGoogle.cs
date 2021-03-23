using Npgsql;
using SME.GoogleClassroom.Infra;
using System;
using System.Data;

namespace SME.GoogleClassroom.Dados
{
    public abstract class RepositorioGoogle
    {
        private readonly ConnectionStrings connectionStrings;

        public RepositorioGoogle(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        protected IDbConnection ObterConexao()
            => new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
    }
}