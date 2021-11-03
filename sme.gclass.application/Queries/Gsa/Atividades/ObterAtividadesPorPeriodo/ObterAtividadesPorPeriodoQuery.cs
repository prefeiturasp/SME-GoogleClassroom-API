using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesPorPeriodoQuery : IRequest<(int? totalPaginas, IEnumerable<DadosAvaliacaoDto> atividades)>
    {
        public ObterAtividadesPorPeriodoQuery(DateTime dataInicio, DateTime dataFim, long? cursoId, int pagina = 1, int quantidadeRegistrosPagina = 100)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            CursoId = cursoId;
            Pagina = pagina;
            QuantidadeRegistrosPagina = quantidadeRegistrosPagina;
        }

        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public long? CursoId { get; }
        public int Pagina { get; private set; }
        public int QuantidadeRegistrosPagina { get; private set; }
    }
}
