using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Infra.Dtos.Curso
{
    public class FuncionarioCursoParaIncluirGoogleDto
    {
        public long Rf { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string UeCodigo { get; set; }
    }
}
