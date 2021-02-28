using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosGoogleQueryHandler : IRequestHandler<ObterFuncionariosGoogleQuery, PaginacaoResultadoDto<UsuarioDto>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterFuncionariosGoogleQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<PaginacaoResultadoDto<UsuarioDto>> Handle(ObterFuncionariosGoogleQuery request, CancellationToken cancellationToken)
           => await repositorioUsuario.ObterFuncionariosAsync(request.Paginacao);
    }
}
