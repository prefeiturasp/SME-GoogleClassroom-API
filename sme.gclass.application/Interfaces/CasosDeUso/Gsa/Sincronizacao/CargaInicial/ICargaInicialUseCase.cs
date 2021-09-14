using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ICargaInicialUseCase
    {
        Task<bool> Executar(FiltroCargaInicialDto filtro);
    }
}
