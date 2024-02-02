using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IListagemDetalhamentoFormacaoUseCase
    {
        Task<IEnumerable<FormacaoDetalhaDTO>> Executar(int ano);
    }
}