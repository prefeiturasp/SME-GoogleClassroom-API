using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoComparativo
    {
        Task<long> SalvarAsync(CursoComparativo cursoComparativo);

        Task<PaginacaoResultadoDto<CursoComparativoDto>> ObterCursosComparativosAsync(Paginacao paginacao, string secao, string nome, string descricao);
        Task<int> ValidarCursosExistentesCursosComparativosAsync();
    }
}
