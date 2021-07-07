using MediatR;
using SME.GoogleClassroom.Dados.Interfaces.GoogleClassroom;
using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Avisos
{
    public class ObterAvisoQueryHandler: IRequestHandler<ObterAvisoQuery, IEnumerable<AvisoGsa>>
    {
        private readonly IRepositorioAviso _repositorioAviso;

        public ObterAvisoQueryHandler(IRepositorioAviso repositorioAviso)
        {
            _repositorioAviso = repositorioAviso;
        }

        public async Task<IEnumerable<AvisoGsa>> Handle(ObterAvisoQuery request, CancellationToken cancellationToken)
            => await _repositorioAviso.ObterAvisosAsync(request.UsuarioId);

    }
}