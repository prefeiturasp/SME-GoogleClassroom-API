using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoArquivadoDto
    {
        public long CursoId { get; set; }
        public DateTime DataArquivamento { get; set; }
        public bool Extinto { get; set; }
    }
}
