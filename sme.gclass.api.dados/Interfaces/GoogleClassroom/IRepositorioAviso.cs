using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAviso
    {
        Task<IEnumerable<AvisoGsa>> ObterAvisosAsync(long usuarioId);
        Task<PaginacaoResultadoDto<AvisoGsa>> ObterAvisosPorData(Paginacao paginacao, DateTime dateReferencia, string usuarioId, long? cursoId);
        Task<int> SalvarAsync(AvisoGsa avisoGsa);
    }
}