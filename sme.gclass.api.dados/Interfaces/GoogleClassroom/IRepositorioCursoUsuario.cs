using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoUsuario
    {
        Task<bool> ExisteProfessorCurso(long usuarioId, long cursoId);
        Task<long> SalvarAsync(CursoUsuario cursoUsuario);
        Task<PaginacaoResultadoDto<ProfessorCursosCadastradosDto>> ObterProfessoresCursosAsync(Paginacao paginacao, long? rf, long? TurmaId, long? ComponenteCurricularId);
        Task<bool> ExisteFuncionarioCurso(long usuarioId, long cursoId);
        Task<PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>> ObterFuncionariosCursosAsync(Paginacao paginacao, long? rf, long? TurmaId, long? ComponenteCurricularId);
    }
}