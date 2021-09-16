using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasIdsCadastradasQueryHandler : IRequestHandler<ObterTurmasIdsCadastradasQuery, IEnumerable<long>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterTurmasIdsCadastradasQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<long>> Handle(ObterTurmasIdsCadastradasQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ObterTurmasComCursoAlunoCadastrado(request.AnoLetivo, request.TurmaId);
        }
    }
}
