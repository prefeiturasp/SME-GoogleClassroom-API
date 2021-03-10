using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IEnviarRequisicaoAtribuirProfessorCursoUseCase
    {
        Task<bool> Executar(AtribuirProfessorCursoDto atribuirProfessorCursoDto);
    }
}