namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioGoogleDto
    {
        public string Id { get; set; }
        public long Indice { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int UsuarioTipo { get; set; }
        public string OrganizationPath { get; set; }
        public string GoogleClassroomId { get; set; }
        public bool ExisteGoogle { get; set; }
    }
}
