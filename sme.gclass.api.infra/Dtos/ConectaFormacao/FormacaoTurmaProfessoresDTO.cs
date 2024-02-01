namespace SME.GoogleClassroom.Infra.Dtos.ConectaFormacao
{
    public class FormacaoTurmaProfessoresDTO
    {
        public long CodigoTurma { get; set; }
        public string Rf { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public bool Tutor { get; set; }
    }
}
