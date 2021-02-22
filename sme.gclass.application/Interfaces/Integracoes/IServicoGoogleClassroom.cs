using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Classroom.v1;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IServicoGoogleClassroom
    {
        DirectoryService ObterDiretorioClassroom();

        ClassroomService ObterServidorClassroom();
    }
}
