using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAvisoMuralPorIdQueryHandler : IRequestHandler<ObterAvisoMuralPorIdQuery, AvisoGsa>
    {
        private readonly IRepositorioAviso repositorioAviso;

        public ObterAvisoMuralPorIdQueryHandler(IRepositorioAviso repositorioAviso)
        {
            this.repositorioAviso = repositorioAviso ?? throw new ArgumentNullException(nameof(repositorioAviso));
        }

        public async Task<AvisoGsa> Handle(ObterAvisoMuralPorIdQuery request, CancellationToken cancellationToken)
            => await repositorioAviso.ObterPorId(request.Id);
    }
}
