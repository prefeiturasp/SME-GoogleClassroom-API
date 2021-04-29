using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioCursoComparativo : RepositorioGoogle, IRepositorioUsuarioCursoComparativo
    {
        public RepositorioUsuarioCursoComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
    }
}
