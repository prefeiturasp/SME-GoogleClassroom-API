using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterTurmasPorTipoECodigosQueryHendler : IRequestHandler<ObterTurmasPorTipoECodigosQuery, IEnumerable<long>>
    {
        private readonly IRepositorioTurmaEscolaEol repositorio;

        public ObterTurmasPorTipoECodigosQueryHendler(IRepositorioTurmaEscolaEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<long>> Handle(ObterTurmasPorTipoECodigosQuery request,
            CancellationToken cancellationToken)
            => await repositorio.ObterTurmasPorCodigoETipo(request.CodigoTurma);
    }
}