using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosInativosPorTipoQueryHandler: IRequestHandler<ObterUsuariosInativosPorTipoQuery, PaginacaoResultadoDto<UsuarioInativoDto>>
    {
        private readonly IRepositorioUsuarioInativo repositorio;

        public ObterUsuariosInativosPorTipoQueryHandler(IRepositorioUsuarioInativo repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativoDto>> Handle(ObterUsuariosInativosPorTipoQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterUsuariosInativosPorTipo(request.Paginacao, request.UsuarioTipo);
    }
}
