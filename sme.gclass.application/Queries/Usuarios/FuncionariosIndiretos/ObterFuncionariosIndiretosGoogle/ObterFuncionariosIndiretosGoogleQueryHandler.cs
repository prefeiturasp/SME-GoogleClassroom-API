using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.FuncionariosIndiretos.ObterFuncionariosIndiretosGoogle
{
    public class ObterFuncionariosIndiretosGoogleQueryHandler : IRequestHandler<ObterFuncionariosIndiretosGoogleQuery, PaginacaoResultadoDto<FuncionarioIndiretoGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterFuncionariosIndiretosGoogleQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoGoogle>> Handle(ObterFuncionariosIndiretosGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterFuncionariosIndiretoAsync(request.Paginacao, request.Cpf, request.Email);
    }
}