using System;

namespace SME.GoogleClassroom.Infra
{
    public  class AlunoParaInclusaoDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int UsuarioTipo { get; set; }
        public string Email { get; set; }
        public string CaminhoOrganizacao { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
