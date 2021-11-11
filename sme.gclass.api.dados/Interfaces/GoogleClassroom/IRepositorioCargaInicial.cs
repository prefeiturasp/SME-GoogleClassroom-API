using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCargaInicial
    {
        Task<IEnumerable<CargaInicial>> ObterPorAno(int ano);
        Task<long> InserirCargaInicial(int ano, string tiposUes, string ues, string turmas);
    }
}
