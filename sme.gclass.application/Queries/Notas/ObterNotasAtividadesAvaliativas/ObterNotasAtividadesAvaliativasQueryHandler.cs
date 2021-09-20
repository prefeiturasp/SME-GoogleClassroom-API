using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterNotasAtividadesAvaliativasQueryHandler : IRequestHandler<ObterNotasAtividadesAvaliativasQuery, PaginacaoResultadoDto<NotasAtividadesDto>>
    {
        private readonly IRepositorioNota repositorioNota;

        public ObterNotasAtividadesAvaliativasQueryHandler(IRepositorioNota repositorioNota)
        {
            this.repositorioNota = repositorioNota ?? throw new ArgumentNullException(nameof(repositorioNota));
        }

        public async Task<PaginacaoResultadoDto<NotasAtividadesDto>> Handle(ObterNotasAtividadesAvaliativasQuery request, CancellationToken cancellationToken)
        {
            return await repositorioNota.ObterNotasAtividadesPorData(request.Paginacao, request.DataReferencia, request.AtividadeId);
        }
    }
}
