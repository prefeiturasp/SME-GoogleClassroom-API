using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioErro
    {
        public long Id { get; set; }
        public long? UsuarioId { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public ExecucaoTipo ExecucaoTipo { get; set; }
        public DateTime DataInclusao { get; set; }

        public UsuarioErro(long? usuarioId, string email, string mensagem, UsuarioTipo usuarioTipo, ExecucaoTipo execucaoTipo)
        {
            UsuarioId = usuarioId;
            Email = email;
            Mensagem = mensagem;
            UsuarioTipo = usuarioTipo;
            ExecucaoTipo = execucaoTipo;
            DataInclusao = DateTime.Now;
        }

        protected UsuarioErro()
        {
        }
    }
}