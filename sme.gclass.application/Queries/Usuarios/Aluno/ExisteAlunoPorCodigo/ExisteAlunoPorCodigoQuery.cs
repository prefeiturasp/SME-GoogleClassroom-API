using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteAlunoPorCodigoQuery : IRequest<bool>
    {
        public ExisteAlunoPorCodigoQuery(long codigo)
        {
            Codigo = codigo;
        }

        public long Codigo { get; set; }
    }
}