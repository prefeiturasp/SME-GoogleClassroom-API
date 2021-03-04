namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosCadastradosDto : FiltroPaginacaoBaseDto
    {
        public long? CodigoEol { get; set; }
        public string Email { get; set; }
    }
}