using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosInativosQueryHandler : IRequestHandler<ObterAlunosInativosQuery, PaginacaoResultadoDto<UsuarioInativo>>
    {
        private readonly IRepositorioUsuarioInativo repositorio;

        public ObterAlunosInativosQueryHandler(IRepositorioUsuarioInativo repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativo>> Handle(ObterAlunosInativosQuery request, CancellationToken cancellationToken)
        {
            return await repositorio.ObterAlunosInativos(request.Paginacao);
        }
    }
}
