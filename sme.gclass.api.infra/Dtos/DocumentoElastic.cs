using Nest;

namespace SME.Pedagogico.Interface.DTO
{
    public class DocumentoElastic 
    {
        [Number(Name = "Id")]
        public long Id { get; set; }

    }
}
