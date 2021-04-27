using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IUseCase<in TParameter, TResponse>
    {
        Task<TResponse> Executar(TParameter param);
    }
}
