namespace SME.GoogleClassroom.Infra
{
    public class FiltroInativacaoUsuariosCursosGoogleDto
    {
        public FiltroInativacaoUsuariosCursosGoogleDto(long? alunoId = null)
        {
            AlunoId = alunoId;
        }

        public long? AlunoId { get; set; }
    }
}

