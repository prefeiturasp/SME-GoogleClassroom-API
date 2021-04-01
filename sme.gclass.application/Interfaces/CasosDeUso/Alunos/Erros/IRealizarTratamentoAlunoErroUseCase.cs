using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IRealizarTratamentoAlunoErroUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagem);
    }
}