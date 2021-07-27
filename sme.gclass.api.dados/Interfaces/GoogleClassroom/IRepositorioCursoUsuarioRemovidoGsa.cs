using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoUsuarioRemovidoGsa
    {
        Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> ObterProfessoresRemovidosCursosPorId(Paginacao paginacao, long cursoId);

        Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> ObterAlunosCursosRemovidosPorCursoId(Paginacao paginacao, long cursoId);

        Task<long> SalvarAsync(CursoUsuarioRemovidoGsa entidade);
      
        Task LimparAsync();
    }
}