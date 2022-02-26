using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoGsa
    {
        Task<bool> ExistePorIdAsync(long cursoId);

        Task<int> SalvarAsync(CursoGsa cursoComparativo);

        Task<PaginacaoResultadoDto<CursoGsaDto>> ObterCursosComparativosAsync(Paginacao paginacao, string secao, string nome, string descricao);

        Task<int> ValidarCursosExistentesCursosComparativosAsync();

        Task<IEnumerable<CursoGsaId>> ObterCursosGsaPorAno(int anoLetivo, long? cursoId, int pagina = 0, int quantidadeRegistrosPagina = 100);

        Task LimparAsync();

        Task<CursoGsaDto> ObterCursoGsaPorNomeAsync(string nome);
    }
}