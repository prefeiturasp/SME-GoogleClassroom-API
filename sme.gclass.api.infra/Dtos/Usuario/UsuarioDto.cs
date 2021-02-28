using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Infra
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
