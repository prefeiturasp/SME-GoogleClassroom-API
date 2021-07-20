using System;

namespace SME.GoogleClassroom.Infra
{
    public class MensagemRabbitSgp
    {
        protected MensagemRabbitSgp() 
        {
            CodigoCorrelacao = Guid.NewGuid();
        }

        public MensagemRabbitSgp(object mensagem, string usuarioLogadoRF = "", string usuarioLogadoNome = "")
        {
            Mensagem = mensagem;
            UsuarioLogadoRF = usuarioLogadoRF;
            UsuarioLogadoNome = usuarioLogadoNome;
            CodigoCorrelacao = Guid.NewGuid();
        }

        public string Action { get; set; }
        public object Mensagem { get; set; }
        public Guid CodigoCorrelacao { get; set; }
        public string UsuarioLogadoNomeCompleto { get; set; }
        public string UsuarioLogadoRF { get; set; }
        public string UsuarioLogadoNome { get; }
        public bool NotificarErroUsuario { get; set; }
        public string PerfilUsuario { get; set; }
    }
}
