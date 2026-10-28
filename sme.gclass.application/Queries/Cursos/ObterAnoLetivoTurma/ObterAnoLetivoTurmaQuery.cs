using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAnoLetivoTurmaQuery : IRequest<int?>
    {
        public ObterAnoLetivoTurmaQuery(long turmaId)
        {
            TurmaId = turmaId;
        }

        public long TurmaId { get; }
    }
}