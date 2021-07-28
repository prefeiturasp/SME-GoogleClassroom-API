using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoArquivadoDto
    {
        public string Curso { get; set; }
        public DateTime DataExtincao { get; set; }
        public DateTime DataArquivamento { get; set; }

        public CursoArquivadoDto()
        {
        }
    }
}