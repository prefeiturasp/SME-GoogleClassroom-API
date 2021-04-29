namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterComparativoUsuarioDto : FiltroPaginacaoBaseDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public bool EhAdmin { get; set; }
        public string OrganizationPath { get; set; }
    }
}
