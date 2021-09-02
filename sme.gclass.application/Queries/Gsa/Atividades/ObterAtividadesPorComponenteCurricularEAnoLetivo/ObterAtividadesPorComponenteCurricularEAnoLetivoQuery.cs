using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesPorComponenteCurricularEAnoLetivoQuery : IRequest<PaginacaoResultadoDto<AtividadeGsa>>
    {
        public ObterAtividadesPorComponenteCurricularEAnoLetivoQuery(long componenteCurricularId, int anoLetivo, Paginacao paginacao)
        {
            ComponenteCurricularId = componenteCurricularId;
            AnoLetivo = anoLetivo;
        }

        public long ComponenteCurricularId { get; set; }
        public int AnoLetivo { get; set; }
        public Paginacao Paginacao { get; set; }
    }
}
