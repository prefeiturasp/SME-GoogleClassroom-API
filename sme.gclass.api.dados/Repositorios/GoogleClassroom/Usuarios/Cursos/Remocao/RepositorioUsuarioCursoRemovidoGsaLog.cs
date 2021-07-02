using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioCursoRemovidoGsaLog : RepositorioGoogle, IRepositorioUsuarioCursoRemovidoGsaLog
    {
        public RepositorioUsuarioCursoRemovidoGsaLog(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
    }
}