using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoArquivado
    {
        Task<bool> Arquivar(long cursoId, DateTime dataArquivamento, bool extinto);
    }
}
