using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCargaInicial : RepositorioGoogle, IRepositorioCargaInicial
    {
        public RepositorioCargaInicial(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }
    }
}
