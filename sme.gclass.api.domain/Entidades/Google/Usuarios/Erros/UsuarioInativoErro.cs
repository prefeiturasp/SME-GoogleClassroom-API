using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioInativoErro
    {
        public long? UsuarioId { get; private set; }
        public string Mensagem { get; private set; }
        public UsuarioTipo UsuarioTipo { get; private set; }
        public ExecucaoTipo ExecucaoTipo { get; private set; }
        public DateTime DataInclusao { get; private set; }

        public UsuarioInativoErro(long? usuarioId, string mensagem)
        {
            UsuarioId = usuarioId;
            Mensagem = mensagem;
            UsuarioTipo = UsuarioTipo.Aluno;
            ExecucaoTipo = ExecucaoTipo.AlunoInativar;
            DataInclusao = DateTime.Now;
        }
    }
}
