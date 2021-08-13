using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioNota : RepositorioGoogle, IRepositorioNota
    {
        public RepositorioNota(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }
    }
}
