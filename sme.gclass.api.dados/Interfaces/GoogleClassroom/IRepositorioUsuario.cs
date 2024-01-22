using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuario
    {
        Task<PaginacaoResultadoDto<AlunoGoogle>> ObterAlunosAsync(Paginacao paginacao, long? codigoEol, string email);

        Task<bool> ExisteAlunoPorCodigo(long codigo);

        Task<bool> ExisteEmailUsuarioPorTipo(string email, UsuarioTipo usuarioTipo, long id);

        Task<PaginacaoResultadoDto<FuncionarioGoogle>> ObterFuncionariosAsync(Paginacao paginacao, long? rf, string email);

        Task<PaginacaoResultadoDto<ProfessorGoogle>> ObterProfessoresAsync(Paginacao paginacao, long? rf, string email);

        Task<int> AtualizarAsync(long id, string nome, string organizationPath, string cpf = null,string email = null,int usuarioTipo = 0);
        Task<UsuarioGoogleDto> ObterUsuarioPorEmail(string email);
        Task<long> ObterIndicePorGoogleClassroomId(string googleClassroomId);
        Task<UsuarioGoogleDto> ObterUsuariosGooglePorCodigos(long[] usuarioCodigo);
        Task<UsuarioGoogleDto> ObteUsuarioPorClassroomId(string classroomId);
        Task<int> AtualizarUsuarioGoogleClassroomIdAsync(long usuarioId, string googleClassroomId);

        Task<IEnumerable<FuncionarioGoogle>> ObterFuncionariosPorRfs(long[] rfs);

        Task<bool> ExisteFuncionarioIndiretoPorCpf(string cpf);

        Task<bool> ExisteFuncionarioPorRf(long rf);

        Task<IEnumerable<ProfessorGoogle>> ObterProfessoresPorRfs(long[] rfs);

        Task<PaginacaoResultadoDto<FuncionarioIndiretoGoogle>> ObterFuncionariosIndiretoAsync(Paginacao paginacao, string cpf, string email);

        Task<PaginacaoResultadoDto<ProfessorGoogle>> ObterProfessoresFuncionariosPaginadoPorRfs(Paginacao paginacao, long[] rfs);

        Task<bool> ExisteProfessorPorRf(long rf);

        Task<long> SalvarAsync(long? id, string cpf, string nome, string email, UsuarioTipo tipo, string organizationPath, DateTime dataInclusao, DateTime? dataAtualizacao, string googleClassroomId);

        Task<IEnumerable<AlunoGoogle>> ObterAlunosPorCodigos(long[] codigosEol);

        Task<PaginacaoResultadoDto<AlunoGoogle>> ObterAlunosPaginadoPorCodigos(Paginacao paginacao, long[] codigosAluno);

        Task<FuncionarioGoogle> ObterFuncionarioPorEmail(string email);

        Task InciarAtualizacaoUsuarioGoogleClassroomIdAsync();

        Task<PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto>> ObterAtualizacaoUsuarioGoogleClassroomIdAsync(Paginacao paginacao);

        Task FinalizarAtualizacaoUsuarioGoogleClassroomIdAsync();

        Task<bool> ExisteUsuarioPorGoogleClassroomIdAsync(string googleClassroomId);
        Task<IEnumerable<long>> ObterTurmasComCursoAlunoCadastrado(int anoLetivo, long? turmaId);

        Task<IEnumerable<ProfessorGoogle>> ObterFuncionariosEProfessoresPorCodigos(long[] Codigos);
        Task<bool> AtualizarUnidadeOrganizacionalAsync(long id, string estruturaOrganizacional);
        Task<FuncionarioCurso> ObterFuncionarioECursoPorUsuarioRFECursoId(long usuarioRF, long cursoId);
        Task<IEnumerable<FuncionarioIndiretoGoogle>> ObterFuncionariosIndiretosPorCpfs(string[] Cpfs);
        Task<IEnumerable<UsuarioGoogleDto>> ObteUsuariosPorClassroomIdsAsync(IEnumerable<string> classroomIds);

        Task<IEnumerable<FuncionarioGoogle>> ObterFuncionariosPorEmail(string requestEmail);
    }
}