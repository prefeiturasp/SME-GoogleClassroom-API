using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosInativosPorTipoQueryHandler: IRequestHandler<ObterUsuariosInativosPorTipoQuery, PaginacaoResultadoDto<UsuarioInativo>>
    {
        private readonly IRepositorioUsuarioInativo repositorio;

        public ObterUsuariosInativosPorTipoQueryHandler(IRepositorioUsuarioInativo repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativo>> Handle(ObterUsuariosInativosPorTipoQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterUsuariosInativosPorTipo(request.Paginacao, request.TiposDeUsuarios);
    }
}
