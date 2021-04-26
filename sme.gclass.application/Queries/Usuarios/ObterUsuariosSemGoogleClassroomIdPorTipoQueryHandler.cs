using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios
{
    public class ObterUsuariosSemGoogleClassroomIdPorTipoQueryHandler : IRequestHandler<ObterUsuariosSemGoogleClassroomIdPorTipoQuery<FuncionarioGoogle>, PaginacaoResultadoDto<FuncionarioGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuariosSemGoogleClassroomIdPorTipoQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioGoogle>> Handle(ObterUsuariosSemGoogleClassroomIdPorTipoQuery<FuncionarioGoogle> request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ObterUsuariosSemGoogleClassroomIdPorTipoAsync<FuncionarioGoogle>(request.Paginacao, request.UsuarioTipo);
        }
    }
}