using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteFuncionarioPorRfQuery : IRequest<bool>
    {
        public ExisteFuncionarioPorRfQuery(long rf)
        {
            Rf = rf;
        }

        public long Rf { get; set; }
    }
}
