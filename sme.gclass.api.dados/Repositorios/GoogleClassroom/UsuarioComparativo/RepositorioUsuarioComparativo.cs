using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioComparativo : RepositorioGoogle, IRepositorioUsuarioComparativo
    {
        public RepositorioUsuarioComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
    }
}
