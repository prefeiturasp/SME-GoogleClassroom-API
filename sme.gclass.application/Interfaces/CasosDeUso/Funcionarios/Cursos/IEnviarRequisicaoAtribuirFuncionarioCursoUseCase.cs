using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IEnviarRequisicaoAtribuirFuncionarioCursoUseCase
    {
        Task<bool> Executar(AtribuirFuncionarioCursoDto atribuirFuncionarioCurso);
    }
}