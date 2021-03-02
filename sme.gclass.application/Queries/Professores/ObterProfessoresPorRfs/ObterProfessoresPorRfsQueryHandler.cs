using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPorRfsQueryHandler : IRequestHandler<ObterProfessoresPorRfsQuery, IEnumerable<ProfessorGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterProfessoresPorRfsQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<ProfessorGoogle>> Handle(ObterProfessoresPorRfsQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterProfessoresPorRfs(request.Rfs);
    }
}