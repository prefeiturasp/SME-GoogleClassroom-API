using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoUsuarioRemovidoGsaErro
    {
        Task<long> SalvarAsync(CursoUsuarioRemovidoGsaErro usuarioCursoGsa);
    }
}