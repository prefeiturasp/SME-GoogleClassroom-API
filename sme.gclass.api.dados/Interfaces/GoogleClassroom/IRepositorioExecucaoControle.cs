using SME.GoogleClassroom.Dominio.Enumerados;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioExecucaoControle
    {
        Task<bool> AtualizaControleExecucao(ExecucaoTipo execucaoTipo, DateTime data);
    }
}
