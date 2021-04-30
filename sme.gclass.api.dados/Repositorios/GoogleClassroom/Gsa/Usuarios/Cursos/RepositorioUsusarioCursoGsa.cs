using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioCursoComparativo : RepositorioGoogle, IRepositorioUsuarioCursoGsa
    {
        public RepositorioUsuarioCursoComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
    }
}
