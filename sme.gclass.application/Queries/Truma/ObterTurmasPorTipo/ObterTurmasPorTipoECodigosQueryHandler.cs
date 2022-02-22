using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class
        ObterTurmasPorTipoECodigosQueryHendler : IRequestHandler<ObterTurmasPorTipoECodigosQuery, IEnumerable<long>>
    {
        private readonly IRepositorioTurmaEscolaEol repositorio;

        public ObterTurmasPorTipoECodigosQueryHendler(IRepositorioTurmaEscolaEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<long>> Handle(ObterTurmasPorTipoECodigosQuery request,
            CancellationToken cancellationToken)
        {
            var tamanho = 0;
            var quantidade = 100;
            var ids = new List<long>();
            var codigosTurma = request.CodigoTurma;
            while (tamanho <= request.CodigoTurma.Count)
            {
                tamanho += quantidade;
                var items = codigosTurma.Take(quantidade).ToList();
                codigosTurma.RemoveRange(0, quantidade);
                ids.AddRange(await repositorio.ObterTurmasPorCodigoETipo(items));
            }

            return ids.Select(x => x);
        }
    }
}