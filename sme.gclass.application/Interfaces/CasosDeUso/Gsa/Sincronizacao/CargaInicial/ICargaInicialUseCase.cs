using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa.Carga_Inicial;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Gsa.Sincronizacao.CargaInicial
{
    public interface ICargaInicialUseCase
    {
        Task<bool> Executar(FiltroCargaInicialDto filtro);
    }
}
