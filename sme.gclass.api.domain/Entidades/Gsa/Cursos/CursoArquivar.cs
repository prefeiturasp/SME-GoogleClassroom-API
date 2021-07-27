using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoArquivar
    {
        public long Id { get; set; }
        public long CursoId{ get; set; }
        public DateTime DataArquivamento { get; set; }
        public bool Extinto { get; set; }

        public CursoArquivar()
        {
        }

        public CursoArquivar(long id, long cursoId, DateTime dataArquivamento, bool extinto)
        {
            Id = id;
            CursoId = cursoId;
            DataArquivamento = dataArquivamento;
            Extinto = extinto;
        }
    }
    
    
}