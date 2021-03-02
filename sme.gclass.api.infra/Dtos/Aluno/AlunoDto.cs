using System;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoDto
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string OrganizationPath { get; set; }

        public int UsuarioTipo { get { return 1; } }

        public string Email { get; set; }
    }
}
