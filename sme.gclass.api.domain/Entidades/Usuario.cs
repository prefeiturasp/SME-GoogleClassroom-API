using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Dominio
{
    public class Usuario
    {
        public long Id { get; set; }
        public int UsuarioTipo { get; set; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
