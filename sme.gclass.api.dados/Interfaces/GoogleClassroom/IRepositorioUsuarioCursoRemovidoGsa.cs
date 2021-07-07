using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioUsuarioCursoRemovidoGsa
    {
        Task<PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>> ObterAlunosCursosRemovidosPorCursoId(Paginacao paginacao, string cursoId);
        Task<long> SalvarAsync(UsuarioCursoRemovidoGsa entidade);
    }
}