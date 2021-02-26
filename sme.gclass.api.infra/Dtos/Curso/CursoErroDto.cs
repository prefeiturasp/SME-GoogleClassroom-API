using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoErroDto
    {
        public long TurmaId { get; set; }

        public long ComponenteCurricularId { get; set; }

        public string Mensagem { get; set; }

        public ExecucaoTipo ExecucaoTipo { get; set; }

        public long? CursoId { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
