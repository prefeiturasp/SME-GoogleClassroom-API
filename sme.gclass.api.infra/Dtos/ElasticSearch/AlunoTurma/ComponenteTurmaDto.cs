using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    [ElasticsearchType(RelationName = "ComponenteTurma")]
    public class ComponenteTurmaDto
    {
        private long componenteCurricularCodigo;
        [Text(Name = "NomeComponenteCurricular")]
        public string NomeComponenteCurricular { get; set; }
        [Number(Name = "ComponenteCurricularCodigo")]
        public long ComponenteCurricularCodigo { get { return componenteCurricularCodigo; } 
                                                 set { componenteCurricularCodigo = value;
                                                       ComponenteCurricularCodigoUnico = value.ToString();}}
        [Text(Name = "RegistroFuncional")]
        public string RegistroFuncional { get; set; }
        [Date(Name = "DataDisponibizacao", Format = "MMddyyyy")]
        public DateTime? DataDisponibizacao { get; set; }
        [Ignore]
        public string ComponenteCurricularCodigoUnico { get; set; }
}
}
