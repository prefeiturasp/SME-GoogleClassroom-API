using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPorRfsPaginadoQueryHandler : IRequestHandler<ObterProfessoresPorRfsPaginadoQuery, PaginacaoResultadoDto<ProfessorGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterProfessoresPorRfsPaginadoQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<PaginacaoResultadoDto<ProfessorGoogle>> Handle(ObterProfessoresPorRfsPaginadoQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterProfessoresPaginadoPorRfs(request.Paginacao, request.Rfs);
    }
}
