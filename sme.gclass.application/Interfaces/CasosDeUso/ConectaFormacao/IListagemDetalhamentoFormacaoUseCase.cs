using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IListagemDetalhamentoFormacaoUseCase
    {
        Task<IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>> Executar(int ano);
    }
}