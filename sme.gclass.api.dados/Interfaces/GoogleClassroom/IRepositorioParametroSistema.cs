using System.Collections.Generic;
using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioParametroSistema
    {
        Task<ParametrosSistema> ObterParametroSistemaPorTipoEAno(TipoParametroSistema tipo, int ano);
        Task<IEnumerable<ParametrosSistema>> ObterParametroSistemaPorAno(int ano);
        Task<long> Salvar(ParametrosSistema parametrosSistema, int novoAno);
    }
}