using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterEscolasUseCase
    {
        Task<IEnumerable<EscolaDTO>> Executar();
    }
}