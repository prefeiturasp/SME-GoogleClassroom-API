using System;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAtividade
    {
        Task<PaginacaoResultadoDto<AtividadeGsa>> ObterAtividadesPorData(Paginacao paginacao, DateTime dateReferencia,
            long? cursoId);
    }
}