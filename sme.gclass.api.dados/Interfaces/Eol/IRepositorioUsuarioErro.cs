using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioErro
    {
        Task<long> Salvar(long? usuarioId, string email, string mensagem, int usuarioTipo, int execucaoTipo, DateTime dataInclusao);
    }
}