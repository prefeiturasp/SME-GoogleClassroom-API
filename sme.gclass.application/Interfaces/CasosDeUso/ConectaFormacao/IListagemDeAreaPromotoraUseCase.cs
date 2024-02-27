using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IListagemDeAreaPromotoraUseCase
    {
        Task<IEnumerable<AreaPromotoraDTO>> Executar();
    }
}
