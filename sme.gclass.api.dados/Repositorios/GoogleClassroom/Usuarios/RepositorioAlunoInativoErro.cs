using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAlunoInativoErro : RepositorioGoogle, IRepositorioAlunoInativoErro
    {
        public RepositorioAlunoInativoErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

    }
}