using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosPorCodigosPaginadoQueryHandler : IRequestHandler<ObterAlunosPorCodigosPaginadoQuery, PaginacaoResultadoDto<AlunoGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterAlunosPorCodigosPaginadoQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<PaginacaoResultadoDto<AlunoGoogle>> Handle(ObterAlunosPorCodigosPaginadoQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterAlunosPaginadoPorCodigos(request.Paginacao, request.CodigosAluno);
    }
}
