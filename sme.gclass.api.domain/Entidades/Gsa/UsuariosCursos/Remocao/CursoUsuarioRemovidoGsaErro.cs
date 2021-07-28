using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoUsuarioRemovidoGsaErro : BaseErro
    {
        public long CursoUsuarioId { get; set; }
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public string UsuarioIdGsa{ get; set; }

        public CursoUsuarioRemovidoGsaErro()
        {

        }

        public CursoUsuarioRemovidoGsaErro(long usuarioId, long cursoId, string mensagem)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
            Mensagem = mensagem;
            ExecucaoTipo = ExecucaoTipo.UsuarioCursoRemover;
            Tipo = ErroTipo.Negocio;
            DataInclusao = DateTime.Now;
        }
    }
}
