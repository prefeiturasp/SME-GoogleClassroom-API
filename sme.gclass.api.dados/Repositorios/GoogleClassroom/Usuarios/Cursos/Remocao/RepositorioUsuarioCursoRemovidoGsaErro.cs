using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioCursoRemovidoGsaErro : RepositorioGoogle, IRepositorioUsuarioCursoRemovidoGsaErro
    {
        public RepositorioUsuarioCursoRemovidoGsaErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
    }
}