using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IAtualizarEmailUsuarioUseCase
    {
        Task Executar(InserirAtualizarEmailDTO filtro);
    }
}