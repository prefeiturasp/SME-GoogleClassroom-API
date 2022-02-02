using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAtividade
    {
        Task<long> AlterarAtividade(AtividadeGsa atividadeGsa);
        Task<long> InserirAtividade(AtividadeGsa atividadeGsa);
        Task<bool> RegistroExiste(long id);
        Task<PaginacaoResultadoDto<AtividadeGsa>> ObterAtividadesPorDataCurso(Paginacao paginacao, DateTime dateReferencia, long? cursoId);
        Task<(int? totalPaginas, IEnumerable<DadosAvaliacaoDto>)> ObterAtividadesPorPeriodo(DateTime dataInicio, DateTime dataFim, long? cursoId, int pagina = 1, int quantidadeRegistrosPagina = 100);
        Task<IEnumerable<long>> ObterComponentesIdsAtividadesPorAnoLetivo(int anoLetivo);
        Task<IEnumerable<AtividadeCursoDto>> ObterAtividadesExistentesAsync(IEnumerable<long> idsParaImportar);
        Task RemoverPorIds(IEnumerable<long> idsParaExcluir);
        Task<bool> InserirVarios(IEnumerable<AtividadeGsa> atividades);
    }
}
