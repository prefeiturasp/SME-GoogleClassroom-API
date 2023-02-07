using Nest;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    [ElasticsearchType(RelationName = "TurmaComponentes")]
    public class TurmaComponentesDto : DocumentoElasticTurma
    {
        public TurmaComponentesDto()
        {
            Componentes = new List<ComponenteTurmaDto>();
        }
        
        [Number(Name = "Modalidade")]
        public int Modalidade { get; set; }
        
        
        [Text(Name = "NomeTurma")]
        public string NomeTurma { get; set; }
        
        
        [Text(Name = "ComplementoTurmaEJA")]
        public string ComplementoTurmaEJA { get; set; }
        
        
        [Text(Name = "Turno")]
        public string Turno { get; set; }
        
        
        [Text(Name = "AnoTurma")]
        public string AnoTurma { get; set; }
        
        
        [Boolean(Name = "Historica")]
        public bool Historica { get; set; }
        
        
        [Number(Name = "TipoEscola")]
        public int TipoEscola { get; set; }
        
        
        [Text(Name = "SituacaoTurmaEscola")]
        public string SituacaoTurmaEscola { get; set; }
        
        
        [Date(Name = "DataStatusTurmaEscola", Format = "MMddyyyy")]
        public DateTime DataStatusTurmaEscola { get; set; }
        
        
        public List<ComponenteTurmaDto> Componentes { get; set; }
        
        
        [Text(Name = "NomeFiltro")]
        public string NomeFiltro { get; set; }
    }
}
