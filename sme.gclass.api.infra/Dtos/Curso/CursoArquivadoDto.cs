using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoArquivadoDto
    {
        public long CursoId { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public DateTime DataExtincao { get; set; }
        public DateTime DataArquivamento { get; set; }

        public CursoArquivadoDto()
        {
        }
    }
}