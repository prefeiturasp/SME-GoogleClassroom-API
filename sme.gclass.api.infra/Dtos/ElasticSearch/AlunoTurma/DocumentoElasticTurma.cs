using Nest;

namespace SME.GoogleClassroom.Infra
{
    [ElasticsearchType(RelationName = "Turma")]
    public class DocumentoElasticTurma: DocumentoElastic
    {
        [Number(Name = "codigoturma")]
        public int CodigoTurma { get; set; }
        [Text(Name = "codigoescola")]
        public string CodigoEscola { get; set; }
        [Number(Name = "anoletivo")]
        public int Ano { get; set; }
    }
}
