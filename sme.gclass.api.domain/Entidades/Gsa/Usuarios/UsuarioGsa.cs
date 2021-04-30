using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioGsa
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public DateTime DataInclusao { get; set; }
        public bool EhAdmin { get; set; }
        public string OrganizationPath { get; set; }
        public bool UltimoItemDaFila { get; set; }
    }
}
