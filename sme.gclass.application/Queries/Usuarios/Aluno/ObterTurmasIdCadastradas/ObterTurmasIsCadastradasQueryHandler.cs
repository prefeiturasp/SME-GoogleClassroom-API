using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasIsCadastradasQueryHandler : IRequestHandler<ObterTurmasIsCadastradasQuery, PaginacaoResultadoDto<long>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterTurmasIsCadastradasQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<PaginacaoResultadoDto<long>> Handle(ObterTurmasIsCadastradasQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ObterTurmasComCursoAlunoCadastrado(request.Paginacao);
        }
    }
}
