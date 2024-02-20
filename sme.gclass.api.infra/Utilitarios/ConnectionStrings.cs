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
        public string ConnectionStringApiEol => configuration.GetConnectionString("ApiEolConnection");
        public string ConnectionStringGoogleClassroom => configuration.GetConnectionString("GoogleClassroomConnection");
        public string ConnectionStringConectaFormacao => configuration.GetConnectionString("ConectaFormacaoConnection");
    }
}
