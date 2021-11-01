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
        Task<(IEnumerable<CursoUsuarioDto>, int? totalPaginas)> ObterCursosComResponsaveisPorAno(int anoLetivo, long? cursoId, int? pagina = null, int? quantidadeRegistrosPagina = null);
        Task<int> RemoverAsync(long id);

        Task<CursoUsuario> ObterPorUsuarioIdCursoIdAsync(long usuarioId, long cursoId);

        Task<IEnumerable<UsuarioGoogleDto>> ObterFuncionariosPorCursoId(long cursoId);

        Task<IEnumerable<CursoUsuarioRemoverDto>> ObterPorUsuarioIdETurmaId(long usuarioId, long turmaId);

        Task<IEnumerable<CursoUsuarioInativarDto>> ObterUsuariosPorIdETurmaId(long usuarioId, long turmaId);

        Task<bool> UsuarioEhDonoCurso(long usuarioId, string email);

    }
}