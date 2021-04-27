using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios
{
    public class ObterUsuariosSemGoogleClassroomIdPorTipoQueryHandler : IRequestHandler<ObterUsuariosSemGoogleClassroomIdPorTipoQuery, PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuariosSemGoogleClassroomIdPorTipoQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto>> Handle(ObterUsuariosSemGoogleClassroomIdPorTipoQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterUsuariosSemGoogleClassroomIdPorTipoAsync(request.Paginacao);
    }
}