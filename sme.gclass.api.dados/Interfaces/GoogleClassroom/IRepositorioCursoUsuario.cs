using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoUsuario
    {
        Task<bool> ExisteProfessorCurso(long usuarioId, long cursoId);

        Task<long> SalvarAsync(CursoUsuario cursoUsuario);

        Task<PaginacaoResultadoDto<ProfessorCursosCadastradosDto>> ObterProfessoresCursosAsync(Paginacao paginacao, long? rf, long? TurmaId, long? ComponenteCurricularId);

        Task<bool> ExisteAlunoCurso(long usuarioId, long cursoId);

        Task<PaginacaoResultadoDto<AlunoCursosCadastradosDto>> ObterAlunosCursosAsync(Paginacao paginacao, long? codigoAluno, long? turmaId, long? componenteCurricularId);

        Task<bool> ExisteFuncionarioCurso(long usuarioId, long cursoId);

        Task<PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>> ObterFuncionariosCursosAsync(Paginacao paginacao, long? rf, long? TurmaId, long? ComponenteCurricularId);
        Task<IEnumerable<CursoUsuarioDto>> ObterCursosComResponsaveisPorAno(int anoLetivo, long? cursoId);
        Task<int> RemoverAsync(long id);

        Task<CursoUsuario> ObterPorUsuarioIdCursoIdAsync(long usuarioId, long cursoId);

        Task<IEnumerable<UsuarioGoogle>> ObterFuncionariosPorCursoId(long cursoId);
    }
}