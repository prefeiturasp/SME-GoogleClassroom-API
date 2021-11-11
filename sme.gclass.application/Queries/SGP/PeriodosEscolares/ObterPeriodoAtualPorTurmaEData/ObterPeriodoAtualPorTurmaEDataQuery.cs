using MediatR;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterPeriodoAtualPorTurmaEDataQuery : IRequest<PeriodoDto>
    {
        public ObterPeriodoAtualPorTurmaEDataQuery(long turmaId, DateTime dataReferencia)
        {
            TurmaId = turmaId;
            DataReferencia = dataReferencia;
        }

        public long TurmaId { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
