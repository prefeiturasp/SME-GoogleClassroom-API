using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioCursoComparativo : RepositorioGoogle, IRepositorioCursoComparativo
    {
        public RepositorioUsuarioCursoComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
    }
}
