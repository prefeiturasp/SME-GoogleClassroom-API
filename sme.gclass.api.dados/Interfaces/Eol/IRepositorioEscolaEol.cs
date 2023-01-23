using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces.Eol
{
    public interface IRepositorioEscolaEol
    {
        public Task<int> ObterTipoDaEscolaPorCodigoEscola(string codigoEscola);
    }
}