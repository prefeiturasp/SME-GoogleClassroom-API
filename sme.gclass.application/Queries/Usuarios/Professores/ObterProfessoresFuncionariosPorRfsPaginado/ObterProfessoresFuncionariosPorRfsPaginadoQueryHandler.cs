using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresFuncionariosPorRfsPaginadoQueryHandler : IRequestHandler<ObterProfessoresFuncionariosPorRfsPaginadoQuery, PaginacaoResultadoDto<ProfessorGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterProfessoresFuncionariosPorRfsPaginadoQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<PaginacaoResultadoDto<ProfessorGoogle>> Handle(ObterProfessoresFuncionariosPorRfsPaginadoQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterProfessoresFuncionariosPaginadoPorRfs(request.Paginacao, request.Rfs);
    }
}