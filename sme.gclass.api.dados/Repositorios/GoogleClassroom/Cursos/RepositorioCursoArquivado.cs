using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoArquivado : IRepositorioCursoArquivado
    {
        public Task<bool> Arquivar(long cursoId, DateTime dataArquivamento, bool extinto)
        {
            throw new NotImplementedException();
        }
    }
}