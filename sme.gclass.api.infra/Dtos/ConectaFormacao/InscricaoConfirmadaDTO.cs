namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class InscricaoConfirmadaDTO
    {
        public string CodigoRf { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DreCodigo { get; set; }
        public string UeCodigo { get; set; }
        public string DreNome { get; set; }
        public string UeNome { get; set; }
        public bool EhUsuarioCustistaUeParceira { get; set; }
    }
}