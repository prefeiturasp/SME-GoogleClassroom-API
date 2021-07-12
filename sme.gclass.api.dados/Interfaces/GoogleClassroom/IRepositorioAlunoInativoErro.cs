using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAlunoInativoErro
    {
        Task<long> SalvarAsync(AlunoInativoErro alunoInativoErro);
    }
}