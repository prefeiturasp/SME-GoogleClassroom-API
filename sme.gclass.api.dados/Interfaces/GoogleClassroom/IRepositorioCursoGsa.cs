using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoGsa
    {
        Task<bool> ExistePorIdAsync(string cursoId);

        Task<long> SalvarAsync(CursoGsa cursoComparativo);

        Task<PaginacaoResultadoDto<CursoGsaDto>> ObterCursosComparativosAsync(Paginacao paginacao, string secao, string nome, string descricao);

        Task<int> ValidarCursosExistentesCursosComparativosAsync();
    }
}