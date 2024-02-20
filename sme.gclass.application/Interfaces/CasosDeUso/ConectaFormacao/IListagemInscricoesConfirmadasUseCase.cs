using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IListagemInscricoesConfirmadasUseCase
    {
        Task<IEnumerable<InscricaoRetornoDTO>> Executar(long codigoDaTurma);
    }
}