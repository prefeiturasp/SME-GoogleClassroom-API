using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesPorPeriodoQuery : IRequest<IEnumerable<DadosAvaliacaoDto>>
    {
        public ObterAtividadesPorPeriodoQuery(DateTime dataInicio, DateTime dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
    }
}
