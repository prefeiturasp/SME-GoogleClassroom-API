using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterMuralAvisosCarregadosQueryHandler : IRequestHandler<ObterMuralAvisosCarregadosQuery, IEnumerable<AvisoGsa>>
    {
        private readonly IRepositorioAviso repositorio;

        public ObterMuralAvisosCarregadosQueryHandler(IRepositorioAviso repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<AvisoGsa>> Handle(ObterMuralAvisosCarregadosQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterAvisosPorCursoId(request.CursoId);
    }
}
