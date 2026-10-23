using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Infra.Dtos.Curso
{
    public class CursoParaIncluirGoogleDto
    {
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long TurmaId { get; set; }
        public string UeCodigo { get; set; }
        public string Email { get; set; }
        public TurmaTipo TurmaTipo { get; set; }
    }
}
