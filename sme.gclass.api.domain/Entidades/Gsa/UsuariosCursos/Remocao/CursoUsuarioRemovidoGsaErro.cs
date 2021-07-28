using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoUsuarioRemovidoGsaErro : BaseErro
    {
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public string UsuarioGsaId{ get; set; }

        public CursoUsuarioRemovidoGsaErro()
        {

        }

        public CursoUsuarioRemovidoGsaErro(long usuarioId, long cursoId, string mensagem, UsuarioTipo usuarioTipo, string UsuarioGsaId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
            Mensagem = mensagem;
            UsuarioTipo = usuarioTipo;
            UsuarioGsaId = UsuarioGsaId;
            ExecucaoTipo = ExecucaoTipo.UsuarioCursoRemover;
            Tipo = ErroTipo.Negocio;
            DataInclusao = DateTime.Now;
            UsuarioTipo = usuarioTipo;
        }
    }
}
