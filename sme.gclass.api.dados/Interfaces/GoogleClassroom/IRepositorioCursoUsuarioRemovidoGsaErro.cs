using System.Collections.Generic;
using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoUsuarioRemovidoGsaErro
    {
        Task<long> SalvarAsync(CursoUsuarioRemovidoGsaErro usuarioCursoGsa);
        Task<IEnumerable<CursoUsuarioRemovidoGsaErro>> ObterTodos();
        Task<int> Excluir(long usuarioId, long cursoId);
    }
}