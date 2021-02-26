using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuario
    {
        Task<PaginacaoResultadoDto<Usuario>> ObterAlunosAsync(Paginacao paginacao);
        Task<bool> ExisteAlunoPorRf(long rf);
    }
}
