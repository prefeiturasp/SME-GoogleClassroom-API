using Nest;

namespace SME.GoogleClassroom.Infra
{
    public class DocumentoElastic 
    {
        [Number(Name = "Id")]
        public long Id { get; set; }

    }
}
