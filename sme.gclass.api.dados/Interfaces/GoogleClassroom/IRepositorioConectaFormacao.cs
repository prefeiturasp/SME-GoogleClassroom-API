using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioConectaFormacao
    {
        Task<IEnumerable<InscricaoConfirmadaDTO>> ListagemInscricoesConfirmadas(long codigoDaTurma);
    }
}
