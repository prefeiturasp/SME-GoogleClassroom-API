using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Classroom.v1;

namespace SME.GoogleClassroom.Aplicacao
{
    public class UtilsGoogleClassroom
    {
       public static readonly string[] Escopos = {
            DirectoryService.Scope.AdminDirectoryUser,
            ClassroomService.Scope.ClassroomCourses,
            ClassroomService.Scope.ClassroomCoursesReadonly,
            ClassroomService.Scope.ClassroomRosters,
            ClassroomService.Scope.ClassroomProfilePhotos,
            ClassroomService.Scope.ClassroomProfileEmails,
        };
    }
}
