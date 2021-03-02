using SME.GoogleClassroom.Dominio;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioErro
    {
        Task<long> SalvarAsync(long? usuarioId, string email, string mensagem, UsuarioTipo usuarioTipo, ExecucaoTipo execucaoTipo, DateTime dataInclusao);
    }
}