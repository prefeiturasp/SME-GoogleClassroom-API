using Nest;

namespace SME.GoogleClassroom.Infra
{
    public class DocumentoElastic 
    {
        [Text(Name = "Id")]
        public string Id { get; set; }

    }
}
