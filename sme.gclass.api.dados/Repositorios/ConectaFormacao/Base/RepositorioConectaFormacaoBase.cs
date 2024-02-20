using Npgsql;
using SME.GoogleClassroom.Infra;
using System;
using System.Data;

namespace SME.GoogleClassroom.Dados
{
    public abstract class RepositorioConectaFormacaoBase
    {
        private readonly ConnectionStrings connectionStrings;

        public RepositorioConectaFormacaoBase(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        protected IDbConnection ObterConexao()
            => new NpgsqlConnection(connectionStrings.ConnectionStringConectaFormacao);
    }
}