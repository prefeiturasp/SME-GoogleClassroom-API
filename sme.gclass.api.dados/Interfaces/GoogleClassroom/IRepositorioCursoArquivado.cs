using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoArquivado
    {
        Task<long> Arquivar(long cursoId, DateTime dataArquivamento, bool extinto);
    }
}
