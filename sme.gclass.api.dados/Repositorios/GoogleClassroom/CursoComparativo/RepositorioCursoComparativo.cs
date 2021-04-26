using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoComparativo: RepositorioGoogle, IRepositorioCursoComparativo
    {
        public RepositorioCursoComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
    }
}
