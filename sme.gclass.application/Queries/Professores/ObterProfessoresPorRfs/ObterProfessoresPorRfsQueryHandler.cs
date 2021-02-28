using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPorRfsQueryHandler : IRequestHandler<ObterProfessoresPorRfsQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterProfessoresPorRfsQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(ObterProfessoresPorRfsQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterProfessoresPorRfs(request.Rfs);
    }
}
