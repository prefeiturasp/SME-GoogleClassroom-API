using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAtividade : RepositorioGoogle, IRepositorioAtividade
    {
        public RepositorioAtividade(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }
    }
}
