using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class ComponenteTerritorioTurmaDto
    {
        public string NomeComponenteCurricular { get; set; }
        public long ComponenteCurricularCodigo { get; set; }
        public string ComponenteCurricularCodigoUnico { get; set; }
        public string RegistroFuncional { get; set; }
        public DateTime? DataDisponibizacao { get; set; }
        public long ComponenteCurricularCodigoEol { get; set; }
    }
}
