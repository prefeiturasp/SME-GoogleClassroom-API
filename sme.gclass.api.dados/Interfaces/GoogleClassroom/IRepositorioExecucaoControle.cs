using SME.GoogleClassroom.Dominio;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioExecucaoControle
    {
        Task<bool> AtualizaControleExecucao(ExecucaoTipo execucaoTipo, DateTime data);
    }
}
