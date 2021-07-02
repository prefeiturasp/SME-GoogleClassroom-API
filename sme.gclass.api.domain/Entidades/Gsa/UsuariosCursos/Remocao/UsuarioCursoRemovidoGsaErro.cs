namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioCursoRemovidoGsaErro : BaseErro
    {
        public string UsuarioId { get; set; }
        public string CursoId { get; set; }
    }
}
