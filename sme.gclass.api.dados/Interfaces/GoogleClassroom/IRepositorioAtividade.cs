using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAtividade
    {
        Task<long> AlterarAtividade(AtividadeGsa atividadeGsa);
        Task<long> InserirAtividade(AtividadeGsa atividadeGsa);
        Task<bool> RegistroExiste(long id);
        Task<PaginacaoResultadoDto<AtividadeGsa>> ObterAtividadesPorDataCurso(Paginacao paginacao, DateTime dateReferencia,
            long? cursoId);
        Task<PaginacaoResultadoDto<AtividadeGsa>> ObterAtividadesPorDataReferencia(Paginacao paginacao, DateTime dateReferencia);
    }
}
