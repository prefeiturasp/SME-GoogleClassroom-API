using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoGoogleCommand : IRequest<bool>
    {
        public AtribuirDonoCursoGoogleCommand(long cursoId, string usuarioId)
        {
            CursoId = cursoId;
            UsuarioId = usuarioId;
        }
        public long CursoId { get; set; }
        public string UsuarioId { get; set; }
    }
}
