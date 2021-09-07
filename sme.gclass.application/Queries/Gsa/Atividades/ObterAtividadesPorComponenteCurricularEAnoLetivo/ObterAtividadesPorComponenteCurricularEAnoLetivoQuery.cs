using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesPorComponenteCurricularEAnoLetivoQuery : IRequest<PaginacaoResultadoDto<DadosAvaliacaoDto>>
    {
        public ObterAtividadesPorComponenteCurricularEAnoLetivoQuery(long componenteCurricularId, DateTime dataReferencia, Paginacao paginacao)
        {
            ComponenteCurricularId = componenteCurricularId;
            DataReferencia = dataReferencia;
            Paginacao = paginacao;
        }

        public long ComponenteCurricularId { get; set; }
        public DateTime DataReferencia { get; set; }
        public Paginacao Paginacao { get; set; }
    }
}
