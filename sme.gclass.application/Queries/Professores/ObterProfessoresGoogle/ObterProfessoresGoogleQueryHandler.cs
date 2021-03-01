using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresGoogleQueryHandler : IRequestHandler<ObterProfessoresGoogleQuery, PaginacaoResultadoDto<ProfessorGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterProfessoresGoogleQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<PaginacaoResultadoDto<ProfessorGoogle>> Handle(ObterProfessoresGoogleQuery request, CancellationToken cancellationToken)
           => await repositorioUsuario.ObterProfessoresAsync(request.Paginacao);
    }
}
