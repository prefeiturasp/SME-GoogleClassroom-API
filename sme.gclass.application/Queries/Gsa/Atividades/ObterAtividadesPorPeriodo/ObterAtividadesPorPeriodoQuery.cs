using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesPorPeriodoQuery : IRequest<IEnumerable<DadosAvaliacaoDto>>
    {
        public ObterAtividadesPorPeriodoQuery(DateTime dataInicio, DateTime dataFim, long? cursoId)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            CursoId = cursoId;
        }

        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public long? CursoId { get; }
    }
}
