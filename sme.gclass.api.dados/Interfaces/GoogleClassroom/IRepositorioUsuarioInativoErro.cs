using System.Collections.Generic;
using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioUsuarioInativoErro
    {
        Task<long> SalvarAsync(UsuarioInativoErro alunoInativoErro);

        Task<IEnumerable<UsuarioInativoErro>> BuscarTodos();
        Task<int> Excluir(long requestUsuarioId);
    }
}