using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosInativosQueryHandler : IRequestHandler<ObterFuncionariosInativosQuery, PaginacaoResultadoDto<UsuarioInativo>>
    {
        private readonly IRepositorioUsuarioInativo repositorio;

        public ObterFuncionariosInativosQueryHandler(IRepositorioUsuarioInativo repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativo>> Handle(ObterFuncionariosInativosQuery request, CancellationToken cancellationToken)
        {
            return await repositorio.ObterFuncionariosInativos(request.Paginacao);
        }
    }
}
