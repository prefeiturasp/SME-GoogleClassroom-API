using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAvisoQueryHandler: IRequestHandler<ObterAvisoQuery, PaginacaoResultadoDto<AvisoGsa>>
    {
        private readonly IRepositorioAviso _repositorioAviso;

        public ObterAvisoQueryHandler(IRepositorioAviso repositorioAviso)
        {
            _repositorioAviso = repositorioAviso ?? throw new System.ArgumentNullException(nameof(repositorioAviso));
        }

        public async Task<PaginacaoResultadoDto<AvisoGsa>> Handle(ObterAvisoQuery request, CancellationToken cancellationToken)
            => await _repositorioAviso.ObterAvisosPorData(request.Paginacao, request.DataReferencia, request.UsuarioId, request.CursoId);

    }
}