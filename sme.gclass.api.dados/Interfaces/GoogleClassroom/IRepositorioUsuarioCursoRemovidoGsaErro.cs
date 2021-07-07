using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioCursoRemovidoGsaErro
    {
        Task<long> SalvarAsync(UsuarioCursoRemovidoGsaErro usuarioCursoGsa);
    }
}