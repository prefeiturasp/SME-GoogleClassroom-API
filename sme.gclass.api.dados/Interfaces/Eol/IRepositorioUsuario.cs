using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassrom.Dados
{
    public interface IRepositorioUsuario
    {
        Task<UsuarioDto> BuscarRfEmailAsync(string login);
    }
}
