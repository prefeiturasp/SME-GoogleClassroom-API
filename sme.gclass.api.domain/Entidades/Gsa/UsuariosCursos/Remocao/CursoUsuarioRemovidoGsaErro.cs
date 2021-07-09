using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoUsuarioRemovidoGsaErro : BaseErro
    {
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }

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
