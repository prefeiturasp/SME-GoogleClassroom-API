using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarTratamentoErroCursoAqruivadosUseCase
    {
        Task<bool> Executar();
    }
}