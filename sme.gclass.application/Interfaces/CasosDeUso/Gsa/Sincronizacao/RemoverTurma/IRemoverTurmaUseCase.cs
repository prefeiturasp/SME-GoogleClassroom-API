using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.RemoverTurma
{
    public interface IRemoverTurmaUseCase
    {
        Task<bool> Executar(FiltroRemoverTurmaDto filtro);
    }
}