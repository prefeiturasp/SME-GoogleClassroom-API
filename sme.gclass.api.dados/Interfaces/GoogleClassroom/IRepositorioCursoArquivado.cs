using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoArquivado
    {
        Task Inserir(long cursoId, DateTime dataArquivamento, bool extinto);
    }
}
