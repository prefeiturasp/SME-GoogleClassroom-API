using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IRealizarTratamentoProfessorErroUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}