using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioParametroSistema
    {
        Task<ParametrosSistema> ObterParametroSistemaPorTipoEAno(ETipoParametroSistema tipo, int ano);
    }
}