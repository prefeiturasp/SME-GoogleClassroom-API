using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoGoogleCommand : IRequest<bool>
    {
        public AtribuirDonoCursoGoogleCommand(string email, long turmaId, long componenteCurricularId)
        {
            Email = email;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public string Email { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
    }
}
