using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Classroom.v1;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ServicoGoogleClassroom : IServicoGoogleClassroom
    {
        private readonly DirectoryService DiretorioClassroom;
        private readonly ClassroomService ServicoClassroom;

        static readonly string[] Scopes = {
            DirectoryService.Scope.AdminDirectoryUser,
            ClassroomService.Scope.ClassroomCourses,
            ClassroomService.Scope.ClassroomCoursesReadonly,
            ClassroomService.Scope.ClassroomRosters,
            ClassroomService.Scope.ClassroomProfilePhotos,
            ClassroomService.Scope.ClassroomProfileEmails,
        };

        public ServicoGoogleClassroom(IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry)
        {
            var emailServico = configuration.GetSection("GoogleClassroomEmailServico").ToString();
            var emailAdmin = configuration.GetSection("GoogleClassroomEmailAdmin").ToString();
            var chaveGoogle = configuration.GetSection("GoogleClassroomChaveAPI").ToString();

            var credenciais = new ServiceAccountCredential(
              new ServiceAccountCredential.Initializer(emailServico)
              {
                  Scopes = Scopes,
                  User = emailAdmin,
              }.FromPrivateKey(chaveGoogle));

            DiretorioClassroom = new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais,
                ApplicationName = "sync-eol",
            });

            ServicoClassroom = new ClassroomService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais,
                ApplicationName = "sync-eol",
            });
        }

        public DirectoryService ObterDiretorioClassroom() => DiretorioClassroom;

        public ClassroomService ObterServidorClassroom() => ServicoClassroom;
    }
}
