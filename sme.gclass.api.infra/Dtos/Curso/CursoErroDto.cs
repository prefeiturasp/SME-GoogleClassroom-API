using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoErroDto
    {
        public int TurmaId { get; set; }

        public int ComponenteCurricularId { get; set; }

        public string Mensagem { get; set; }

        public ExecucaoTipo ExecucaoTipo { get; set; }

        public long? CursoId { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
