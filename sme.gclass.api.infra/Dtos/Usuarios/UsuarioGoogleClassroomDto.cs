using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioGoogleClassroomDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public bool? Suspenso { get; set; }       
        public DateTime? DataCriacao { get; set; }
    }
}
