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
        Task<IEnumerable<AvisoGsa>> ObterAvisosPorCursoId(long cursoId);
        Task<int> InserirAviso(AvisoGsa avisoGsa);
        Task<int> AlterarAviso(AvisoGsa avisoGsa);
        Task<AvisoGsa> ObterPorId(long id);
        Task<bool> RegistroExiste(long id);
        Task<PaginacaoResultadoDto<AvisoGsa>> ObterAvisosPorData(Paginacao paginacao, DateTime dateReferencia, string usuarioId, long? cursoId);
    }
}