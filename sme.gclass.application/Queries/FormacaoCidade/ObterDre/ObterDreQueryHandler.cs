using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDreQueryHandler : IRequestHandler<ObterDreQuery, IEnumerable<DreDto>>
    {
        private readonly IRepositorioDreEol repositorioDreEol;

        public ObterDreQueryHandler(IRepositorioDreEol repositorioDreEol)
        {
            this.repositorioDreEol = repositorioDreEol;
        }

        public async Task<IEnumerable<DreDto>> Handle(ObterDreQuery request, CancellationToken cancellationToken) 
            => await repositorioDreEol.ObterDres(request.CodigoDre);
    }
}