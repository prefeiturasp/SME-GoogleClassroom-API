using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioGsa
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public bool EhAdmin { get; set; }
        public string OrganizationPath { get; set; }
        public bool InseridoManualmenteGoogle { get; set; }
        public DateTime DataInclusao { get; set; }

        public UsuarioGsa(string id, string email, string nome, DateTime? dataUltimoLogin, bool ehAdmin, string organizationPath, bool inseridoManualmenteGoogle, DateTime? dataInclusao = null)
        {
            Id = id;
            Email = email;
            Nome = nome;
            DataUltimoLogin = dataUltimoLogin;
            EhAdmin = ehAdmin;
            OrganizationPath = organizationPath;
            InseridoManualmenteGoogle = inseridoManualmenteGoogle;
            DataInclusao = dataInclusao ?? DateTime.Now;
        }
    }
}