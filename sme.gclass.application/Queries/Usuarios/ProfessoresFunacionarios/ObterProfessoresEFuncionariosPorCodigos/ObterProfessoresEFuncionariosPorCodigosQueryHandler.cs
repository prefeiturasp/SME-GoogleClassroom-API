using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresEFuncionariosPorCodigosQueryHandler : IRequestHandler<ObterProfessoresEFuncionariosPorCodigosQuery, IEnumerable<ProfessorGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterProfessoresEFuncionariosPorCodigosQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<ProfessorGoogle>> Handle(ObterProfessoresEFuncionariosPorCodigosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ObterFuncionariosEProfessoresPorCodigos(request.ProfessoresEFuncionariosCodigo);
        }
    }
}
