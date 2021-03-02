using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteProfessorPorRfQuery : IRequest<bool>
    {
        public ExisteProfessorPorRfQuery(long rf)
        {
            Rf = rf;
        }

        public long Rf { get; set; }
    }
}
