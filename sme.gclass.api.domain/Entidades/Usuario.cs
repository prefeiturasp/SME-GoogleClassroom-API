using System;

namespace SME.GoogleClassroom.Dominio
{
    public class Usuario
    {
        public string CodigoRf { get; set; }
        public DateTime? ExpiracaoRecuperacaoSenha { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public Guid PerfilAtual { get; set; }

        public Guid? TokenRecuperacaoSenha { get; set; }
        public DateTime UltimoLogin { get; set; }
        public string Email { get; set; }

    }
}
