using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ComponenteLancaNotaQuery : IRequest<bool>
    {
        public ComponenteLancaNotaQuery(long componenteCurricularId)
        {
            ComponenteCurricularId = componenteCurricularId;
        }

        public long ComponenteCurricularId { get; set; }
    }
}
