using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoGsa
    {
        Task<long> SalvarAsync(CursoGsa cursoComparativo);

        Task<PaginacaoResultadoDto<CursoComparativoDto>> ObterCursosComparativosAsync(Paginacao paginacao, string secao, string nome, string descricao);
        Task<int> ValidarCursosExistentesCursosComparativosAsync();
    }
}
