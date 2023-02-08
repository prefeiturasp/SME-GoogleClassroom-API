using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces.Eol
{
    public interface IRepositorioEscolaEol
    {
        public Task<int> ObterTipoDaEscolaPorCodigoEscola(string codigoEscola);
        public Task<IEnumerable<EscolaDTO>> ObterEscolas(int[] tiposEscola, string codigoDre, string siglaTipoEscola);
    }
}