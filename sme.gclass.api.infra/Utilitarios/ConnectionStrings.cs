using Microsoft.Extensions.Configuration;
using System;

namespace SME.GoogleClassroom.Infra
{
    public class ConnectionStrings
    {
        private readonly IConfiguration configuration;
        public ConnectionStrings(IConfiguration configuration) {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string ConnectionStringEol => configuration.GetConnectionString("EolConnection");
        public string ConnectionStringGoogleClassroom => "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=db_googleclassroom;Pooling=true;Command Timeout=300;";// configuration.GetConnectionString("GoogleClassroomConnection");
    }
}
